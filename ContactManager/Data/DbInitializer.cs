using ContactManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Data
{
    public class DbInitializer 
    {
        public static void Initialize(ApplicationDbContext context) {
        
            if(context.Customers == null) return;

            var customers = new Customers[]
            {
                 new Customers
                {
                    Name = "João Silva",
                    Contact = "999999999",
                    EmailAddress = "joao@example.com"
                },
                new Customers
                {
                    Name = "Maria Oliveira",
                    Contact = "888888888",
                    EmailAddress = "maria@example.com"
                },
                new Customers
                {
                    Name = "Ana Costa",
                    Contact = "777777777",
                    EmailAddress = "ana@example.com"
                }
            };

            context.Customers.AddRange(customers);
            context.SaveChanges();
        }
    }
}
