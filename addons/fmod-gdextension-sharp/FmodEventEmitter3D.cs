using Godot;
using System;

namespace FmodGDExtensionSharp;

/// <summary>
/// A Node3D component for playing FMOD events in 3D space.
/// Automatically updates the event's 3D position based on the node's transform.
/// </summary>
[GlobalClass]
public partial class FmodEventEmitter3D : Node3D
{
    private FmodEvent _eventInstance;
    private Vector3 _lastPosition;

    /// <summary>
    /// The path to the FMOD event to play.
    /// </summary>
    [Export]
    public string EventPath { get; set; } = "";

    /// <summary>
    /// Whether to play the event automatically when the node enters the scene.
    /// </summary>
    [Export]
    public bool AutoPlay { get; set; } = false;

    /// <summary>
    /// Whether to stop the event when the node exits the scene.
    /// </summary>
    [Export]
    public bool StopOnExit { get; set; } = true;

    /// <summary>
    /// Gets whether the event is currently playing.
    /// </summary>
    public bool IsPlaying => _eventInstance?.IsPlaying ?? false;

    public override void _Ready()
    {
        _lastPosition = GlobalPosition;

        if (AutoPlay && !string.IsNullOrEmpty(EventPath))
        {
            Play();
        }
    }

    /// <summary>
    /// Starts playback of the FMOD event.
    /// </summary>
    public void Play()
    {
        if (string.IsNullOrEmpty(EventPath))
        {
            GD.PrintErr("Cannot play event: EventPath is not set");
            return;
        }

        if (_eventInstance != null && _eventInstance.IsPlaying)
        {
            GD.PrintErr($"Event {EventPath} is already playing on this emitter");
            return;
        }

        if (FmodManager.Instance != null)
        {
            _eventInstance = FmodManager.Instance.PlayEvent(EventPath);
            if (_eventInstance != null)
            {
                _eventInstance.Set3DAttributes(GlobalPosition);
            }
        }
        else
        {
            GD.PrintErr("FmodManager is not available. Cannot play event.");
        }
    }

    /// <summary>
    /// Stops playback of the FMOD event.
    /// </summary>
    /// <param name="immediate">If true, stops immediately; otherwise, allows release tail</param>
    public void Stop(bool immediate = false)
    {
        if (_eventInstance != null)
        {
            _eventInstance.Stop(immediate);
            _eventInstance = null;
        }
    }

    /// <summary>
    /// Pauses playback of the FMOD event.
    /// </summary>
    public void Pause()
    {
        _eventInstance?.Pause();
    }

    /// <summary>
    /// Resumes playback of the FMOD event.
    /// </summary>
    public void Resume()
    {
        _eventInstance?.Resume();
    }

    /// <summary>
    /// Sets a parameter value for the event.
    /// </summary>
    /// <param name="parameterName">The name of the parameter</param>
    /// <param name="value">The value to set</param>
    public void SetParameter(string parameterName, float value)
    {
        _eventInstance?.SetParameter(parameterName, value);
    }

    /// <summary>
    /// Gets a parameter value from the event.
    /// </summary>
    /// <param name="parameterName">The name of the parameter</param>
    /// <returns>The parameter value</returns>
    public float GetParameter(string parameterName)
    {
        return _eventInstance?.GetParameter(parameterName) ?? 0f;
    }

    public override void _Process(double delta)
    {
        // Update 3D position if the node has moved
        if (_eventInstance != null && _eventInstance.IsPlaying)
        {
            Vector3 currentPosition = GlobalPosition;
            if (!currentPosition.IsEqualApprox(_lastPosition))
            {
                Vector3 velocity = (currentPosition - _lastPosition) / (float)delta;
                _eventInstance.Set3DAttributes(currentPosition, velocity);
                _lastPosition = currentPosition;
            }
        }
    }

    public override void _ExitTree()
    {
        if (StopOnExit && _eventInstance != null)
        {
            Stop();
        }
    }
}
