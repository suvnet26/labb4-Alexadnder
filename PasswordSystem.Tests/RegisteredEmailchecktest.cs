namespace PasswordSystem.Tests;

public class UserServiceTests
{
    [Fact]
    public void EmailIsRegistered_WhenEmailDoesNotExist_ReturnsFalse()
    {
        // Arrange
        var fakeRepo = new FakeUserRepository();
        var sut = new UserService(fakeRepo);
        var emailToCheck = "fakemail@.se";

        // Act
        var result = sut.EmailIsRegistered(emailToCheck);

        // Assert
        Assert.True(result);
    }
}