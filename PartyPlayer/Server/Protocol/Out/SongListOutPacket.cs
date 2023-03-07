using System.Collections.Generic;

namespace PartyPlayer.Server.Protocol.Out;

public class SongListOutPacket
{
    public List<string> Songs { get; set; }
}