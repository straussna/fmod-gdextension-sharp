#if TOOLS
using Godot;

namespace FmodSharp;

/// <inheritdoc/>
[Tool]
public partial class FmodSharpPlugin : EditorPlugin
{
    private const string _autoloadPath = "res://addons/fmod-sharp/src/FmodServerWrapper.cs";

    /// <inheritdoc/>
    public override void _EnterTree()
    {
        AddAutoloadSingleton("FmodServerWrapper", _autoloadPath);
    }

    /// <inheritdoc/>
    public override void _ExitTree()
    {
        RemoveAutoloadSingleton("FmodServerWrapper");
    }
}
#endif
