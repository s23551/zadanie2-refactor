using System;

namespace LegacyApp;

public class ClientMapper : IClientMapper
{
    public ClientDao map(Client client)
    {
        ClientType parsedClientType;
        try
        {
            parsedClientType = Enum.Parse<ClientType>(client.Type);
        }
        catch (ArgumentException)
        {
            parsedClientType = ClientType.NormalClient;
        }
        
        return new ClientDao()
        {
            Name = client.Name,
            ClientId = client.ClientId,
            Email = client.Email,
            Address = client.Address,
            Type = parsedClientType
        };
    }
}