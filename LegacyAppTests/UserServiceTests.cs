using LegacyApp;

namespace LegacyAppTests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_Should_Return_False_When_Missing_FirstName_And_LastName()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser(null, null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Missing_FirstName()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser(null, "Nowak", "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Missing_LastName()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("Janina", null, "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Empty_FirstName_And_LastName()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("", "", "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Empty_FirstName()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("", "Nowak", "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Empty_LastName()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("Janina", "", "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }



    [Fact]
    public void AddUser_Should_Return_False_When_Missing_At_Sign_And_Dot_In_Email()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Doe", "kowalskiwppl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Missing_At_Sign_In_Email()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Doe", "kowalskiwp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Missing_Dot_In_Email()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Doe", "kowalski@wppl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Email_Is_Null()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Doe", null, new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Email_Is_Empty()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Doe", "", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }




    [Fact]
    public void AddUser_Should_Return_False_When_Younger_Than_21_Years_Old()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Doe", "kowalski@wp.pl", new DateTime(DateTime.Now.Year - 19, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_BirthDate_Is_In_Future()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Doe", "kowalski@wp.pl", DateTime.Now.AddDays(1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_User_Is_Older_Than_150_Years()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Doe", "kowalski@wp.pl", new DateTime(DateTime.Now.Year - 150, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Very_Important_Client()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Malewski", "kowalski@wp.pl", new DateTime(1980, 1, 1), 2);

        //Assert
        Assert.Equal(true, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Important_Client()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Smith", "smith@gmail.pl", new DateTime(1980, 1, 1), 3);

        //Assert
        Assert.Equal(true, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_True_When_Normal_Client()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Kwiatkowski", "kwiatkowski@wp.pl", new DateTime(1980, 1, 1), 5);

        //Assert
        Assert.Equal(true, result);
    }
    
    [Fact]
    public void AddUser_Should_Return_False_When_Normal_Client_With_No_Credit_Limit()
    {
        //Arrange
        var service = new UserService();

        //Act
        var result = service.AddUser("John", "Kowalski", "kowalski@wp.pl", new DateTime(1980, 1, 1), 1);

        //Assert
        Assert.Equal(false, result);
    }
    
    [Fact]
    public void AddUser_Should_Throw_Exception_When_User_Does_Not_Exist()
    {
        //Arrange
        var service = new UserService();

        //Act and Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _ = service.AddUser("John", "Unknown", "kowalski@wp.pl", new DateTime(1980, 1, 1), 100);
        });
    }
    
    [Fact]
    public void AddUser_Should_Throw_Exception_When_User_No_Credit_Limit_Exists_For_User()
    {
        //Arrange
        var service = new UserService();

        //Act and Assert
        Assert.Throws<ArgumentException>(() =>
        {
            _ = service.AddUser("John", "Andrzejewicz", "andrzejewicz@wp.pl", new DateTime(1980, 1, 1), 6);
        });
    }
}