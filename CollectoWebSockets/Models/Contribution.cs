using System;
using System.Collections.Generic;

namespace CollectoWebSockets.Models;

public partial class Contribution
{
    public Guid Id { get; set; }

    public Guid WalletId { get; set; }

    public decimal Balance { get; set; }

    public string UserName { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public virtual Wallet Wallet { get; set; } = null!;
}
