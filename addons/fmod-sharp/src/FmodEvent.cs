using Godot;

namespace FmodSharp;

public enum FMOD_STUDIO_PLAYBACK_STATE
{
    FMOD_STUDIO_PLAYBACK_PLAYING = 0,
    FMOD_STUDIO_PLAYBACK_SUSTAINING = 1,
    FMOD_STUDIO_PLAYBACK_STOPPED = 2,
    FMOD_STUDIO_PLAYBACK_STARTING = 3,
    FMOD_STUDIO_PLAYBACK_STOPPING = 4,
    FMOD_STUDIO_PLAYBACK_FORCEINT = 65536,
}

/// <summary>
/// Wrapper for an FMOD event instance that manages its lifecycle and provides position tracking.
/// Supports both 2D and 3D positional audio based on the parent node type.
/// </summary>
public partial class FmodEvent : Node
{
    private readonly GodotObject _eventInstance;
    private bool _released;

    /// <summary>
    /// The underlying FMOD event GodotObject for advanced usage.
    /// </summary>
    public GodotObject FmodInstance => _eventInstance;

    /// <summary>
    /// Whether the event is currently playing, based on actual FMOD playback state.
    /// </summary>
    public bool IsPlaying
    {
        get
        {
            var state = GetPlaybackState();
            return state is FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_PLAYING
                or FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_STARTING
                or FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_SUSTAINING;
        }
    }

    /// <summary>
    /// The listener mask for this event instance.
    /// </summary>
    public uint ListenerMask
    {
        get => _eventInstance.Get("listener_mask").AsUInt32();
        set => _eventInstance.Set("listener_mask", value);
    }

    /// <summary>
    /// Pause state of the event.
    /// </summary>
    public bool Paused
    {
        get => _eventInstance.Get("paused").AsBool();
        set => _eventInstance.Set("paused", value);
    }

    /// <summary>
    /// Playback pitch.
    /// </summary>
    public float Pitch
    {
        get => _eventInstance.Get("pitch").AsSingle();
        set => _eventInstance.Set("pitch", value);
    }

    /// <summary>
    /// Playback position in milliseconds (or as provided by FMOD binding).
    /// </summary>
    public int Position
    {
        get => _eventInstance.Get("position").AsInt32();
        set => _eventInstance.Set("position", value);
    }

    /// <summary>
    /// 2D transform used for positional audio.
    /// </summary>
    public Transform2D Transform2D
    {
        get => (Transform2D)_eventInstance.Get("transform_2d");
        set => _eventInstance.Set("transform_2d", value);
    }

    /// <summary>
    /// 3D transform used for positional audio.
    /// </summary>
    public Transform3D Transform3D
    {
        get => (Transform3D)_eventInstance.Get("transform_3d");
        set => _eventInstance.Set("transform_3d", value);
    }

    /// <summary>
    /// Playback volume.
    /// </summary>
    public float Volume
    {
        get => _eventInstance.Get("volume").AsSingle();
        set => _eventInstance.Set("volume", value);
    }

    /// <summary>
    /// Create a new FMOD event instance wrapper.
    /// </summary>
    /// <param name="eventInstance">The FMOD event instance GodotObject.</param>
    public FmodEvent(GodotObject eventInstance)
    {
        _eventInstance = eventInstance ?? throw new ArgumentNullException(nameof(eventInstance));
        Name = "FmodEventInstance";
    }

    /// <summary>
    /// Update the event's position to follow the parent node every frame.
    /// Automatically detects Node2D vs Node3D parents for correct spatial audio.
    /// Only applies when the FmodEvent is added as a child node in the scene tree.
    /// </summary>
    public override void _Process(double delta)
    {
        if (!IsPlaying) return;

        var parent = GetParent();
        if (parent is Node2D or Node3D)
        {
            _eventInstance.Call("set_node_attributes", parent);
        }
    }

    public void EventKeyOff()
    {
        _eventInstance.Call("event_key_off");
    }

    public float GetParameterById(long parameterId)
    {
        var result = _eventInstance.Call("get_parameter_by_id", parameterId);
        return result.AsSingle();
    }

