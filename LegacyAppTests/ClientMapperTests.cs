using LegacyApp;

namespace LegacyAppTests;

public class ClientMapperTests
{
    [Fact]
    public void ClientMapper_Should_Return_ClientDao_With_NormalClientType_Given_NormalClientType()
    {
        //Arrange
        var client = FakeClientRepository.NORMAL_CLIENT;
        var mapper = new ClientMapper();
        var expected = ClientType.NormalClient;
        
        //Act
        var result = mapper.map(client).Type;

        //Assert
        Assert.Equal(expected , result);
    }

    [Fact]
    public void ClientMapper_Should_Return_ClientDao_With_NormalClientType_Given_UnknownClientType()
    {
        //Arrange
        var client = FakeClientRepository.UNKNOWN_CLIENT;
        var mapper = new ClientMapper();
        var expected = ClientType.NormalClient;

        //Act
        var result = mapper.map(client).Type;

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ClientMapper_Should_Return_ClientDao_With_TestClientType_Given_TestClientType()
    {
        //Arrange
        var client = FakeClientRepository.TEST_CLIENT;
        var mapper = new ClientMapper();
        var expected = ClientType.TestClient;
        
        //Act
        var result = mapper.map(client).Type;

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ClientMapper_Should_Return_ClientDao_With_ImportantClientType_Given_ImportantClientType()
    {
        //Arrange
        var client = FakeClientRepository.IMPORTANT_CLIENT;
        var mapper = new ClientMapper();
        var expected = ClientType.ImportantClient;

        //Act
        var result = mapper.map(client).Type;

        //Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ClientMapper_Should_Return_ClientDao_With_VeryImportantClientType_Given_VeryImportantClientType()
    {
        //Arrange
        var client = FakeClientRepository.VERY_IMPORTANT_CLIENT;
        var mapper = new ClientMapper();
        var expected = ClientType.VeryImportantClient;
        
        //Act
        var result = mapper.map(client).Type;
        
        //Assert
        Assert.Equal(expected, result);
    }
}