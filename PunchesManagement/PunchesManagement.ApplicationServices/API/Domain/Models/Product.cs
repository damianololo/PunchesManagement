using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.ApplicationServices.API.Domain.Models;

public class Product
{
    public int Id { get; set; }
    [MaxLength(50)]
    [Required]
    public string Name { get; set; }
    [MaxLength(20)]
    [Required]
    public string Series { get; set; }
    [MaxLength(1500)]
    public string Description { get; set; }
    [Precision(6, 2)]
    public decimal BatchSize { get; set; }
    [Precision(6, 2)]
    public decimal RealWorkingTime { get; set; }
    public string TabletPress { get; set; }
}
