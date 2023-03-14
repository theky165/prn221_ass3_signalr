using SignalRRazorCrud00.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SignalRAssignment.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int PublishStatus { get; set; }
        public int CategoryId { get; set; }

        public virtual AppUser Auth { get; set; }
        public virtual PostCategory Category { get; set; }
    }
}
