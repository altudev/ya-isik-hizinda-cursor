using System;
using System.Collections.Generic;

namespace CursorWeb.WebApi.Entities;

public class Category : EntityBase
{
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}