namespace PartyPlayer.Server.Protocol.In;

public class SongRequestPacket : IPacket
{
    public string Location { get; set; }
}