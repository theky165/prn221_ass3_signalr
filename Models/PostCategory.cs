using System;
using System.Collections.Generic;

namespace SignalRAssignment.Models;

public partial class PostCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }
}
