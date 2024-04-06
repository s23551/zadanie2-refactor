using LegacyApp;

namespace LegacyAppTests;

public class FakeUserCreditServiceTests
{
    [Fact]
    public void FakeUserCreditService_Should_Return_0_Given_UserName_OPTION_ZERO()
    {
        //Arrange
        var service = new FakeUserCreditService();
        var expected = 0;
        var input = FakeUserCreditService.OPTION_ZERO;

        //Act
        var result = service.GetCreditLimit(input, new DateTime(2010, 1, 1));

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FakeUserCreditService_Should_Return_1000_Given_UserName_Other_Than_OPTION_DEFAULT()
    {
        //Arrange
        var service = new FakeUserCreditService();
        var expected = 1000;
        var input = "Kowalski";
        
        //Act
        var result = service.GetCreditLimit("Kowalski", new DateTime(1990, 1, 1));
        
        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FakeUserCreditService_Should_Throw_ArgumentException_Given_LastName_OPTION_NULL()
    {
        //Arrange
        var service = new FakeUserCreditService();
        var input = FakeUserCreditService.OPTION_NULL;
        var date = new DateTime(1990, 1, 1);
        
        //Act and Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _ = service.GetCreditLimit(input, date);
        });
    }
}