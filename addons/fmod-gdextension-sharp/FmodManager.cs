using Godot;
using System;
using System.Collections.Generic;

namespace FmodGDExtensionSharp;

/// <summary>
/// Singleton manager class for FMOD audio system.
/// Provides a high-level interface for managing FMOD audio events and buses.
/// </summary>
public partial class FmodManager : Node
{
    private static FmodManager _instance;
    private List<FmodEvent> _activeEvents = new();
    private bool _isInitialized = false;

    /// <summary>
    /// Gets the singleton instance of FmodManager.
    /// </summary>
    public static FmodManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GD.PrintErr("FmodManager instance not initialized. Ensure the autoload is set up correctly.");
            }
            return _instance;
        }
    }

    public override void _Ready()
    {
        _instance = this;
        Initialize();
    }

    /// <summary>
    /// Initializes the FMOD audio system.
    /// </summary>
    public void Initialize()
    {
        if (_isInitialized)
        {
            GD.PrintErr("FMOD Manager already initialized");
            return;
        }

        GD.Print("Initializing FMOD Manager...");
        
        // TODO: Initialize FMOD Studio System
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        _isInitialized = true;
        GD.Print("FMOD Manager initialized successfully");
    }

    /// <summary>
    /// Shuts down the FMOD audio system.
    /// </summary>
    public void Shutdown()
    {
        if (!_isInitialized)
        {
            return;
        }

        GD.Print("Shutting down FMOD Manager...");
        
        // Stop all active events
        foreach (var fmodEvent in _activeEvents)
        {
            fmodEvent.Stop();
        }
        _activeEvents.Clear();

        // TODO: Shutdown FMOD Studio System
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        _isInitialized = false;
        GD.Print("FMOD Manager shutdown complete");
    }

    /// <summary>
    /// Plays an FMOD event by path.
    /// </summary>
    /// <param name="eventPath">The path to the FMOD event (e.g., "event:/Music/MainTheme")</param>
    /// <returns>The FmodEvent instance</returns>
    public FmodEvent PlayEvent(string eventPath)
    {
        if (!_isInitialized)
        {
            GD.PrintErr("FMOD Manager not initialized. Cannot play event: " + eventPath);
            return null;
        }

        GD.Print($"Playing FMOD event: {eventPath}");
        
        var fmodEvent = new FmodEvent(eventPath);
        fmodEvent.Play();
        
        _activeEvents.Add(fmodEvent);
        
        return fmodEvent;
    }

    /// <summary>
    /// Plays an FMOD event at a specific 3D position.
    /// </summary>
    /// <param name="eventPath">The path to the FMOD event</param>
    /// <param name="position">The 3D position to play the event at</param>
    /// <returns>The FmodEvent instance</returns>
    public FmodEvent PlayEventAtPosition(string eventPath, Vector3 position)
    {
        var fmodEvent = PlayEvent(eventPath);
        if (fmodEvent != null)
        {
            fmodEvent.Set3DAttributes(position);
        }
        return fmodEvent;
    }

    /// <summary>
    /// Stops all instances of an FMOD event by path.
    /// </summary>
    /// <param name="eventPath">The path to the FMOD event to stop</param>
    /// <param name="immediate">If true, stops immediately; otherwise, allows release tail</param>
    public void StopEvent(string eventPath, bool immediate = false)
    {
        var eventsToStop = _activeEvents.FindAll(e => e.EventPath == eventPath);
        foreach (var fmodEvent in eventsToStop)
        {
            fmodEvent.Stop(immediate);
            _activeEvents.Remove(fmodEvent);
        }
    }

    /// <summary>
    /// Stops a specific FMOD event instance.
    /// </summary>
    /// <param name="fmodEvent">The event instance to stop</param>
    /// <param name="immediate">If true, stops immediately; otherwise, allows release tail</param>
    public void StopEventInstance(FmodEvent fmodEvent, bool immediate = false)
    {
        if (fmodEvent != null && _activeEvents.Contains(fmodEvent))
        {
            fmodEvent.Stop(immediate);
            _activeEvents.Remove(fmodEvent);
        }
    }

    /// <summary>
    /// Sets a global parameter value.
    /// </summary>
    /// <param name="parameterName">The name of the parameter</param>
    /// <param name="value">The value to set</param>
    public void SetGlobalParameter(string parameterName, float value)
    {
        if (!_isInitialized)
        {
            GD.PrintErr("FMOD Manager not initialized. Cannot set global parameter: " + parameterName);
            return;
        }

        GD.Print($"Setting global parameter {parameterName} to {value}");
        
        // TODO: Implement actual FMOD global parameter setting
        // This will be implemented when integrating with the actual FMOD GDExtension
    }

    /// <summary>
    /// Gets a global parameter value.
    /// </summary>
    /// <param name="parameterName">The name of the parameter</param>
    /// <returns>The parameter value</returns>
    public float GetGlobalParameter(string parameterName)
    {
        if (!_isInitialized)
        {
            GD.PrintErr("FMOD Manager not initialized. Cannot get global parameter: " + parameterName);
            return 0f;
        }

        // TODO: Implement actual FMOD global parameter getting
        // This will be implemented when integrating with the actual FMOD GDExtension
        
        return 0f;
    }

    /// <summary>
    /// Sets the volume of a bus by name.
    /// </summary>
    /// <param name="busPath">The path to the bus (e.g., "bus:/Music")</param>
    /// <param name="volume">The volume level (0.0 to 1.0)</param>
    public void SetBusVolume(string busPath, float volume)
    {
        if (!_isInitialized)
        {
            GD.PrintErr("FMOD Manager not initialized. Cannot set bus volume: " + busPath);
            return;
        }

        volume = Mathf.Clamp(volume, 0f, 1f);
        GD.Print($"Setting bus {busPath} volume to {volume}");
        
        // TODO: Implement actual FMOD bus volume setting
        // This will be implemented when integrating with the actual FMOD GDExtension
    }

    /// <summary>
    /// Pauses or unpauses all audio on a specific bus.
    /// </summary>
    /// <param name="busPath">The path to the bus</param>
    /// <param name="paused">True to pause, false to unpause</param>
    public void SetBusPaused(string busPath, bool paused)
    {
        if (!_isInitialized)
        {
            GD.PrintErr("FMOD Manager not initialized. Cannot set bus paused state: " + busPath);
            return;
        }

        GD.Print($"Setting bus {busPath} paused state to {paused}");
        
        // TODO: Implement actual FMOD bus pause/unpause
        // This will be implemented when integrating with the actual FMOD GDExtension
    }

    public override void _Process(double delta)
    {
        if (!_isInitialized)
        {
            return;
        }

        // Remove stopped events from the active list
        _activeEvents.RemoveAll(e => e.IsStopped());

        // TODO: Update FMOD system
        // This will be implemented when integrating with the actual FMOD GDExtension
    }

    public override void _ExitTree()
    {
        Shutdown();
    }
}
