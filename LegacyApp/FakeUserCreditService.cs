using System;

namespace LegacyApp;

public class FakeUserCreditService : IUserCreditService
{
    public static string OPTION_ZERO = "ZERO";
    public static int CREDIT_DEFAULT = 1000;
    public static string OPTION_NULL = "null";
    
    public int GetCreditLimit(string lastName, DateTime dateOfBirth)
    {
        if (lastName.Equals(OPTION_NULL))
        {
            throw new ArgumentException("No user in database");
        }

        return lastName.Equals(OPTION_ZERO) ? 0 : 1000;
    }
}