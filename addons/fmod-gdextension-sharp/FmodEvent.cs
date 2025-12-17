using Godot;
using System;
using System.Collections.Generic;

namespace FmodGDExtensionSharp;

/// <summary>
/// Represents an FMOD event instance.
/// Provides control over playback, parameters, and 3D attributes.
/// </summary>
public partial class FmodEvent
{
    private string _eventPath;
    private bool _isPlaying = false;
    private bool _isPaused = false;
    private Vector3 _position = Vector3.Zero;
    private Dictionary<string, float> _parameters = new();

    /// <summary>
    /// Gets the path of this FMOD event.
    /// </summary>
    public string EventPath => _eventPath;

    /// <summary>
    /// Gets whether this event is currently playing.
    /// </summary>
    public bool IsPlaying => _isPlaying;

    /// <summary>
    /// Gets whether this event is currently paused.
    /// </summary>
    public bool IsPaused => _isPaused;

    /// <summary>
    /// Gets the 3D position of this event.
    /// </summary>
    public Vector3 Position => _position;

    /// <summary>
    /// Creates a new FmodEvent instance.
    /// </summary>
    /// <param name="eventPath">The path to the FMOD event</param>
    public FmodEvent(string eventPath)
    {
        _eventPath = eventPath;
        
        // TODO: Create actual FMOD event instance
        // This will be implemented when integrating with the actual FMOD GDExtension
    }

    /// <summary>
    /// Starts playback of this event.
    /// </summary>
    public void Play()
    {
        if (_isPlaying && !_isPaused)
        {
            GD.PrintErr($"Event {_eventPath} is already playing");
            return;
        }

        GD.Print($"Playing event: {_eventPath}");
        
        // TODO: Implement actual FMOD event play
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        _isPlaying = true;
        _isPaused = false;
    }

    /// <summary>
    /// Stops playback of this event.
    /// </summary>
    /// <param name="immediate">If true, stops immediately; otherwise, allows release tail</param>
    public void Stop(bool immediate = false)
    {
        if (!_isPlaying)
        {
            return;
        }

        GD.Print($"Stopping event: {_eventPath} (immediate: {immediate})");
        
        // TODO: Implement actual FMOD event stop
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        _isPlaying = false;
        _isPaused = false;
    }

    /// <summary>
    /// Pauses playback of this event.
    /// </summary>
    public void Pause()
    {
        if (!_isPlaying || _isPaused)
        {
            return;
        }

        GD.Print($"Pausing event: {_eventPath}");
        
        // TODO: Implement actual FMOD event pause
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        _isPaused = true;
    }

    /// <summary>
    /// Resumes playback of this event.
    /// </summary>
    public void Resume()
    {
        if (!_isPlaying || !_isPaused)
        {
            return;
        }

        GD.Print($"Resuming event: {_eventPath}");
        
        // TODO: Implement actual FMOD event resume
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        _isPaused = false;
    }

    /// <summary>
    /// Sets a parameter value for this event.
    /// </summary>
    /// <param name="parameterName">The name of the parameter</param>
    /// <param name="value">The value to set</param>
    public void SetParameter(string parameterName, float value)
    {
        GD.Print($"Setting parameter {parameterName} to {value} for event {_eventPath}");
        
        _parameters[parameterName] = value;
        
        // TODO: Implement actual FMOD parameter setting
        // This will be implemented when integrating with the actual FMOD GDExtension
    }

    /// <summary>
    /// Gets a parameter value from this event.
    /// </summary>
    /// <param name="parameterName">The name of the parameter</param>
    /// <returns>The parameter value</returns>
    public float GetParameter(string parameterName)
    {
        if (_parameters.TryGetValue(parameterName, out float value))
        {
            return value;
        }
        
        // TODO: Implement actual FMOD parameter getting
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        return 0f;
    }

    /// <summary>
    /// Sets the 3D attributes (position) for this event.
    /// </summary>
    /// <param name="position">The 3D position</param>
    public void Set3DAttributes(Vector3 position)
    {
        _position = position;
        
        GD.Print($"Setting 3D position to {position} for event {_eventPath}");
        
        // TODO: Implement actual FMOD 3D attributes setting
        // This will be implemented when integrating with the actual FMOD GDExtension
    }

    /// <summary>
    /// Sets the 3D attributes with velocity for this event.
    /// </summary>
    /// <param name="position">The 3D position</param>
    /// <param name="velocity">The velocity vector</param>
    public void Set3DAttributes(Vector3 position, Vector3 velocity)
    {
        _position = position;
        
        GD.Print($"Setting 3D position to {position} and velocity to {velocity} for event {_eventPath}");
        
        // TODO: Implement actual FMOD 3D attributes setting with velocity
        // This will be implemented when integrating with the actual FMOD GDExtension
    }

    /// <summary>
    /// Gets the playback position of this event in milliseconds.
    /// </summary>
    /// <returns>The playback position in milliseconds</returns>
    public int GetTimelinePosition()
    {
        // TODO: Implement actual FMOD timeline position getting
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        return 0;
    }

    /// <summary>
    /// Sets the playback position of this event in milliseconds.
    /// </summary>
    /// <param name="position">The position in milliseconds</param>
    public void SetTimelinePosition(int position)
    {
        GD.Print($"Setting timeline position to {position}ms for event {_eventPath}");
        
        // TODO: Implement actual FMOD timeline position setting
        // This will be implemented when integrating with the actual FMOD GDExtension
    }

    /// <summary>
    /// Gets the volume of this event.
    /// </summary>
    /// <returns>The volume level (0.0 to 1.0)</returns>
    public float GetVolume()
    {
        // TODO: Implement actual FMOD volume getting
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        return 1f;
    }

    /// <summary>
    /// Sets the volume of this event.
    /// </summary>
    /// <param name="volume">The volume level (0.0 to 1.0)</param>
    public void SetVolume(float volume)
    {
        volume = Mathf.Clamp(volume, 0f, 1f);
        GD.Print($"Setting volume to {volume} for event {_eventPath}");
        
        // TODO: Implement actual FMOD volume setting
        // This will be implemented when integrating with the actual FMOD GDExtension
    }

    /// <summary>
    /// Checks if the event has finished playing.
    /// </summary>
    /// <returns>True if the event has stopped, false otherwise</returns>
    public bool IsStopped()
    {
        // TODO: Implement actual FMOD event state checking
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        return !_isPlaying;
    }

    /// <summary>
    /// Releases the event instance.
    /// </summary>
    public void Release()
    {
        GD.Print($"Releasing event: {_eventPath}");
        
        // TODO: Implement actual FMOD event release
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        _isPlaying = false;
        _isPaused = false;
    }
}
