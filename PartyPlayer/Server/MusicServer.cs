using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PartyPlayer.Music;
using PartyPlayer.Server.Protocol;
using PartyPlayer.Server.Protocol.In;

namespace PartyPlayer.Server;

public class MusicServer
{
    private readonly MusicManager _musicManager;
    public readonly TcpListener _tcpListener;
    public readonly List<Client> Clients = new();
    public readonly Logger Logger = Logger.Create("MusicServer");

    public MusicServer(MusicManager musicManager, IPEndPoint endPoint)
    {
        _musicManager = musicManager;
        _tcpListener = new TcpListener(endPoint);
        _tcpListener.Start();
        
        Logger.Info("Listening at " + endPoint.Address + ":" + endPoint.Port);
        
        AwaitClients();

    }

    private async void AwaitClients()
    {
        while (true)
        {
            var tcpClient = await _tcpListener.AcceptTcpClientAsync();
            var client = new Client(this, tcpClient);
            Clients.Add(client);

            client.Logger.Info("/connected");
        }
    }

    public class Client : IDisposable
    {
        public readonly MusicServer MusicServer;
        public readonly TcpClient TcpClient;
        public readonly Logger Logger;
        private readonly NetworkStream NetworkStream;
        private readonly PacketProtocol PacketProtocol;
        private static readonly Dictionary<string, Type> Packets = new()
        {
            {"Authentication", typeof(AuthenticationPacket)},
            {"SongRequest", typeof(SongRequestPacket)},
            {"SongList", typeof(SongListPacket)},
            //{"Resume", ServerCommands.Resume},
            //{"Pause", ServerCommands.Pause},
            //{"RequestElevation", ServerCommands.RequestElevation},
            //{"SongInfo", ServerCommands.SongInfo},
            //{"Seek", ServerCommands.Seek},
            //{"ChangeVolume, ServerCommands.ChangeVolume}
        };

        private readonly Dictionary<Type, Action<IPacket>> Actions;
        
        public Client(MusicServer musicServer, TcpClient tcpClient)
        {
            MusicServer = musicServer;
            TcpClient = tcpClient;
            Logger = Logger.Create("TcpClient " + tcpClient.Client.RemoteEndPoint + " as unidentified");
            NetworkStream = tcpClient.GetStream();
            PacketProtocol = new PacketProtocol(int.MaxValue) { MessageArrived = DataReceived};
            
            // actions
            Actions = new()
            {
                {typeof(AuthenticationPacket), AuthenticatePacketReceived},
                {typeof(SongRequestPacket), SongRequestPacketReceived},
                {typeof(SongListPacket), SongListPacketReceived}
            };
            
            Loop();
        }

        public void Dispose()
        {
            TcpClient?.Dispose();
        }

        private async void Loop()
        {
            while (true)
            {
                try
                {
                    var buffer = new byte[64];
                    var receivedBytes = await NetworkStream.ReadAsync(buffer, 0, buffer.Length);

                    if (receivedBytes == 0) continue;

                    Array.Resize(ref buffer, receivedBytes);
                    PacketProtocol.DataReceived(buffer);
                    Logger.Debug("Received " + receivedBytes + " bytes of data");
                }
                catch (IOException)
                {
                    break;
                }
            }
            
            HandleDisconnect();
        }

        private void DataReceived(byte[] data)
        {
            try
            {
                var rawData = Encoding.UTF8.GetString(data);
                int lastIndex;
                if (!rawData.StartsWith("<") || (lastIndex = rawData.IndexOf('>')) == -1)
                {
                    WriteError("Packet", "Invalid protocol");
                    return;
                }

                var prefix = rawData.Substring(1, lastIndex - 1);

                Logger.Debug(prefix);
                
                if (!Packets.ContainsKey(prefix))
                {
                    WriteError("Packet", "Invalid packet");
                    return;
                }

                var packetType = Packets[prefix];
                var rawJson = rawData.Substring(lastIndex + 1).Trim();
                
                Logger.Info(rawJson);
                var json = JsonConvert.DeserializeObject(rawJson, packetType);
                Actions[packetType].Invoke((IPacket) json);
            }
            catch (Exception e)
            {
                WriteError("Packet", "Invalid message");
                Logger.Error("err", e);
            }
        }

        private void AuthenticatePacketReceived(IPacket rawPacket)
        {
            var packet = (AuthenticationPacket)rawPacket;
            
            Logger.Debug("Auth request: " + packet.NewName);
        }

        private void SongRequestPacketReceived(IPacket rawPacket)
        {
            var packet = (SongRequestPacket)rawPacket;
            Logger.Debug("Song request: " + packet.Location);
        }
        
        private void SongListPacketReceived(IPacket rawPacket)
        {
            Logger.Debug("SongList packet received");


            var songListJson = MusicServer._musicManager.SongSources.ToJsonString();
            Logger.Debug("<SongList>{\"Songs\":[" + songListJson.Replace("\\", "\\\\") + "}]}");
            WriteAsync("<SongList>{\"Songs\":[" + songListJson.Replace("\\", "\\\\") + "}]}");
        }
        
        public async void WriteAsync(string message)
        {
            var buffer = PacketProtocol.WrapMessage(Encoding.UTF8.GetBytes(message));
            await NetworkStream.WriteAsync(buffer, 0, buffer.Length);
        }

        private void WriteError(string cause, string friendlyMessage)
        {
            WriteAsync("<Error>\\{\"Cause:\"" + cause + "\",\"FriendlyMessage\":\"" + friendlyMessage + "\"}");
        }

        private void HandleDisconnect()
        {
            TcpClient.Close();
            Logger.Info("/disconnected");
        }

        public struct Information
        {
            public static string Name = string.Empty;

            public Information()
            {
            }
        }
    }
}