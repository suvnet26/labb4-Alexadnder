namespace PasswordSystem.Tests;

public class UserServiceTests
{
    [Fact]
    public void EmailIsRegistered_WhenEmailDoesNotExist_ReturnsFalse()
    {
        // Arrange
        var fakeRepo = new FakeUserRepository();
        var sut = new UserService(fakeRepo); // "sut" stands for System Under Test
        var emailToCheck = "test@example.com";

        // Act
        var result = sut.EmailIsRegistered(emailToCheck);

        // Assert
        Assert.False(result);
    }
}