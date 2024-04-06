namespace LegacyApp;

public class FakeUserServiceConfig : IUserServiceConfig
{
    private IUserValidator _userValidator;
    private IClientRepository _clientRepository;
    private IClientMapper _clientMapper;
    private IUserCreditService _userCreditService;
    private IUserDataAccessAdapter _userDataAccessAdapter;

    public FakeUserServiceConfig() : this(new FakeUserValidator(), new FakeClientRepository(), new ClientMapper(), new FakeUserCreditService(), new FakeUserDataAccessAdapter())
    {
    }

    public FakeUserServiceConfig(IUserValidator userValidator, IClientRepository clientRepository, IClientMapper clientMapper, IUserCreditService userCreditService, IUserDataAccessAdapter userDataAccessAdapter)
    {
        _userValidator = userValidator;
        _clientRepository = clientRepository;
        _clientMapper = clientMapper;
        _userCreditService = userCreditService;
        _userDataAccessAdapter = userDataAccessAdapter;
    }

    public IUserValidator UserValidator()
    {
        return _userValidator;
    }

    public IClientRepository ClientRepository()
    {
        return _clientRepository;
    }

    public IClientMapper ClientMapper()
    {
        return _clientMapper;
    }

    public IUserCreditService UserCreditService()
    {
        return _userCreditService;
    }

    public IUserDataAccessAdapter UserDataAccessAdapter()
    {
        return _userDataAccessAdapter;
    }

    public void SetUserValidator(IUserValidator userValidator)
    {
        this._userValidator = userValidator;
    }

    public void SetUserCreditService(IUserCreditService userCreditService)
    {
        this._userCreditService = userCreditService;
    }
    
    
}