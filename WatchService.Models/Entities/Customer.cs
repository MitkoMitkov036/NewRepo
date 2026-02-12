using System;
using System.Collections.Generic;
using System.Text;

namespace WatchService.Models.Entities;

public class Customer
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;
}
