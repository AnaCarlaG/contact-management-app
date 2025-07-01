using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Pages
{
    [Authorize]
    public class EditModel : PageModel
    {
        private ApplicationDbContext _context;

        [BindProperty]
        public Customers Customers { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get contact by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
                return NotFound();

            Customers = await _context.Customers.FindAsync(id);
            
            if(Customers == null) return NotFound();

            return Page();
        }
        
        /// <summary>
        /// Edit contact
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid) return Page();

            _context.Attach(Customers).State = EntityState.Modified;

            try{
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!_context.Customers.Any(e => e.Id == Customers.Id)) {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("Index");
        }
    }
}
