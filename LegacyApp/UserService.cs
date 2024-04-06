using System;

namespace LegacyApp
{
    public class UserService
    {
        private IUserValidator _userValidator;
        private IClientRepository _clientRepository;
        private IClientMapper _clientMapper;
        
        
        public UserService() : this(new UserValidator(), new ClientRepository(), new ClientMapper())
        {
        }

        public UserService(IUserValidator userValidator, IClientRepository clientRepository, IClientMapper clientMapper)
        {
            this._userValidator = userValidator;
            this._clientRepository = clientRepository;
            this._clientMapper = clientMapper;
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
            
            if (client.Type == "VeryImportantClient")
            {
                user.HasCreditLimit = false;
            }
            else if (client.Type == "ImportantClient")
            {
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    creditLimit = creditLimit * 2;
                    user.CreditLimit = creditLimit;
                }
            }
            else
            {
                user.HasCreditLimit = true;
                using (var userCreditService = new UserCreditService())
                {
                    int creditLimit = userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
                    user.CreditLimit = creditLimit;
                }
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
