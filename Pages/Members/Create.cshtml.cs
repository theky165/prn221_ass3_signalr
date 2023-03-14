using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRRazorCrud00.Models;

namespace SignalRRazorCrud00.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly SignalRRazorCrud00.Models.SchoolContextDBContext _context;

        public CreateModel(SignalRRazorCrud00.Models.SchoolContextDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AppUser AppUser { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.AppUser.Add(AppUser);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
