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
    
    public Client GetById(int id)
    {
        return TEST_CLIENT;
    }
}