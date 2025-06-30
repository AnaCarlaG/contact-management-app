using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Pages
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _context;

        [BindProperty]
        public Customers Customers { get; set; }

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customers = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id/* && !c.isDeleted*/);
            
            if(Customers == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> Edit()
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
