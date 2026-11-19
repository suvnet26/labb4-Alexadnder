namespace PasswordSystem;

public interface IEmailProvider
{
    public void SendEmail(string to, string subject, string body);
}
