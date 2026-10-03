using System;
using Godot;

namespace FmodSharp;

/// <summary>Wrapper for an FMOD VCA, which sets the volume of a group of buses.</summary>
public class FmodVca(GodotObject vcaInstance)
{
    /// <summary>The underlying FMOD VCA object.</summary>
    public GodotObject FmodInstance { get; } = vcaInstance ?? throw new ArgumentNullException(nameof(vcaInstance));

    /// <summary>Volume of the VCA, from 0.0 to 1.0.</summary>
    public float Volume
    {
        get => FmodInstance.Get("volume").AsSingle();
        set => FmodInstance.Set("volume", value);
    }

    /// <summary>Returns whether the VCA handle is still valid.</summary>
    public bool IsValid()
    {
        return FmodInstance.Call("is_valid").AsBool();
    }

    /// <summary>Returns the VCA's FMOD path.</summary>
    public string GetPath()
    {
        return FmodInstance.Call("get_path").AsString();
    }

    /// <summary>Returns the VCA's GUID.</summary>
    public string GetGuid()
    {
        return FmodInstance.Call("get_guid").AsString();
    }
}
