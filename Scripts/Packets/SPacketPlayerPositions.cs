﻿namespace Sandbox2;

public class SPacketPlayerPositions : ServerPacket
{
    public Dictionary<uint, Vector2> PlayerPositions { get; set; }

    public override void Write(PacketWriter writer)
    {
        writer.Write((byte)PlayerPositions.Count);
        foreach (var player in PlayerPositions)
        {
            writer.Write((uint)player.Key);
            writer.Write((Vector2)player.Value);
        }
    }

    public override void Read(PacketReader reader)
    {
        var count = reader.ReadByte();
        PlayerPositions = new();
        for (int i = 0; i < count; i++)
        {
            var id = reader.ReadUInt();
            var pos = reader.ReadVector2();
            PlayerPositions.Add(id, pos);
        }
    }

    public override void Handle()
    {
        foreach (var playerPos in PlayerPositions)
        {
            GameMaster.UpdatePlayerPosition(playerPos.Key, playerPos.Value);
        }
    }
}
