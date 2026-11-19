namespace PasswordSystem;

public interface IUserRepository
{
    bool EmailIsRegistered(string email);
    void AddUser(string email, string password);
}