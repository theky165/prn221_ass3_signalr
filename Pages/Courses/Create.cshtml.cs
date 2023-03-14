using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using SignalRAssignment.Hubs;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly SignalRAssignment.Models.SchoolContextDBContext _context;
        private readonly IHubContext<SignalRServer> _signalRHub;
        public CreateModel(SignalRAssignment.Models.SchoolContextDBContext context, IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub= signalRHub;
        }

        public IActionResult OnGet()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "Name");
            return Page();
        }

        [BindProperty]
        public Course Course { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Courses.Add(Course);
            await _context.SaveChangesAsync();
            await _signalRHub.Clients.All.SendAsync("LoadCourses");
            return RedirectToPage("./Index");
        }
    }
}