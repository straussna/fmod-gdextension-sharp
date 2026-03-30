using Godot;

namespace FmodSharp;

/// <summary>
/// Wrapper for an FMOD VCA (Virtual Control Analog) object.
/// VCAs provide volume control for groups of buses, commonly used for
/// master volume sliders (e.g., Music, SFX, Voice).
/// This is a RefCounted-backed object, not a scene node.
/// </summary>
public class FmodVca(GodotObject vcaInstance)
{
    private readonly GodotObject _vcaInstance = vcaInstance ?? throw new ArgumentNullException(nameof(vcaInstance));

    /// <summary>
    /// The underlying FMOD VCA GodotObject for advanced usage.
    /// </summary>
    public GodotObject FmodInstance => _vcaInstance;

    /// <summary>
    /// Volume of the VCA (0.0 to 1.0).
    /// </summary>
    public float Volume
    {
        get => _vcaInstance.Get("volume").AsSingle();
        set => _vcaInstance.Set("volume", value);
    }

    public bool IsValid()
    {
        return _vcaInstance.Call("is_valid").AsBool();
    }

    public string GetPath()
    {
        return _vcaInstance.Call("get_path").AsString();
    }

    public string GetGuid()
    {
        return _vcaInstance.Call("get_guid").AsString();
    }
}
