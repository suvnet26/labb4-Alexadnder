namespace PasswordSystem.Tests;

public class UserRepository(IUserRepository emailIsRegistered, IUserRepository addUser)
{
    private readonly IUserRepository _EmailIsRegistered = emailIsRegistered;
    private readonly IUserRepository _Adduser = addUser;
    string[] userEmail = ["a@mail.se", "b@mail.se", "c@mail.se", "d@mail.se", "e@mail.se", "f@mail.se", "g@mail.se", "h@mail.se", "i@mail.se"];

    private bool EmailIsRegistered(string email)
    {
        if (userEmail.Contains(email))
        {
            return true;
        }

        return false;

    }
    private static void AddUser(string email, string password)
    {

    }


}