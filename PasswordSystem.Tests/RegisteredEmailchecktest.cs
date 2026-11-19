namespace PasswordSystem.Tests;

public class EmailIsRegistered
{
    [Fact]
    public void CheckIfEmailISTaken()
    {
        var expected = false;
        FakeUserRepository f = new();
        var actual = f.EmailIsRegistered("a@.se");
        Assert.Equal(expected, actual);
    }
}