using Godot;
using FmodGDExtensionSharp;

namespace FmodGDExtensionSharp.Examples;

/// <summary>
/// Example script demonstrating 3D audio functionality.
/// Shows how to use FmodEventEmitter3D for spatial audio.
/// </summary>
public partial class SpatialAudioExample : Node3D
{
    private FmodEventEmitter3D _emitter;
    private Node3D _movingObject;
    private float _time = 0f;

    public override void _Ready()
    {
        GD.Print("=== FMOD GDExtension Sharp - Spatial Audio Example ===");
        
        SetupSpatialAudio();
    }

    private void SetupSpatialAudio()
    {
        // Create a moving object with an audio emitter
        _movingObject = new Node3D();
        AddChild(_movingObject);
        _movingObject.Position = new Vector3(0, 0, 0);

        // Add FMOD event emitter to the moving object
        _emitter = new FmodEventEmitter3D
        {
            EventPath = "event:/Ambience/FireLoop",
            AutoPlay = true,
            StopOnExit = true
        };
        _movingObject.AddChild(_emitter);

        GD.Print("Spatial audio emitter created and playing");
        GD.Print("The sound source will move in a circular pattern");
    }

    public override void _Process(double delta)
    {
        if (_movingObject == null) return;

        // Move the object in a circle
        _time += (float)delta;
        float radius = 10f;
        float x = Mathf.Cos(_time) * radius;
        float z = Mathf.Sin(_time) * radius;
        
        _movingObject.Position = new Vector3(x, 0, z);

        // Update parameter based on distance from origin
        if (_emitter != null && _emitter.IsPlaying)
        {
            float distance = _movingObject.Position.Length();
            float normalizedDistance = Mathf.Clamp(distance / radius, 0f, 1f);
            _emitter.SetParameter("Distance", normalizedDistance);
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed && !keyEvent.Echo)
        {
            // Press P to pause/resume
            if (keyEvent.Keycode == Key.P)
            {
                if (_emitter != null)
                {
                    if (_emitter.IsPlaying)
                    {
                        _emitter.Pause();
                        GD.Print("Audio paused");
                    }
                    else
                    {
                        _emitter.Resume();
                        GD.Print("Audio resumed");
                    }
                }
            }
            
            // Press S to stop
            if (keyEvent.Keycode == Key.S)
            {
                if (_emitter != null)
                {
                    _emitter.Stop();
                    GD.Print("Audio stopped");
                }
            }
            
            // Press R to restart
            if (keyEvent.Keycode == Key.R)
            {
                if (_emitter != null)
                {
                    _emitter.Stop();
                    _emitter.Play();
                    GD.Print("Audio restarted");
                }
            }
        }
    }

    public override void _ExitTree()
    {
        // Cleanup is handled automatically by FmodEventEmitter3D
        GD.Print("Spatial audio example cleaned up");
    }
}
