using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContactManager.Models;
using ContactManager.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Customers> Customers { get; set; } = new();
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        ///// <summary>
        ///// Return all undeleted contacts
        ///// </summary>
        ///// <returns>List of undeleted contacts</returns>
        //public async Task OnGetAsync()
        //{
        //    Customers = await _context.Customers.Where(c => !c.isDeleted)
        //        .OrderBy(c => c.Name)
        //        .ToListAsync();
        //}

        ///// <summary>
        ///// Soft Delete
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IActionResult> OnDeleteAsync(int id)
        //{
        //    var contact = await _context.Customers.FindAsync(id);
        //    if(contact != null)
        //    {
        //        contact.isDeleted = true;
        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToPage();
        //}
    }
}
