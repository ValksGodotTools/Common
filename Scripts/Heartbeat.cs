namespace Multiplayer;

public static class Heartbeat
{
    public static int PositionUpdate { get; } = 150;
}

public enum Direction
{
	None,
	Up,
	Down,
	Left,
	Right
}
