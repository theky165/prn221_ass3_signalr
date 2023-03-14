using System;
using System.Collections.Generic;

namespace SignalRAssignment.Models;

public partial class AppUser
{
    public int UserId { get; set; }

    public string? Fullname { get; set; }

    public string? Address { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;
}
