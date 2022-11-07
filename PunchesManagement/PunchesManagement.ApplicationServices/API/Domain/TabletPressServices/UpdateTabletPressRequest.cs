using MediatR;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.TabletPressServices;

public class UpdateTabletPressRequest : RequestBase, IRequest<UpdateTabletPressResponse>
{
    public int UpdateId { get; set; }
    public string Name { get; set; }
    public string Producer { get; set; }
    public int NumberOfStation { get; set; }
    public int TypesId { get; set; }
}
