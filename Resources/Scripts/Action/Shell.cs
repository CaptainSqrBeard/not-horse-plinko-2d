using Godot;

/// <summary>
/// This class provides functionality to open a URL or file.
/// </summary>
public partial class Shell : Node
{

	[Export] public string Link;

    /// <summary>
    /// Opens the specified URL or file.
    /// </summary>
	private void Activate()
	{
		OS.ShellOpen(Link);
	}
}