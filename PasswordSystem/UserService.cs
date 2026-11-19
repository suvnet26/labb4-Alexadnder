namespace PasswordSystem;

public class UserService(IUserRepository userRepository)
{
    public bool EmailIsRegistered(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return false;
        }

        var cleanEmail = email.Trim().ToLowerInvariant();
        return userRepository.EmailIsRegistered(cleanEmail);
    }
}
