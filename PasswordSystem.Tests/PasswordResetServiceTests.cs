namespace PasswordSystem.Tests;

public class PasswordResetServiceTests
{
    [Fact]
    public void SendResetEmail_SendsTokenToCorrectEmail()
    {
        // Arrange
        var fakeEmailProvider = new FakeEmailProvider();
        var fakeTokenGenerator = new FakeTokenGenerator();
        var sut = new PasswordResetService(fakeEmailProvider, fakeTokenGenerator);
        var testEmail = "test@test.com";

        // Act
        sut.SendResetEmail(testEmail);

        // Assert
        var sentEmail = Assert.Single(fakeEmailProvider.SentEmails);
        Assert.Equal(testEmail, sentEmail.To);
        Assert.Contains(fakeTokenGenerator.Token, sentEmail.Body);
    }
}
