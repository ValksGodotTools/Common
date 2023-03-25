namespace Multiplayer;

public class SPacketPeerId : ServerPacket
{
    public uint Id { get; set; }

    public override void Write(PacketWriter writer)
    {
        writer.Write((uint)Id);
    }

    public override void Read(PacketReader reader)
    {
        Id = reader.ReadUInt();
    }

    public override void Handle()
    {
#if CLIENT
        GameMaster.PeerId = Id;
        Net.Client.Log("My client ID is " + GameMaster.PeerId);
#endif
    }
}
