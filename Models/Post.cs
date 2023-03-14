using System;
using System.Collections.Generic;

namespace SignalRAssignment.Models;

public partial class Post
{
    public int PostId { get; set; }

    public int? AuthorId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public int? PublishStatus { get; set; }

    public int? CategoryId { get; set; }
}
