﻿namespace PunchesManagement.DataAccess.Entities;

public class User : EntityBase
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordHash { get; set; }

    public int UserRoleId { get; set; }
    public virtual UserRole UserRole { get; set; }
}