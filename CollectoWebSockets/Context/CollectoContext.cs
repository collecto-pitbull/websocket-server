using System;
using System.Collections.Generic;
using CollectoWebSockets.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectoWebSockets.Context;

public partial class CollectoContext : DbContext
{
    public CollectoContext()
    {
    }

    public CollectoContext(DbContextOptions<CollectoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contribution> Contributions { get; set; }
}
