using MediatR;
using Microsoft.EntityFrameworkCore;
using PunchesManagement.DataAccess.Entities;

namespace PunchesManagement.ApplicationServices.API.Domain;

public class AddPunchesRequest : IRequest<AddPunchesResponse>
{
    public string Size { get; set; }
    public string Series { get; set; }

    public int ManufacturerId { get; set; }

    public int TypesId { get; set; }
}
