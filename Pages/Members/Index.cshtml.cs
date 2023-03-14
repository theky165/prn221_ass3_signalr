using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.Members
{
    public class IndexModel : PageModel
    {
        private readonly SignalRAssignment.Models.SchoolContextDBContext _context;

        public IndexModel(SignalRAssignment.Models.SchoolContextDBContext context)
        {
            _context = context;
        }

        public IList<AppUser> AppUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AppUser != null)
            {
                AppUser = await _context.AppUser.ToListAsync();
            }
        }
    }
}
