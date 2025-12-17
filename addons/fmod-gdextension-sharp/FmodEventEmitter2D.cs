using Godot;
using System;

namespace FmodGDExtensionSharp;

/// <summary>
/// A Node2D component for playing FMOD events in 2D space.
/// Automatically updates the event's 2D position based on the node's transform.
/// </summary>
[GlobalClass]
public partial class FmodEventEmitter2D : Node2D
{
    private FmodEvent _eventInstance;
    private Vector2 _lastPosition;

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
                // Convert 2D position to 3D (Y becomes Z for depth)
                Vector3 position3D = new Vector3(GlobalPosition.X, 0, GlobalPosition.Y);
                _eventInstance.Set3DAttributes(position3D);
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
        // Update 2D position if the node has moved
        if (_eventInstance != null && _eventInstance.IsPlaying)
        {
            Vector2 currentPosition = GlobalPosition;
            if (!currentPosition.IsEqualApprox(_lastPosition))
            {
                // Convert 2D position to 3D (Y becomes Z for depth)
                Vector3 position3D = new Vector3(currentPosition.X, 0, currentPosition.Y);
                Vector2 velocity2D = (currentPosition - _lastPosition) / (float)delta;
                Vector3 velocity3D = new Vector3(velocity2D.X, 0, velocity2D.Y);
                
                _eventInstance.Set3DAttributes(position3D, velocity3D);
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
