using LegacyApp;

namespace LegacyAppTests;

public class FakeUserDataAccessAdapterTests
{
    [Fact]
    public void FakeUserDataAccessAdapter_Should_Return_False_Given_Null()
    {
        //Arrange
        var adapter = new FakeUserDataAccessAdapter();
        
        //Act
        var result = adapter.AddUser(null);
        
        //Assert
        Assert.False(result);
    }

    [Fact]
    public void FakeUserDataAccessAdapter_Should_Return_True_Given_Any_User()
    {
        //Arrange
        var adapter = new FakeUserDataAccessAdapter();
        var user = new User();
        
        //Act
        var result = adapter.AddUser(user);
        
        //Assert
        Assert.True(result);
    }
}