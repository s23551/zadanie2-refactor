namespace LegacyApp;

public interface IClientMapper
{
    ClientDao map(Client client);
}