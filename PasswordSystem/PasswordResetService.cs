namespace PasswordSystem;

public class PasswordResetService(IEmailProvider emailProvider, ITokenGenerator tokenGenerator, IUserRepository userRepository)
{
    private readonly IEmailProvider _emailProvider = emailProvider;
    private readonly ITokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public void SendResetEmail(string email)
    {
        string subject = "Password Reset Requested";
        string token = _tokenGenerator.Generate();
        string body = CreateEmailBody(token);
        bool isEmailRegistered = _userRepository.EmailIsRegistered(email);
        if (isEmailRegistered)
        {
            throw new Exception("Email is already used");
        }
        _emailProvider.SendEmail(email, subject, body);
    }

    private string CreateEmailBody(string token)
    {
        string link = $"https://example.com/reset?token={token}";
        return $"Click the following link to reset your password: {link}";
    }
}