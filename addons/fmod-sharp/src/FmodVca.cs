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
    /// <summary>
    /// The underlying FMOD VCA GodotObject for advanced usage.
    /// </summary>
    public GodotObject FmodInstance { get; } = vcaInstance ?? throw new ArgumentNullException(nameof(vcaInstance));

    /// <summary>
    /// Volume of the VCA (0.0 to 1.0).
    /// </summary>
    public float Volume
    {
        get => FmodInstance.Get("volume").AsSingle();
        set => FmodInstance.Set("volume", value);
    }

    public bool IsValid()
    {
        return FmodInstance.Call("is_valid").AsBool();
    }

    public string GetPath()
    {
        return FmodInstance.Call("get_path").AsString();
    }

    public string GetGuid()
    {
        return FmodInstance.Call("get_guid").AsString();
    }
}
