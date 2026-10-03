using System;
using Godot;

namespace FmodSharp;

/// <summary>Playback states returned by <see cref="FmodEvent.GetPlaybackState"/>.</summary>
public enum FMOD_STUDIO_PLAYBACK_STATE
{
    /// <summary>Playback state: playing.</summary>
    FMOD_STUDIO_PLAYBACK_PLAYING = 0,
    /// <summary>Playback state: paused on a sustain point.</summary>
    FMOD_STUDIO_PLAYBACK_SUSTAINING = 1,
    /// <summary>Playback state: stopped.</summary>
    FMOD_STUDIO_PLAYBACK_STOPPED = 2,
    /// <summary>Playback state: starting.</summary>
    FMOD_STUDIO_PLAYBACK_STARTING = 3,
    /// <summary>Playback state: fading out before stopping.</summary>
    FMOD_STUDIO_PLAYBACK_STOPPING = 4,
    /// <summary>Forces the playback state type to 32 bits.</summary>
    FMOD_STUDIO_PLAYBACK_FORCEINT = 65536,
}

/// <summary>Node wrapping an FMOD event instance that follows a Node2D or Node3D parent's position.
/// Releases the instance when it leaves the scene tree.</summary>
public partial class FmodEvent : Node
{
    private bool _released;

    /// <summary>The underlying FMOD event instance object.</summary>
    public GodotObject FmodInstance { get; }

    /// <summary>Whether the event is playing, starting or sustaining.</summary>
    public bool IsPlaying
    {
        get
        {
            // Native calls on a handle FMOD has stolen crash; is_valid is safe on any handle.
            if (_released || !IsValid())
                return false;

            var state = GetPlaybackState();
            return state is FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_PLAYING
                or FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_STARTING
                or FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_SUSTAINING;
        }
    }

    /// <summary>Bit mask of the listeners that hear the event.</summary>
    public uint ListenerMask
    {
        get => FmodInstance.Get("listener_mask").AsUInt32();
        set => FmodInstance.Set("listener_mask", value);
    }

    /// <summary>Pause state of the event.</summary>
    public bool Paused
    {
        get => FmodInstance.Get("paused").AsBool();
        set => FmodInstance.Set("paused", value);
    }

    /// <summary>Playback pitch multiplier.</summary>
    public float Pitch
    {
        get => FmodInstance.Get("pitch").AsSingle();
        set => FmodInstance.Set("pitch", value);
    }

    /// <summary>Timeline position, in milliseconds.</summary>
    public int Position
    {
        get => FmodInstance.Get("position").AsInt32();
        set => FmodInstance.Set("position", value);
    }

    /// <summary>2D transform used for positional audio.</summary>
    public Transform2D Transform2D
    {
        get => (Transform2D)FmodInstance.Get("transform_2d");
        set => FmodInstance.Set("transform_2d", value);
    }

    /// <summary>3D transform used for positional audio.</summary>
    public Transform3D Transform3D
    {
        get => (Transform3D)FmodInstance.Get("transform_3d");
        set => FmodInstance.Set("transform_3d", value);
    }

    /// <summary>Playback volume.</summary>
    public float Volume
    {
        get => FmodInstance.Get("volume").AsSingle();
        set => FmodInstance.Set("volume", value);
    }

    /// <summary>Wraps <paramref name="eventInstance"/> in a node named FmodEventInstance.</summary>
    public FmodEvent(GodotObject eventInstance)
    {
        FmodInstance = eventInstance ?? throw new ArgumentNullException(nameof(eventInstance));
        Name = "FmodEventInstance";
    }

    public override void _Process(double delta)
    {
        if (!IsPlaying) return;

        var parent = GetParent();
        if (parent is Node2D or Node3D)
        {
            FmodInstance.Call("set_node_attributes", parent);
        }
    }

    /// <summary>Triggers key-off, releasing sustain points on the timeline.</summary>
    public void EventKeyOff()
    {
        FmodInstance.Call("event_key_off");
    }

    /// <summary>Returns the value of the parameter with the given ID.</summary>
    public float GetParameterById(long parameterId)
    {
        var result = FmodInstance.Call("get_parameter_by_id", parameterId);
        return result.AsSingle();
    }

    /// <summary>Returns the value of the named parameter.</summary>
    public float GetParameterByName(string parameterName)
    {
        var result = FmodInstance.Call("get_parameter_by_name", parameterName);
        return result.AsSingle();
    }

    /// <summary>Returns the current playback state.</summary>
    public FMOD_STUDIO_PLAYBACK_STATE GetPlaybackState()
    {
        var result = FmodInstance.Call("get_playback_state");
        return (FMOD_STUDIO_PLAYBACK_STATE)result.AsInt32();
    }

    /// <summary>Returns the sound key used by the programmer sound callback.</summary>
    public string GetProgrammerCallbackSoundKey()
    {
        var result = FmodInstance.Call("get_programmer_callback_sound_key");
        return result.AsString();
    }

