using System;
using CursorWeb.WebApi.Enums;

namespace CursorWeb.WebApi.Entities;

public class Customer : EntityBase
{
    public CustomerType Type { get; set; }
    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string Country { get; set; }
    public string City { get; set; }

    public string State { get; set; }

    public string ZipCode { get; set; }
}
