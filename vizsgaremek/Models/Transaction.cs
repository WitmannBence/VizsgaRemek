using System;
using System.Collections.Generic;

namespace vizsgaremek.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public int ServiceId { get; set; }

    public decimal TimeAmount { get; set; }

    public string? Description { get; set; }

    public DateTime TransactionDate { get; set; }

    public virtual User Receiver { get; set; } = null!;

    public virtual User Sender { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
