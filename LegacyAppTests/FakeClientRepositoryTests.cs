using LegacyApp;

namespace LegacyAppTests;

public class FakeClientRepositoryTests
{
    [Fact]
    public void FakeClientRepository_Should_Return_Test_Client_Given_TestClientId()
    {
        //Arrange
        var repository = new FakeClientRepository();
        var testClient = FakeClientRepository.TEST_CLIENT;
        var clientId = FakeClientRepository.TEST_CLIENT_ID;
        
        //Act
        var result = repository.GetById(clientId);

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

    [Fact]
    public void FakeClientRepository_Should_Return_ImportantClient_Given_ImportantClientId()
    {
        //Arrange
        var repository = new FakeClientRepository();
        var expected = ClientType.ImportantClient.ToString();
        var clientId = FakeClientRepository.IMPORTANT_CLIENT_ID;
        
        //Act
        var result = repository.GetById(clientId).Type;
        
        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FakeClientRepository_Should_Return_VeryImportantClient_Given_VeryImportantClientId()
    {
        //Arrange
        var repository = new FakeClientRepository();
        var expected = ClientType.VeryImportantClient.ToString();
        var clientId = FakeClientRepository.VERY_IMPORTANT_CLIENT_ID;
        
        //Act
        var result = repository.GetById(clientId).Type;
        
        //Assert
        Assert.Equal(expected, result);
    }

}