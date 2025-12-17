#if TOOLS
using Godot;

namespace FmodGDExtensionSharp;

/// <summary>
/// Main plugin class for FMOD GDExtension Sharp addon.
/// This class handles the initialization and cleanup of the FMOD addon.
/// </summary>
[Tool]
public partial class FmodPlugin : EditorPlugin
{
    /// <summary>
    /// Called when the plugin enters the scene tree.
    /// Initialize the FMOD system and register custom types here.
    /// </summary>
    public override void _EnterTree()
    {
        GD.Print("FMOD GDExtension Sharp plugin enabled");
        
        // Add autoload singleton for FMOD manager
        AddAutoloadSingleton("FmodManager", "res://addons/fmod-gdextension-sharp/FmodManager.cs");
    }

    /// <summary>
    /// Called when the plugin exits the scene tree.
    /// Cleanup and release FMOD resources here.
    /// </summary>
    public override void _ExitTree()
    {
        GD.Print("FMOD GDExtension Sharp plugin disabled");
        
        // Remove autoload singleton
        RemoveAutoloadSingleton("FmodManager");
    }
}
#endif
