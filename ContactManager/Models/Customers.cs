using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Customers
    {
        public int Id { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "O nome deve ter pelo menos 6 caracteres.")]
        public string Name { get; set; }
        //[Required]
        //[RegularExpression(@"^\d{9}", ErrorMessage ="O número de contato deve conter exatamente 9 digítos.")]
        //public string Contact { get; set; }
        //[Required]
        //[EmailAddress(ErrorMessage ="E-mail inválido.")]
        //public string EmailAddress { get; set; }
        //public bool isDeleted { get; set; } = false;
    }
}
