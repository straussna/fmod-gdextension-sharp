using Godot;
using FmodGDExtensionSharp;

namespace FmodGDExtensionSharp.Examples;

/// <summary>
/// Example script demonstrating basic FMOD functionality.
/// This shows how to play events, set parameters, and control buses.
/// </summary>
public partial class BasicExample : Node
{
    public override void _Ready()
    {
        GD.Print("=== FMOD GDExtension Sharp - Basic Example ===");
        
        // Wait a frame for FmodManager to initialize
        CallDeferred(nameof(DemoBasicFunctionality));
    }

    private void DemoBasicFunctionality()
    {
        // Example 1: Play a simple event
        GD.Print("\n--- Example 1: Play a simple event ---");
        var musicEvent = FmodManager.Instance.PlayEvent("event:/Music/MainTheme");
        if (musicEvent != null)
        {
            GD.Print("Music event started successfully");
        }

        // Example 2: Play an event at a 3D position
        GD.Print("\n--- Example 2: Play event at 3D position ---");
        Vector3 soundPosition = new Vector3(10, 0, 5);
        var spatialEvent = FmodManager.Instance.PlayEventAtPosition("event:/SFX/Explosion", soundPosition);
        if (spatialEvent != null)
        {
            GD.Print($"Spatial event started at position {soundPosition}");
        }

        // Example 3: Set event parameters
        GD.Print("\n--- Example 3: Set event parameters ---");
        if (musicEvent != null)
        {
            musicEvent.SetParameter("Intensity", 0.75f);
            musicEvent.SetParameter("Layer", 2.0f);
            GD.Print("Event parameters set");
        }

        // Example 4: Control bus volume
        GD.Print("\n--- Example 4: Control bus volume ---");
        FmodManager.Instance.SetBusVolume("bus:/Music", 0.7f);
        FmodManager.Instance.SetBusVolume("bus:/SFX", 0.9f);
        GD.Print("Bus volumes set");

        // Example 5: Set global parameters
        GD.Print("\n--- Example 5: Set global parameters ---");
        FmodManager.Instance.SetGlobalParameter("TimeOfDay", 18.0f); // Evening
        FmodManager.Instance.SetGlobalParameter("CombatIntensity", 0.5f);
        GD.Print("Global parameters set");

        // Example 6: Pause and resume
        GD.Print("\n--- Example 6: Pause and resume (after 2 seconds) ---");
        GetTree().CreateTimer(2.0).Timeout += () =>
        {
            if (musicEvent != null)
            {
                musicEvent.Pause();
                GD.Print("Music paused");
                
                GetTree().CreateTimer(1.0).Timeout += () =>
                {
                    musicEvent.Resume();
                    GD.Print("Music resumed");
                };
            }
        };

        // Example 7: Stop events
        GD.Print("\n--- Example 7: Stop events (after 5 seconds) ---");
        GetTree().CreateTimer(5.0).Timeout += () =>
        {
            if (musicEvent != null)
            {
                musicEvent.Stop();
                GD.Print("Music stopped");
            }
            if (spatialEvent != null)
            {
                spatialEvent.Stop(true); // Immediate stop
                GD.Print("Spatial event stopped immediately");
            }
        };
    }

    public override void _Input(InputEvent @event)
    {
        // Press Space to play a sound effect
        if (@event is InputEventKey keyEvent && keyEvent.Pressed && !keyEvent.Echo)
        {
            if (keyEvent.Keycode == Key.Space)
            {
                GD.Print("Playing UI click sound");
                FmodManager.Instance.PlayEvent("event:/UI/Click");
            }
        }
    }
}
