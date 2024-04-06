using System;

namespace LegacyApp;

public class FakeClientRepository : IClientRepository
{
    public const int TEST_CLIENT_ID = 801;
    public const int NORMAL_CLIENT_ID = 802;
    public const int IMPORTANT_CLIENT_ID = 803;
    public const int VERY_IMPORTANT_CLIENT_ID = 804;
    public const int UNKNOWN_CLIENT_ID = 0;
    public const int USER_NOT_EXISTS_ID = -1;
    public static Client TEST_CLIENT = new Client()
    {
        Name = "Test",
        Address = "Test",
        ClientId = TEST_CLIENT_ID,
        Email = "Test@Test.pl",
        Type = "TestClient"
    };

    public static Client NORMAL_CLIENT = new Client()
    {
        Name = "Aron",
        Address = "Brok",
        ClientId = NORMAL_CLIENT_ID,
        Email = "Czarny@Dym.es",
        Type = "NormalClient"
    };

    public static Client IMPORTANT_CLIENT = new Client()
    {
        Name = "Felicjan",
        Address = "Głuchołazy",
        ClientId = IMPORTANT_CLIENT_ID,
        Email = "Hak@Inaczej.jp",
        Type = "ImportantClient"
    };

    public static Client VERY_IMPORTANT_CLIENT = new Client()
    {
        Name = "Katarzyna",
        Address = "Lublin",
        ClientId = VERY_IMPORTANT_CLIENT_ID,
        Email = "mala@natemat.org",
        Type = "VeryImportantClient"
    };

    public static Client UNKNOWN_CLIENT = new Client()
    {
        Name = "Hilary",
        Address = "Hrebenne",
        ClientId = UNKNOWN_CLIENT_ID,
        Email = "hhrabio@hoga.hu",
        Type = "Unknown"
    };
    
    public Client GetById(int id)
    {
        if (id == USER_NOT_EXISTS_ID)
        {
            throw new ArgumentException("No such client in FakeDatabase.");
        }

        return id switch
        {
            TEST_CLIENT_ID => TEST_CLIENT,
            NORMAL_CLIENT_ID => NORMAL_CLIENT,
            IMPORTANT_CLIENT_ID => IMPORTANT_CLIENT,
            VERY_IMPORTANT_CLIENT_ID => VERY_IMPORTANT_CLIENT,
            _ => UNKNOWN_CLIENT
        };
    }
}