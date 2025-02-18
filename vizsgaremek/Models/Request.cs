using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vizsgaremek.Models;

public partial class Request
{
    public int RequestId { get; set; }

    public int RequesterId { get; set; }

    public int ServiceId { get; set; }

    public string? Status { get; set; }

    public DateTime RequestedAt { get; set; }
    [JsonIgnore]
    public virtual User Requester { get; set; } = null!;
    [JsonIgnore]
    public virtual Service Service { get; set; } = null!;
}
