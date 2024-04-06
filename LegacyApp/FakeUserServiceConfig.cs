namespace LegacyApp;

public class FakeUserServiceConfig : IUserServiceConfig
{
    public IUserValidator UserValidator()
    {
        return new FakeUserValidator();
    }

    public IClientRepository ClientRepository()
    {
        return new FakeClientRepository();
    }

    public IClientMapper ClientMapper()
    {
        return new ClientMapper();
    }

    public IUserCreditService UserCreditService()
    {
        return new FakeUserCreditService();
    }

    public IUserDataAccessAdapter UserDataAccessAdapter()
    {
        return new FakeUserDataAccessAdapter();
    }
}