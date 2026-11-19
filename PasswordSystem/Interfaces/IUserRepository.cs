namespace PasswordSystem;

public interface IUserRepository
{
    public bool EmailIsRegistered();
    public void AddUser(string email, string password);
}