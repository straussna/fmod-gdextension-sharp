using System;
using Godot;

namespace FmodSharp;

/// <summary>Wrapper for an FMOD bus, which controls volume, mute and pause for a group of events.</summary>
public class FmodBus(GodotObject busInstance)
{
    /// <summary>The underlying FMOD bus object.</summary>
    public GodotObject FmodInstance { get; } = busInstance ?? throw new ArgumentNullException(nameof(busInstance));

    /// <summary>Mute state of the bus.</summary>
    public bool Mute
    {
        get => FmodInstance.Get("mute").AsBool();
        set => FmodInstance.Set("mute", value);
    }

    /// <summary>Pause state of the bus.</summary>
    public bool Paused
    {
        get => FmodInstance.Get("paused").AsBool();
        set => FmodInstance.Set("paused", value);
    }

    /// <summary>Volume of the bus, from 0.0 to 1.0.</summary>
    public float Volume
    {
        get => FmodInstance.Get("volume").AsSingle();
        set => FmodInstance.Set("volume", value);
    }

    /// <summary>Stops all events on the bus with an FMOD_STUDIO_STOP_* mode.</summary>
    public void StopAllEvents(int stopMode)
    {
        FmodInstance.Call("stop_all_events", stopMode);
    }

    /// <summary>Stops all events on the bus, immediately or with fade-out.</summary>
    public void StopAllEvents(bool immediate = false)
    {
        int stopMode = immediate
            ? FmodServerWrapper.FMOD_STUDIO_STOP_IMMEDIATE
            : FmodServerWrapper.FMOD_STUDIO_STOP_ALLOWFADEOUT;
        FmodInstance.Call("stop_all_events", stopMode);
    }

    /// <summary>Returns whether the bus handle is still valid.</summary>
    public bool IsValid()
    {
        return FmodInstance.Call("is_valid").AsBool();
    }

    /// <summary>Returns the bus's FMOD path.</summary>
    public string GetPath()
    {
        return FmodInstance.Call("get_path").AsString();
    }

    /// <summary>Returns the bus's GUID.</summary>
    public string GetGuid()
    {
        return FmodInstance.Call("get_guid").AsString();
    }
}
