using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.PunchesServices;

public class AddPunchesRequest : RequestBase, IRequest<AddPunchesResponse>
{
    public string Size { get; set; }
    public string Series { get; set; }

    public int ManufacturerId { get; set; }

    public int TypesId { get; set; }
}
