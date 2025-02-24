using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vizsgaremek.Models;

public partial class UserService
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ServiceId { get; set; }

    public virtual Service? Service { get; set; } = null!;
    [JsonIgnore]
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User? User { get; set; } = null!;
}