    public float GetParameterByName(string parameterName)
    {
        var result = _eventInstance.Call("get_parameter_by_name", parameterName);
        return result.AsSingle();
    }

    public FMOD_STUDIO_PLAYBACK_STATE GetPlaybackState()
    {
        var result = _eventInstance.Call("get_playback_state");
        return (FMOD_STUDIO_PLAYBACK_STATE)result.AsInt32();
    }

    public string GetProgrammerCallbackSoundKey()
    {
        var result = _eventInstance.Call("get_programmer_callback_sound_key");
        return result.AsString();
    }

    public float GetReverbLevel(int index)
    {
        var result = _eventInstance.Call("get_reverb_level", index);
        return result.AsSingle();
    }

    public bool IsValid()
    {
        return _eventInstance.Call("is_valid").AsBool();
    }

    public bool IsVirtual()
    {
        var result = _eventInstance.Call("is_virtual");
        return result.AsBool();
    }

    public void Release()
    {
        if (_released) return;
        _released = true;

        if (IsPlaying)
        {
            _eventInstance.Call("stop", FmodServerWrapper.FMOD_STUDIO_STOP_IMMEDIATE);
        }

        _eventInstance.Call("release");
    }

    public void Set2DAttributes(Transform2D transform)
    {
        _eventInstance.Call("set_2d_attributes", transform);
    }

    public Transform2D Get2DAttributes()
    {
        return (Transform2D)_eventInstance.Call("get_2d_attributes");
    }

    public void Set3DAttributes(Transform3D transform)
    {
        _eventInstance.Call("set_3d_attributes", transform);
    }

    public Transform3D Get3DAttributes()
    {
        return (Transform3D)_eventInstance.Call("get_3d_attributes");
    }

    public void SetNodeAttributes(Node node)
    {
        _eventInstance.Call("set_node_attributes", node);
    }

    public void SetDistanceScale(float scale)
    {
        _eventInstance.Call("set_distance_scale", scale);
    }

    public void SetCallback(Callable callback, uint callbackMask)
    {
        _eventInstance.Call("set_callback", callback, callbackMask);
    }

    public void SetParameterById(long parameterId, float value)
    {
        _eventInstance.Call("set_parameter_by_id", parameterId, value);
    }

    public void SetParameterByIdWithLabel(long parameterId, string label, bool ignoreSeekSpeed = false)
    {
        _eventInstance.Call("set_parameter_by_id_with_label", parameterId, label, ignoreSeekSpeed);
    }

    public void SetParameterByName(string parameterName, float value)
    {
        _eventInstance.Call("set_parameter_by_name", parameterName, value);
    }

    public void SetParameterByNameWithLabel(string parameterName, string label, bool ignoreSeekSpeed = false)
    {
        _eventInstance.Call("set_parameter_by_name_with_label", parameterName, label, ignoreSeekSpeed);
    }

    public void SetProgrammerCallback(string programmersCallbackSoundKey)
    {
        _eventInstance.Call("set_programmer_callback", programmersCallbackSoundKey);
    }

    public void SetReverbLevel(int index, float level)
    {
        _eventInstance.Call("set_reverb_level", index, level);
    }

    /// <summary>
    /// Start playback of the event.
    /// </summary>
    public void Start()
    {
        _eventInstance.Call("start");
    }

    /// <summary>
    /// Stop the event using the specified FMOD stop mode.
    /// </summary>
    public void Stop(int stopMode)
    {
        if (IsPlaying)
        {
            _eventInstance.Call("stop", stopMode);
        }
    }

    /// <summary>
    /// Stop the event. If <paramref name="immediate"/> is true, the event is stopped immediately,
    /// otherwise it is allowed to fade out.
    /// </summary>
    public void Stop(bool immediate = false)
    {
        if (IsPlaying)
        {
            int stopMode = immediate ? FmodServerWrapper.FMOD_STUDIO_STOP_IMMEDIATE : FmodServerWrapper.FMOD_STUDIO_STOP_ALLOWFADEOUT;
            _eventInstance.Call("stop", stopMode);
        }
    }

    public override void _ExitTree()
    {
        Release();
        base._ExitTree();
    }
}
