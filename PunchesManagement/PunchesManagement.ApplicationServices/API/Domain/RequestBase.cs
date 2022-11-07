namespace PunchesManagement.ApplicationServices.API.Domain;

public class RequestBase
{
    public int AuthenticationIdentifier { get; set; }
    public string ?AuthenticationUserName { get; set; }
    public string ?AuthenticationRole { get; set; }
}
