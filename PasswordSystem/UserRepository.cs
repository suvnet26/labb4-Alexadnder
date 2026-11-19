namespace PasswordSystem;

public class UserRepository : IUserRepository
{
    private readonly List<string> _userEmails = ["a@mail.se", "b@mail.se", "c@mail.se", "d@mail.se", "e@mail.se", "f@mail.se", "g@mail.se", "h@mail.se", "i@mail.se"];

    public bool EmailIsRegistered(string email)
    {
        return _userEmails.Contains(email);
    }

    public void AddUser(string email, string password)
    {
        if (EmailIsRegistered(email))
        {
            throw new Exception("Email already exists");
        }
        _userEmails.Add(email);
    }
}