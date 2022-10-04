using System.ComponentModel.DataAnnotations;

namespace PunchesManagement.DataAccess.Entities;

public abstract class EntityBase
{
    [Key]
    public int Id { get; set; }
}
