namespace LegacyApp;

public class UserDataAccessAdapter : IUserDataAccessAdapter
{
    
    public bool AddUser(User user)
    {
        UserDataAccess.AddUser(user);
        return true;
    }
}