using System;

namespace LegacyApp
{
    public class UserService

    {

        private IUserValidator _userValidator;
        private IClientRepository _clientRepository;
        private IClientMapper _clientMapper;
        private IUserCreditService _userCreditService;
        private IUserDataAccessAdapter _userDataAccessAdapter;
        
        
        public UserService() : this(new DefaultUserServiceConfig())
        {
        }


        public UserService(IUserServiceConfig config)
        {
            this._userValidator = config.UserValidator();
            this._clientRepository = config.ClientRepository();
            this._clientMapper = config.ClientMapper();
            this._userCreditService = config.UserCreditService();
            this._userDataAccessAdapter = config.UserDataAccessAdapter();
        }
        
        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            var userValidated = _userValidator.Validate(firstName, lastName, email, dateOfBirth, clientId);

            if (!userValidated)
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);
            var clientDao = _clientMapper.map(client);
            
            var user = new User
            {
                Client = clientDao,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            if (clientDao.Type.Equals(ClientType.VeryImportantClient))
            {
                user.HasCreditLimit = false;
            }
            else
            {
                int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                if (clientDao.Type.Equals(ClientType.ImportantClient))
                {
                    creditLimit *= 2;
                }

                user.HasCreditLimit = true;
                user.CreditLimit = creditLimit;
            }
            
            if (user.HasCreditLimit && user.CreditLimit < 500)
            {
                return false;
            }

            _userDataAccessAdapter.AddUser(user);
            return true;
        }
    }
}
