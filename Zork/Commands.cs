namespace Zork
{
	public enum Commands
	{
		Quit,
		Look,
		North,
		South,
		West,
		East,
		Unknown
	}

	public enum Directions
	{
		North = Commands.North,
		South = Commands.South,
		West = Commands.West,
		East = Commands.East
	}
}