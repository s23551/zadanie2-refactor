using LegacyApp;

namespace LegacyAppTests;

public class FakeClientRepositoryTests
{
    [Fact]
    public void FakeClientRepository_Should_Return_Test_Client_Given_Id_0()
    {
        //Arrange
        var repository = new FakeClientRepository();
        var testClient = FakeClientRepository.TEST_CLIENT;
        
        //Act
        var result = repository.GetById(0);

        //Assert
        Assert.Equal(result, testClient);
    }
    
    [Fact]
    public void FakeClientRepository_Should_Throw_Exception_When_User_Does_Not_Exist()
    {
        //Arrange
        var repository = new FakeClientRepository();

        //Act and Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _ = repository.GetById(-1);
        });
    }

}