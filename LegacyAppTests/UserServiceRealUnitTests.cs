using LegacyApp;

namespace LegacyAppTests;

public class UserServiceRealUnitTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Missing_FirstName()
    {
        //Arrange
        var config = new FakeUserServiceConfig();
        var realValidator = new UserValidator();
        config.SetUserValidator(realValidator);
        var service = new UserService(config);

        //Act
        var result = service.AddUser(null, null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Missing_At_Sign_And_Dot_In_Email()
    {
        //Arrange
        var config = new FakeUserServiceConfig();
        var realValidator = new UserValidator();
        config.SetUserValidator(realValidator);
        var service = new UserService(config);

        //Act
        var result = service.AddUser("John", "Doe", "kowalskiwppl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Younger_Then_21_Years_Old()
    {
        //Arrange
        var config = new FakeUserServiceConfig();
        var realValidator = new UserValidator();
        config.SetUserValidator(realValidator);
        var service = new UserService(config);

        //Act
        var result = service.AddUser("John", "Doe", "kowalski@wp.pl", new DateTime(2010, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Very_Important_Client()
    {
        //Arrange
        var config = new FakeUserServiceConfig();
        var service = new UserService(config);
        var clientId = FakeClientRepository.VERY_IMPORTANT_CLIENT_ID;

        //Act
        var result = service.AddUser("John", "Malewski", "kowalski@wp.pl", new DateTime(1980, 1, 1), clientId);

        //Assert
        Assert.Equal(true, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Important_Client()
    {
        //Arrange
        var config = new FakeUserServiceConfig();
        var service = new UserService(config);
        var clientId = FakeClientRepository.IMPORTANT_CLIENT_ID;

        //Act
        var result = service.AddUser("John", "Smith", "smith@gmail.pl", new DateTime(1980, 1, 1), clientId);

        //Assert
        Assert.Equal(true, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Normal_Client()
    {
        //Arrange
        var config = new FakeUserServiceConfig();
        var service = new UserService(config);
        var clientId = FakeClientRepository.NORMAL_CLIENT_ID;

        //Act
        var result = service.AddUser("John", "Kwiatkowski", "kwiatkowski@wp.pl", new DateTime(1980, 1, 1), clientId);

        //Assert
        Assert.Equal(true, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Normal_Client_With_No_Credit_Limit()
    {
        //Arrange
        var config = new FakeUserServiceConfig();
        config.SetUserCreditService(new FakeUserCreditService(true));
        var service = new UserService(config);
        var clientId = FakeClientRepository.NORMAL_CLIENT_ID;

        //Act
        var result = service.AddUser("John", "Kowalski", "kowalski@wp.pl", new DateTime(1980, 1, 1), clientId);

        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Throw_Exception_When_User_Does_Not_Exist()
    {
        //Arrange
        var config = new FakeUserServiceConfig();
        var service = new UserService(config);
        var clientId = FakeClientRepository.USER_NOT_EXISTS_ID;

        //Act and Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _ = service.AddUser("John", "Unknown", "kowalski@wp.pl", new DateTime(1980, 1, 1), clientId);
        });
    }
    
    [Fact]
    public void AddUser_Should_Throw_Exception_When_User_No_Credit_Limit_Exists_For_User()
    {
        //Arrange
        var config = new FakeUserServiceConfig();
        var service = new UserService(config);
        var clientName = FakeUserCreditService.OPTION_NULL;

        //Act and Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _ = service.AddUser("John", clientName, "andrzejewicz@wp.pl", new DateTime(1980, 1, 1), 1);
        });
    }
}