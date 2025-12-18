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
/// For 2D positional audio, the attached node must be a Node2D.
/// </summary>
public partial class FmodEvent : Node
{
    private GodotObject _eventInstance = null!;
    private Node2D _attachedNode => GetParent() as Node2D ?? new Node2D();
    private bool _isPlaying;
    private bool _shouldStart;

    public bool IsPlaying => _isPlaying;

    /// <summary>
    /// The listener mask for this event instance.
    /// </summary>
    public int ListenerMask
    {
        get => _eventInstance.Get("listener_mask").AsInt32();
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
        if (eventInstance == null)
        {
            GD.PushError("FmodEventInstance: Cannot create with null event instance");
            return;
        }

        _eventInstance = eventInstance;
        Name = "FmodEventInstance";
    }

    public override void _Ready()
    {
        // If Start() was called before the node was ready, start now.
        if (_shouldStart)
        {
            _shouldStart = false;
            StartNow();
        }
    }

    /// <summary>
    /// Update the event's position to follow the attached node every frame.
    /// This is required for 2D positional audio to work correctly.
    /// </summary>
    public override void _Process(double delta)
    {
        // Start on first process frame if requested
        if (_shouldStart)
        {
            _shouldStart = false;
            StartNow();
        }

        // Update position every frame when playing and attached to a Node2D
        if (_isPlaying && _eventInstance != null && _attachedNode != null)
        {
            _eventInstance.Call("set_2d_attributes", _attachedNode.GlobalTransform);
        }
    }

    public void EventKeyOff()
    {
        _eventInstance.Call("event_key_off");
    }

    public float GetParameterById(int parameterId)
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
        if (_eventInstance == null)
            return false;

        try
        {
            var result = _eventInstance.Call("is_valid");
            return result.AsBool();
        }
        catch
        {
            return false;
        }
    }

    public bool IsVirtual()
    {
        var result = _eventInstance.Call("is_virtual");
        return result.AsBool();
    }

    public void Release()
    {
        if (_eventInstance != null)
        {
            if (_isPlaying)
            {
                _eventInstance.Call("stop", FmodServerWrapper.FMOD_STUDIO_STOP_IMMEDIATE);
                _isPlaying = false;
            }

            _eventInstance.Call("release");
        }
    }

    public void Set3DAttributes(Transform3D transform)
    {
        _eventInstance?.Call("set_3d_attributes", transform);
    }

    public void SetCallback(Callable callback, int callbackMask)
    {
        _eventInstance?.Call("set_callback", callback, callbackMask);
    }

    public void SetParameterById(int parameterId, float value)
    {
        _eventInstance?.Call("set_parameter_by_id", parameterId, value);
    }

    public void SetParameterByIdWithLabel(int parameterId, string label, bool ignoreSeekSpeed)
    {
        _eventInstance?.Call("set_parameter_by_id_with_label", parameterId, label, ignoreSeekSpeed);
    }

    public void SetParameterByName(string parameterName, float value)
    {
        _eventInstance.Call("set_parameter_by_name", parameterName, value);
    }

    public void SetParameterByNameWithLabel(string parameterName, string label, bool ignoreSeekSpeed)
    {
        _eventInstance?.Call("set_parameter_by_name_with_label", parameterName, label, ignoreSeekSpeed);
    }

    public void SetProgrammerCallback(string programmersCallbackSoundKey)
    {
        _eventInstance?.Call("set_programmer_callback", programmersCallbackSoundKey);
    }

    public void SetReverbLevel(int index, float level)
    {
        _eventInstance?.Call("set_reverb_level", index, level);
    }

    /// <summary>
    /// Request that the event be started. The actual start may occur on the next frame
    /// if the node is not yet ready.
    /// </summary>
    public void Start()
    {
        _shouldStart = true;
    }

    /// <summary>
    /// Stop the event using the specified FMOD stop mode.
    /// </summary>
    public void Stop(int stopMode)
    {
        _shouldStart = false;

        if (_isPlaying)
        {
            _eventInstance.Call("stop", stopMode);
            _isPlaying = false;
        }
    }

    /// <summary>
    /// Stop the event. If <paramref name="immediate"/> is true, the event is stopped immediately,
    /// otherwise it is allowed to fade out.
    /// </summary>
    public void Stop(bool immediate = false)
    {
        _shouldStart = false;

        if (_isPlaying)
        {
            int stopMode = immediate ? FmodServerWrapper.FMOD_STUDIO_STOP_IMMEDIATE : FmodServerWrapper.FMOD_STUDIO_STOP_ALLOWFADEOUT;
            _eventInstance.Call("stop", stopMode);
            _isPlaying = false;
        }
    }

    private void StartNow()
    {
        if (_eventInstance == null)
        {
            GD.PushError("FmodEventInstance.Start: Event instance is null");
            return;
        }

        if (!_isPlaying)
        {
            if (_attachedNode != null)
            {
                _eventInstance.Call("set_2d_attributes", _attachedNode.GlobalTransform);
            }

            _eventInstance.Call("start");
            _isPlaying = true;
        }
    }

    public override void _ExitTree()
    {
        Release();
        base._ExitTree();
    }
}
