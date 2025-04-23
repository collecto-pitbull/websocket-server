using System;
using System.Collections.Generic;

namespace CollectoWebSockets.Models;

public partial class Wallet
{
    public Guid Id { get; set; }

    public decimal Balance { get; set; }

    public string Name { get; set; } = null!;

    public string Link { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Contribution> Contributions { get; set; } = new List<Contribution>();
}
