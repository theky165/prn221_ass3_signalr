using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly SignalRAssignment.Models.SchoolContextDBContext _context;

        public DetailsModel(SignalRAssignment.Models.SchoolContextDBContext context)
        {
            _context = context;
        }

      public AppUser AppUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AppUser == null)
            {
                return NotFound();
            }

            var appuser = await _context.AppUser.FirstOrDefaultAsync(m => m.UserId == id);
            if (appuser == null)
            {
                return NotFound();
            }
            else 
            {
                AppUser = appuser;
            }
            return Page();
        }
    }
}
