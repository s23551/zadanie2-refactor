﻿namespace LegacyApp;

public class ClientDao
{
    public string Name { get; internal set; }
    public int ClientId { get; internal set; }
    public string Email { get; internal set; }
    public string Address { get; internal set; }
    public ClientType Type { get; set; }
}