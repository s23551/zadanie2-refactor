using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp
{
    internal class UserValidator : IUserValidator
    {
        public bool Validate(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
            {
                return false;
            }

            if (!email.Contains("@") && !email.Contains("."))
            {
                return false;
            }

            return true;
        }
    }
}
