using System;

namespace LegacyApp;

public class FakeUserValidator : IUserValidator
{
    public bool Validate(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
    {
        return true;
    }
}