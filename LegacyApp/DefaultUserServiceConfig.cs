namespace LegacyApp;

public class DefaultUserServiceConfig : IUserServiceConfig
{
    public IUserValidator UserValidator()
    {
        return new UserValidator();
    }

    public IClientRepository ClientRepository()
    {
        return new ClientRepository();
    }

    public IClientMapper ClientMapper()
    {
        return new ClientMapper();
    }

    public IUserCreditService UserCreditService()
    {
        return new UserCreditService();
    }

    public IUserDataAccessAdapter UserDataAccessAdapter()
    {
        return new UserDataAccessAdapter();
    }
}