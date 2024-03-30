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
            if (CheckNullOrEmpty(firstName) || CheckNullOrEmpty(lastName) || CheckNullOrEmpty(email) 
                || CheckNull(dateOfBirth) || CheckNull(clientId))
            {
                return false;
            }

            if (!CheckEmail(email))
            {
                return false;
            }

            return true;
        }

        private bool CheckNull(Object? obj)
        {
            return obj == null;
        }

        private bool CheckNullOrEmpty(String? str)
        {
            return string.IsNullOrEmpty(str);
        }

        private bool CheckEmail(String email)
        {
            return email.Contains("@") && email.Contains(".");
        }
    }
}
