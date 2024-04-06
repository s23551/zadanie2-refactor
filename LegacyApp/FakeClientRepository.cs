using System;

namespace LegacyApp;

public class FakeClientRepository : IClientRepository
{
    public static Client TEST_CLIENT = new Client()
    {
        Name = "Test",
        Address = "Test",
        ClientId = 801,
        Email = "Test@Test.pl",
        Type = "TestClient"
    };

    public static Client NORMAL_CLIENT = new Client()
    {
        Name = "Aron",
        Address = "Brok",
        ClientId = 802,
        Email = "Czarny@Dym.es",
        Type = "NormalClient"
    };

    public static Client IMPORTANT_CLIENT = new Client()
    {
        Name = "Felicjan",
        Address = "Głuchołazy",
        ClientId = 803,
        Email = "Hak@Inaczej.jp",
        Type = "ImportantClient"
    };

    public static Client VERY_IMPORTANT_CLIENT = new Client()
    {
        Name = "Katarzyna",
        Address = "Lublin",
        ClientId = 804,
        Email = "mala@natemat.org",
        Type = "VeryImportantClient"
    };

    public static Client UNKNOWN_CLIENT = new Client()
    {
        Name = "Hilary",
        Address = "Hrebenne",
        ClientId = 0,
        Email = "hhrabio@hoga.hu",
        Type = "Unknown"
    };
    
    public Client GetById(int id)
    {
        if (id == -1)
        {
            throw new ArgumentException("No such client in FakeDatabase.");
        }
        return TEST_CLIENT;
    }
}