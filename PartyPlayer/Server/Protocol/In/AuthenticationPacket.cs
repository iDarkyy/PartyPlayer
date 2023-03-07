namespace PartyPlayer.Server.Protocol.In;

public class AuthenticationPacket : IPacket
{
    public string NewName { get; set; }
}