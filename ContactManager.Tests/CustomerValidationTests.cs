using ContactManager.Models;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Tests
{
    public class CustomerValidationTests
    {
        private List<ValidationResult> ValidateModel(Customers customers)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(customers, serviceProvider: null, items: null);
            Validator.TryValidateObject(customers, context, results, true);
            return results;
        }
        [Fact]
        public void Should_Fail_When_Name_Is_Empty()
        {
            var customer = new Customers
            {
                Name = "",
                Contact = "123456789",
                EmailAddress = "user@example.com"
            };

            var result = ValidateModel(customer);
            Assert.Contains(result, r => r.MemberNames.Contains("Name"));
        }

        [Fact]
        public void Should_Fail_When_Name_Is_Too_Short()
        {
            var customer = new Customers
            {
                Name = "Ana",
                Contact = "123456789",
                EmailAddress = "user@example.com"
            };
            var result = ValidateModel(customer);
            Assert.Contains(result, r => r.MemberNames.Contains("Name"));
        }

        [Fact]
        public void Should_Fail_When_ContactNumber_Is_Invalid()
        {
            var customer = new Customers
            {
                Name = "Nome Válido",
                Contact = "123", // inválido
                EmailAddress = "user@example.com"
            };
            var results = ValidateModel(customer);
            Assert.Contains(results, r => r.MemberNames.Contains("Contact"));
        }

        [Fact]
        public void Should_Fail_When_Email_Is_Invalid()
        {
            var customer = new Customers
            {
                Name = "Nome Válido",
                Contact = "123456789",
                EmailAddress = "invalid-email"
            };

            var results = ValidateModel(customer);
            Assert.Contains(results, r => r.MemberNames.Contains("EmailAddress"));
        }

        [Fact]
        public void Should_Pass_When_All_Fields_Are_Valid()
        {
            var customer = new Customers
            {
                Name = "Cliente Completo",
                Contact = "987654321",
                EmailAddress = "valido@example.com"
            };

            var results = ValidateModel(customer);
            Assert.Empty(results);
        }
    }
}