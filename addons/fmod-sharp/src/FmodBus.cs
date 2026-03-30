using System;
using Godot;

namespace FmodSharp;

/// <summary>
/// Wrapper for an FMOD bus object. Buses control volume, mute, and pause state for groups of events.
/// This is a RefCounted-backed object, not a scene node.
/// </summary>
public class FmodBus
{
    private readonly GodotObject _busInstance;

    /// <summary>
    /// The underlying FMOD bus GodotObject for advanced usage.
    /// </summary>
    public GodotObject FmodInstance => _busInstance;

    /// <summary>
    /// Mute state of the bus.
    /// </summary>
    public bool Mute
    {
        get => _busInstance.Get("mute").AsBool();
        set => _busInstance.Set("mute", value);
    }

    /// <summary>
    /// Pause state of the bus.
    /// </summary>
    public bool Paused
    {
        get => _busInstance.Get("paused").AsBool();
        set => _busInstance.Set("paused", value);
    }

    /// <summary>
    /// Volume of the bus (0.0 to 1.0).
    /// </summary>
    public float Volume
    {
        get => _busInstance.Get("volume").AsSingle();
        set => _busInstance.Set("volume", value);
    }

    public FmodBus(GodotObject busInstance)
    {
        _busInstance = busInstance ?? throw new ArgumentNullException(nameof(busInstance));
    }

    /// <summary>
    /// Stop all events on this bus using the specified FMOD stop mode constant.
    /// </summary>
    public void StopAllEvents(int stopMode)
    {
        _busInstance.Call("stop_all_events", stopMode);
    }

    /// <summary>
    /// Stop all events on this bus. If <paramref name="immediate"/> is true, events stop immediately,
    /// otherwise they are allowed to fade out.
    /// </summary>
    public void StopAllEvents(bool immediate = false)
    {
        int stopMode = immediate
            ? FmodServerWrapper.FMOD_STUDIO_STOP_IMMEDIATE
            : FmodServerWrapper.FMOD_STUDIO_STOP_ALLOWFADEOUT;
        _busInstance.Call("stop_all_events", stopMode);
    }

    public bool IsValid()
    {
        return _busInstance.Call("is_valid").AsBool();
    }

    public string GetPath()
    {
        return _busInstance.Call("get_path").AsString();
    }

    public string GetGuid()
    {
        return _busInstance.Call("get_guid").AsString();
    }
}
