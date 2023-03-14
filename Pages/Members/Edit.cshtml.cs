using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRRazorCrud00.Models;

namespace SignalRRazorCrud00.Pages.Members
{
    public class EditModel : PageModel
    {
        private readonly SignalRRazorCrud00.Models.SchoolContextDBContext _context;

        public EditModel(SignalRRazorCrud00.Models.SchoolContextDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AppUser AppUser { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AppUser == null)
            {
                return NotFound();
            }

            var appuser =  await _context.AppUser.FirstOrDefaultAsync(m => m.UserId == id);
            if (appuser == null)
            {
                return NotFound();
            }
            AppUser = appuser;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AppUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppUserExists(AppUser.UserId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AppUserExists(int id)
        {
          return _context.AppUser.Any(e => e.UserId == id);
        }
    }
}
