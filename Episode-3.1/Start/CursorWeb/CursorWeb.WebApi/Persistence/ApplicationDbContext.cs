using System;
using CursorWeb.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursorWeb.WebApi.Persistence;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Customer> Customers { get; set; }

}

