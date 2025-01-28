using System;
using System.Collections.Generic;

namespace vizsgaremek.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    public int UserId { get; set; }

    public string ServiceName { get; set; } = null!;

    public string? Description { get; set; }

    public string? Category { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}
