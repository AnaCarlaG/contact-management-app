using ContactManager.Data;
using ContactManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ContactManager.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Customers Customers { get; set; } = new();

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adiciona um novo contato
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Create()
        {
            if (!ModelState.IsValid) return Page();

            _context.Customers.Add(Customers);
            await _context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }
}
