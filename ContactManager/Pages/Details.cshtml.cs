using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace ContactManager.Pages
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private ApplicationDbContext _context;
        public Customers Customers { get; set; }

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customers = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id /*&& !c.isDeleted*/);

            if (Customers == null)
                return NotFound();

            return Page();
        }
    }
}
