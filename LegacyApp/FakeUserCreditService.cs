using System;

namespace LegacyApp;

public class FakeUserCreditService : IUserCreditService
{
    public const string OPTION_ZERO = "ZERO";
    public const int CREDIT_DEFAULT = 1000;
    public const string OPTION_NULL = "UserNull";
    public bool AlwaysZero;

    public FakeUserCreditService() : this(false)
    {
    }

    public FakeUserCreditService(bool alwaysZero)
    {
        AlwaysZero = alwaysZero;
    }

    public int GetCreditLimit(string lastName, DateTime dateOfBirth)
    {
        if (AlwaysZero)
        {
            return 0;
        }
        if (lastName.Equals(OPTION_NULL))
        {
            throw new ArgumentException("No user in database");
        }

        return lastName.Equals(OPTION_ZERO) ? 0 : 1000;
    }
}