using LoginSignup.Data;
using LoginSignup.Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace LoginSignup.Pages
{
    public class SignUpModel(AppDbContext dbContext) : PageModel//constructor to use the database
    {
        private readonly AppDbContext _dbContext = dbContext;//accesing thr database tables

        [BindProperty]//merging the backend and frontend
        public required SignupInputModel Input { get; set; }//to take input from the user 

        public class SignupInputModel//accessing the Appdbcontext here
        {
            public required string Username { get; set; }
            public required string Email { get; set; }
            public required string Password { get; set; }
        }

        public void OnGet()//while searching hitting enter, the data wil be shown at search bar
        {
        }

        public IActionResult OnPost()//data submit, while hitting enter, the data will not be shown in the search bar.
        {
            if (ModelState.IsValid)
            {
                var user = new User//using LoginSignup.Data.Entity;
                {
                    Username = Input.Username,//username input
                    Email = Input.Email,//email input
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(Input.Password) // Hash the password
                };

                _dbContext.Users.Add(user);//Adding the user
                _dbContext.SaveChanges();//Saving the changes

                return RedirectToPage("/Login");//after the signup, the user is redirected to Login page.
            }
            return Page();//returning the same page i.e SignUp page
        }
    }
}
