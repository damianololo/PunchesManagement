using PunchesManagement.ApplicationServices.API.ErrorHandling;

namespace PunchesManagement.ApplicationServices.API.Domain;

public class ResponseBase<T> : ErrorResponseBase
{
    public T Data { get; set; }
}
