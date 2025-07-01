using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ContactManager.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }
        public void OnGet() { }

        /// <summary>
        /// Sign in
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync() { 
            //if(Username == null || Password == null)
            //{
            //    return;
            //}
            if(Username == "admin" && Password == "12345")
            {
                var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, Username)
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Volta para a página originalmente requisitada
                var returnUrl = HttpContext.Request.Query["ReturnUrl"];

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    //return LocalRedirect(returnUrl); //Caso venha de página protegida
                    return RedirectToPage("/Create");
                }
                return RedirectToPage("/Index");
            }

            ErrorMessage = "Usuário ou senha inválidos";
            return Page();
        }
    }
}
