using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;
using SignalRAssignment.Models.SchoolViewModels;

namespace SignalRAssignment.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly SignalRAssignment.Models.SchoolContextDBContext _context;

        public IndexModel(SignalRAssignment.Models.SchoolContextDBContext context)
        {
            _context = context;
        }

        public IList<CourseViewModel> CourseVM { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                CourseVM = await _context.Courses
                    .Select(p => new CourseViewModel
                    {
                        CourseId = p.CourseId,
                        Title = p.Title,
                        Credits = p.Credits,
                        DepartmentName = p.Department.Name
                    }).ToListAsync();
            }
        }
    }
}
