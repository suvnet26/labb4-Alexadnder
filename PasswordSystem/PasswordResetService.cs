namespace PasswordSystem;

public class PasswordResetService(IEmailProvider emailProvider, ITokenGenerator tokenGenerator)
{
    private readonly IEmailProvider _emailProvider = emailProvider;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;

    public void SendResetEmail(string email)
    {
        string subject = "Password Reset Requested";
        string token = _tokenGenerator.Generate();
        string body = CreateEmailBody(token);
        _emailProvider.SendEmail(email, subject, body);
    }

    private string CreateEmailBody(string token)
    {
        string link = $"https://example.com/reset?token={token}";
        return $"Click the following link to reset your password: {link}";
    }
}