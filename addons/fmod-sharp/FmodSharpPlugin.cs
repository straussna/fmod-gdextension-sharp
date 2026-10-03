#if TOOLS
using Godot;

namespace FmodSharp;

/// <summary>Editor plugin that registers <see cref="FmodServerWrapper"/> as an autoload singleton.</summary>
[Tool]
public partial class FmodSharpPlugin : EditorPlugin
{
    private const string _autoloadPath = "res://addons/fmod-sharp/src/FmodServerWrapper.cs";

    /// <summary>Adds the FmodServerWrapper autoload when the plugin is enabled.</summary>
    public override void _EnterTree()
    {
        AddAutoloadSingleton("FmodServerWrapper", _autoloadPath);
    }

    /// <summary>Removes the FmodServerWrapper autoload when the plugin is disabled.</summary>
    public override void _ExitTree()
    {
        RemoveAutoloadSingleton("FmodServerWrapper");
    }
}
#endif
