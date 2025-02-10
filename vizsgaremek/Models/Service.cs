using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vizsgaremek.Models;

public partial class Service
{
    public int ServiceId { get; set; }

    [JsonIgnore]
    public int UserId { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal? TimeCost { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public DateTime CreatedAt { get; set; }
    [JsonIgnore]
    public virtual ICollection<Request>? Requests { get; set; } = new List<Request>();
    [JsonIgnore]
    public virtual ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();
    [JsonIgnore]
    public virtual ICollection<UserService>? UserServices { get; set; } = new List<UserService>();
}
