using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRRazorCrud00.Models;

namespace SignalRRazorCrud00.Pages.Posts
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string search { get; set; }
        private readonly SignalRRazorCrud00.Models.SchoolContextDBContext _context;

        public IndexModel(SignalRRazorCrud00.Models.SchoolContextDBContext context)
        {
            _context = context;
        }

        public IList<Post> Post { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Post != null)
            {
                Post = await _context.Post
                .Include(p => p.Auth)
                .Include(p => p.Category).ToListAsync();
            }
            if (!String.IsNullOrEmpty(search))
            {
                Post = Post.Where(p => p.Title.ToLower().Contains(search.ToLower()) ||
                p.PostId.ToString() == search)
                    .ToList();
            }
        }
    }
}
