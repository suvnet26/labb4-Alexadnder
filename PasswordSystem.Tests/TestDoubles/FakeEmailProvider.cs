namespace PasswordSystem.Tests;

public record SentEmail(string To, string Subject, string Body);

public class FakeEmailProvider : IEmailProvider
{
    public List<SentEmail> SentEmails { get; } = [];

    public void SendEmail(string to, string subject, string body)
    {
        SentEmails.Add(new SentEmail(to, subject, body));
    }
}
