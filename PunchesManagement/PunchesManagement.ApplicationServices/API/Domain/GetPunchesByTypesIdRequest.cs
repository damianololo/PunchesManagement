using MediatR;

namespace PunchesManagement.ApplicationServices.API.Domain;

public class GetPunchesByTypesIdRequest : IRequest<GetPunchesByTypesIdResponse>
{
    public int TypesId { get; set; }
}
