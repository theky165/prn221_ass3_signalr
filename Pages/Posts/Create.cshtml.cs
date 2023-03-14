using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using SignalRAssignment.Models;
using SignalRAssignment.Hubs;

namespace SignalRAssignment.Pages.Posts
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
            ViewData["AuthorId"] = new SelectList(_context.AppUser, "UserId", "FullName");
            ViewData["CategoryId"] = new SelectList(_context.PostCategory, "CategoryId", "CategoryName");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Post.Add(Post);
            await _context.SaveChangesAsync();
            await _signalRHub.Clients.All.SendAsync("LoadPosts");
            return RedirectToPage("./Index");
        }
    }
}