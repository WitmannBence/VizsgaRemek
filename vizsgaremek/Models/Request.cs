using System;
using System.Collections.Generic;

namespace vizsgaremek.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public int RequesterId { get; set; }

    public int ServiceId { get; set; }

    public string? Status { get; set; }

    public DateTime RequestedAt { get; set; }


    public virtual User Requester { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;
}
