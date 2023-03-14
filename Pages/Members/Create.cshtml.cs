using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using SignalRAssignment.Hubs;
using SignalRAssignment.Models;

namespace SignalRAssignment.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly SignalRAssignment.Models.SchoolContextDBContext _context;
        private readonly IHubContext<SignalRServer> _signalRHub;

        public CreateModel(SignalRAssignment.Models.SchoolContextDBContext context, IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;
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
            await _signalRHub.Clients.All.SendAsync("LoadMembers");

            return RedirectToPage("./Index");
        }
    }
}
