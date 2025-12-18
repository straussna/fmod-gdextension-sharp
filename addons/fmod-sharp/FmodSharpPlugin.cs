using Godot;

namespace FmodSharp;

[Tool]
public partial class FmodSharpPlugin : EditorPlugin
{
    private const string _autoloadPath = "res://addons/fmod-sharp/src/FmodServerWrapper.cs";

    public override void _EnterTree()
    {
        AddAutoloadSingleton("FmodServerWrapper", _autoloadPath);
    }

    public override void _ExitTree()
    {
        RemoveAutoloadSingleton("FmodServerWrapper");
    }
}
