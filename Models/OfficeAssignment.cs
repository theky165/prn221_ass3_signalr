using System;
using System.Collections.Generic;

namespace SignalRAssignment.Models
{
    public partial class OfficeAssignment
    {
        public int InstructorId { get; set; }
        public string Location { get; set; } = null!;

        public virtual Instructor Instructor { get; set; } = null!;
    }
}
