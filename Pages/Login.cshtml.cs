using LoginSignup.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LoginSignup.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AppDbContext _dbContext;

        public LoginModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public required LoginInputModel Input { get; set; }

        public string? ErrorMessage { get; set; } // For error feedback

        public class LoginInputModel
        {
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Invalid input. Please try again.";
                return Page();
            }

            // Fetch the user from the database using the provided email
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == Input.Email);

            if (user == null)
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }

            // Verify the provided password with the stored hash
            if (!BCrypt.Net.BCrypt.Verify(Input.Password, user.PasswordHash))
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }

            // Successful login logic here (e.g., set session, redirect)
            return RedirectToPage("/Welcome"); // Redirect to a welcome page after login
        }
    }
}
