namespace PasswordSystem.Tests;

public class FakeUserRepository : IUserRepository
{
    List<string> userEmail = ["fakemail@.se"];

    public bool EmailIsRegistered(string email)
    {
        if (userEmail.Contains(email))
        {
            return true;
        }

        return false;

    }
    public void AddUser(string email, string password)
    {
        if (EmailIsRegistered(email))
        {
            throw new Exception("Email already exists");
        }
        userEmail.Add(email);
    }


}

