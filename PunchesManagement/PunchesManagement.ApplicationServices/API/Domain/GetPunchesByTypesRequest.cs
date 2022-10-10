using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain;

public class GetPunchesByTypesRequest : IRequest<GetPunchesByTypesResponse>
{
    public string SearchSize { get; set; }
}
