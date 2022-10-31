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
		Inventory,
		Take,
		Drop,
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