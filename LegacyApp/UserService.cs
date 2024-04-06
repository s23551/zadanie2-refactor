using System;

namespace LegacyApp
{
    public class UserService
    {
        private IUserValidator _userValidator;
        private IClientRepository _clientRepository;
        private IClientMapper _clientMapper;
        private IUserCreditService _userCreditService;
        
        
        public UserService() : this(new UserValidator(), new ClientRepository(), new ClientMapper(), new UserCreditService())
        {
        }

        public UserService(IUserValidator userValidator, IClientRepository clientRepository, IClientMapper clientMapper, IUserCreditService userCreditService)
        {
            this._userValidator = userValidator;
            this._clientRepository = clientRepository;
            this._clientMapper = clientMapper;
            this._userCreditService = userCreditService;
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
                if (user.Client.GetType().Equals(ClientType.ImportantClient))
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

            UserDataAccess.AddUser(user);
            return true;
        }
    }
}
