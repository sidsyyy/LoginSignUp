namespace LoginSignup.Data.Entity
{
    public class User//table in the databse.
    {
        //below are the column names.
            public int Id { get; set; }
            public required string Username { get; set; }
            public required string Email { get; set; }
            public required string PasswordHash { get; set; }
        }

}
