using LegacyApp;

namespace LegacyAppTests;

public class FakeUserValidatorTests
{
    [Fact]
    public void FakeUserValidator_Should_Return_True()
    {
        //Arrange
        var validator = new FakeUserValidator();
        
        //Act
        var result = validator.Validate(null, null, null, DateTime.Now, -1);
        
        //Assert
        Assert.True(result);
    }
}