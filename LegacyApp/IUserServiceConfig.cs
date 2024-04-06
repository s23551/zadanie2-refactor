namespace LegacyApp;

public interface IUserServiceConfig
{
    IUserValidator UserValidator();
    IClientRepository ClientRepository();
    IClientMapper ClientMapper();
    IUserCreditService UserCreditService();
    IUserDataAccessAdapter UserDataAccessAdapter();

}