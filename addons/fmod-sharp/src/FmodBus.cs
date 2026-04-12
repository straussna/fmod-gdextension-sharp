using Godot;

namespace FmodSharp;

/// <summary>
/// Wrapper for an FMOD bus object. Buses control volume, mute, and pause state for groups of events.
/// This is a RefCounted-backed object, not a scene node.
/// </summary>
public class FmodBus(GodotObject busInstance)
{
    /// <summary>
    /// The underlying FMOD bus GodotObject for advanced usage.
    /// </summary>
    public GodotObject FmodInstance { get; } = busInstance ?? throw new ArgumentNullException(nameof(busInstance));

    /// <summary>
    /// Mute state of the bus.
    /// </summary>
    public bool Mute
    {
        get => FmodInstance.Get("mute").AsBool();
        set => FmodInstance.Set("mute", value);
    }

    /// <summary>
    /// Pause state of the bus.
    /// </summary>
    public bool Paused
    {
        get => FmodInstance.Get("paused").AsBool();
        set => FmodInstance.Set("paused", value);
    }

    /// <summary>
    /// Volume of the bus (0.0 to 1.0).
    /// </summary>
    public float Volume
    {
        get => FmodInstance.Get("volume").AsSingle();
        set => FmodInstance.Set("volume", value);
    }

    /// <summary>
    /// Stop all events on this bus using the specified FMOD stop mode constant.
    /// </summary>
    public void StopAllEvents(int stopMode)
    {
        FmodInstance.Call("stop_all_events", stopMode);
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
        FmodInstance.Call("stop_all_events", stopMode);
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
