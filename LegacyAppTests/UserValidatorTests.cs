using LegacyApp;

namespace LegacyAppTests;

public class UserValidatorTests
{
    [Fact]
    public void UserValidator_Should_Return_False_When_Missing_FirstName()
    {
        //Arrange
        var validator = new UserValidator();

        //Act
        var result = validator.Validate(null, null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void UserValidator_Should_Return_False_When_Missing_At_Sign_And_Dot_In_Email()
    {
        //Arrange
        var validator = new UserValidator();

        //Act
        var result = validator.Validate("John", "Doe", "kowalskiwppl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void UserValidator_Should_Return_False_When_Younger_Then_21_Years_Old()
    {
        //Arrange
        var validator = new UserValidator();

        //Act
        var result = validator.Validate("John", "Doe", "kowalski@wp.pl", new DateTime(2010, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    
}