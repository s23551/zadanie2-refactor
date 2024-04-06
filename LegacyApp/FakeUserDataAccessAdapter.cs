namespace LegacyApp;

public class FakeUserDataAccessAdapter : IUserDataAccessAdapter
{
    public bool AddUser(User user)
    {
        if (user == null)
        {
            return false;
        }
        return true;
    }
}