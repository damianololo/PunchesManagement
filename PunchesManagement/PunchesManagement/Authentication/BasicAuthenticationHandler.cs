using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PunchesManagement.DataAccess.CQRS.Queries.UsersQuery;
using PunchesManagement.DataAccess.CQRS;
using PunchesManagement.DataAccess.Entities;

namespace MagazynEdu.Authentication;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IQueryExecutor _queryExecutor;
    private readonly IPasswordHasher<User> _passwordHasher;

    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IQueryExecutor queryExecutor,
        IPasswordHasher<User> passwordHasher)
        : base(options, logger, encoder, clock)
    {
        _queryExecutor = queryExecutor;
        _passwordHasher = passwordHasher;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        var endpoint = Context.GetEndpoint();
        if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
        {
            return AuthenticateResult.NoResult();
        }

        if (!Request.Headers.ContainsKey("Authorization"))
        {
            return AuthenticateResult.Fail("Missing Authorization Header");
        }

        User user = null;
        try
        {
            var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
            var username = credentials[0];
            var password = credentials[1];
            var query = new GetUserQuery()
            {
                UserName = username
            };
            user = await _queryExecutor.Execute(query);

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);

            if (user == null || result == PasswordVerificationResult.Failed)
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

        }
        catch
        {
            return AuthenticateResult.Fail("Invalid Authorization Header");
        }

        var claims = new[] {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.UserRole.Name),
        };

        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}