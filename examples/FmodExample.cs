using FmodSharp;
using Godot;
using System;

// Minimal example to attach to a Node in Godot.
// - Loads banks on ready
// - Creates an FMOD event instance and adds it under a Node2D child
// - Plays a one-shot when the "ui_accept" action is pressed

public partial class FmodExample : Node2D
{
    private readonly Godot.Collections.Array _loadedBanks = [];

    public override void _Ready()
    {
        LoadBanks();

        // Create an FMOD event instance (replace the path with your event path)
        var _eventInstance = FmodServerWrapper.CreateEventInstance("event:/example_path");

        // Add the FmodEvent as a child of the attach node so it follows position
        AddChild(_eventInstance);
        _eventInstance.Start();

        GD.Print("FmodExample initialized");
    }

    /// <summary>
    /// Load all required FMOD banks. You should move this to its own AutoLoad singleton in a real project.
    /// </summary>
    private void LoadBanks()
    {
        _loadedBanks.Clear();

        try
        {
            var masterBank = FmodServerWrapper.LoadBank("res://Master.bank", FmodServerWrapper.FMOD_STUDIO_LOAD_BANK_NORMAL);
            if (masterBank != null)
            {
                _loadedBanks.Add(masterBank);
                GD.Print("AudioManager: Loaded Master.bank");
            }

            var stringsBank = FmodServerWrapper.LoadBank("res://Master.strings.bank", FmodServerWrapper.FMOD_STUDIO_LOAD_BANK_NORMAL);
            if (stringsBank != null)
            {
                _loadedBanks.Add(stringsBank);
                GD.Print("AudioManager: Loaded Master.strings.bank");
            }

            var musicBank = FmodServerWrapper.LoadBank("res://music.bank", FmodServerWrapper.FMOD_STUDIO_LOAD_BANK_NORMAL);
            if (musicBank != null)
            {
                _loadedBanks.Add(musicBank);
                GD.Print("AudioManager: Loaded music.bank");
            }

            var sfxBank = FmodServerWrapper.LoadBank("res://sfx.bank", FmodServerWrapper.FMOD_STUDIO_LOAD_BANK_NORMAL);
            if (sfxBank != null)
            {
                _loadedBanks.Add(sfxBank);
                GD.Print("AudioManager: Loaded sfx.bank");
            }

            GD.Print($"AudioManager: Successfully loaded {_loadedBanks.Count} banks");
        }
        catch (Exception ex)
        {
            GD.PushError($"AudioManager: Error loading banks: {ex.Message}");
        }
    }


    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("ui_accept"))
        {
            PlayOneShotOnAccept();
        }
    }

    // Public method to play a one-shot (replace path with your oneshot event)
    public void PlayOneShotOnAccept()
    {
        FmodServerWrapper.PlayOneShot("event:/example_path");
        GD.Print("Played one-shot event");
    }
}
