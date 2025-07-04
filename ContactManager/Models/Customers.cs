﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Models
{
    public class Customers
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is mandatory")]
        [MinLength(6, ErrorMessage = "The name needs to have 6 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Contact number is mandatory")]
        [RegularExpression(@"^\d{9}", ErrorMessage = "The contact number shoud be 9 digits")]
        public string Contact { get; set; }

        [Required(ErrorMessage = "E-mail is mandatory")]
        [EmailAddress(ErrorMessage = "Invalid e-mail")]
        public string EmailAddress { get; set; }
        public bool isDeleted { get; set; } = false;
    }
}