    /// <summary>Returns the send level to the reverb at the given index.</summary>
    public float GetReverbLevel(int index)
    {
        var result = FmodInstance.Call("get_reverb_level", index);
        return result.AsSingle();
    }

    /// <summary>Returns whether the event handle is still valid.</summary>
    public bool IsValid()
    {
        return FmodInstance.Call("is_valid").AsBool();
    }

    /// <summary>Returns whether FMOD has virtualized the event.</summary>
    public bool IsVirtual()
    {
        var result = FmodInstance.Call("is_virtual");
        return result.AsBool();
    }

    /// <summary>Stops the event immediately and releases the FMOD instance; later calls do nothing.</summary>
    public void Release()
    {
        if (_released) return;

        // Skip native calls on a handle FMOD has already reclaimed.
        if (IsValid())
        {
            if (IsPlaying)
                FmodInstance.Call("stop", FmodServerWrapper.FMOD_STUDIO_STOP_IMMEDIATE);

            FmodInstance.Call("release");
        }

        // Set last so IsPlaying above still queries FMOD.
        _released = true;
    }

    /// <summary>Sets the event's 2D position from a transform.</summary>
    public void Set2DAttributes(Transform2D transform)
    {
        FmodInstance.Call("set_2d_attributes", transform);
    }

    /// <summary>Returns the event's 2D position as a transform.</summary>
    public Transform2D Get2DAttributes()
    {
        return (Transform2D)FmodInstance.Call("get_2d_attributes");
    }

    /// <summary>Sets the event's 3D position from a transform.</summary>
    public void Set3DAttributes(Transform3D transform)
    {
        FmodInstance.Call("set_3d_attributes", transform);
    }

    /// <summary>Returns the event's 3D position as a transform.</summary>
    public Transform3D Get3DAttributes()
    {
        return (Transform3D)FmodInstance.Call("get_3d_attributes");
    }

    /// <summary>Sets the event's position from a Node2D or Node3D.</summary>
    public void SetNodeAttributes(Node node)
    {
        FmodInstance.Call("set_node_attributes", node);
    }

    /// <summary>Sets the distance scale applied to 3D attenuation.</summary>
    public void SetDistanceScale(float scale)
    {
        FmodInstance.Call("set_distance_scale", scale);
    }

    /// <summary>Registers a callback for the FMOD_STUDIO_EVENT_CALLBACK_* types in the mask.</summary>
    public void SetCallback(Callable callback, uint callbackMask)
    {
        FmodInstance.Call("set_callback", callback, callbackMask);
    }

    /// <summary>Sets the value of the parameter with the given ID.</summary>
    public void SetParameterById(long parameterId, float value)
    {
        FmodInstance.Call("set_parameter_by_id", parameterId, value);
    }

    /// <summary>Sets the parameter with the given ID to the value of a label.</summary>
    public void SetParameterByIdWithLabel(long parameterId, string label, bool ignoreSeekSpeed = false)
    {
        FmodInstance.Call("set_parameter_by_id_with_label", parameterId, label, ignoreSeekSpeed);
    }

    /// <summary>Sets the value of the named parameter.</summary>
    public void SetParameterByName(string parameterName, float value)
    {
        FmodInstance.Call("set_parameter_by_name", parameterName, value);
    }

    /// <summary>Sets the named parameter to the value of a label.</summary>
    public void SetParameterByNameWithLabel(string parameterName, string label, bool ignoreSeekSpeed = false)
    {
        FmodInstance.Call("set_parameter_by_name_with_label", parameterName, label, ignoreSeekSpeed);
    }

    /// <summary>Sets the sound key used by the programmer sound callback.</summary>
    public void SetProgrammerCallback(string programmersCallbackSoundKey)
    {
        FmodInstance.Call("set_programmer_callback", programmersCallbackSoundKey);
    }

    /// <summary>Sets the send level to the reverb at the given index.</summary>
    public void SetReverbLevel(int index, float level)
    {
        FmodInstance.Call("set_reverb_level", index, level);
    }

    /// <summary>Starts playback.</summary>
    public void Start()
    {
        FmodInstance.Call("start");
    }

    /// <summary>Stops playback with an FMOD_STUDIO_STOP_* mode if the event is playing.</summary>
    public void Stop(int stopMode)
    {
        if (IsPlaying)
        {
            FmodInstance.Call("stop", stopMode);
        }
    }

    /// <summary>Stops playback, immediately or with fade-out, if the event is playing.</summary>
    public void Stop(bool immediate = false)
    {
        if (IsPlaying)
        {
            int stopMode = immediate ? FmodServerWrapper.FMOD_STUDIO_STOP_IMMEDIATE : FmodServerWrapper.FMOD_STUDIO_STOP_ALLOWFADEOUT;
            FmodInstance.Call("stop", stopMode);
        }
    }

    public override void _ExitTree()
    {
        Release();
        base._ExitTree();
    }
}
