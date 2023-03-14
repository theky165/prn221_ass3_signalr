using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.Members
{
    public class DeleteModel : PageModel
    {
        private readonly SignalRAssignment.Models.SchoolContextDBContext _context;

        public DeleteModel(SignalRAssignment.Models.SchoolContextDBContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AppUser == null)
            {
                return NotFound();
            }
            var appuser = await _context.AppUser.FindAsync(id);

            if (appuser != null)
            {
                AppUser = appuser;
                _context.AppUser.Remove(AppUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
