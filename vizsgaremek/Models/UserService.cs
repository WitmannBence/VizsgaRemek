using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace vizsgaremek.Models;

public partial class UserService
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int ServiceId { get; set; }

    [JsonIgnore]
    public virtual Service Service { get; set; } = null!;
    [JsonIgnore]
    public virtual User User { get; set; } = null!;
}
