﻿namespace Multiplayer;

public class CPacketPlayerPosition : ClientPacket
{
    public Vector2 Position { get; set; }

    public override void Write(PacketWriter writer)
    {
        writer.Write(Position);
    }

    public override void Read(PacketReader reader)
    {
        Position = reader.ReadVector2();
    }

    public override void Handle(Peer peer)
    {
#if SERVER
        //Net.Server.Players[peer.ID].PrevCurPosition.Add(Position);
#endif
    }
}
