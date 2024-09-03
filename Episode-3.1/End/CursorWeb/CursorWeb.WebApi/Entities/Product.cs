using System;
using CursorWeb.WebApi.Enums;

namespace CursorWeb.WebApi.Entities;

public class Product : EntityBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public ProductStatusEnum Status { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }
}