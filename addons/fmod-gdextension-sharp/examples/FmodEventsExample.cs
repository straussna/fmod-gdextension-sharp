using FmodSharp;
using Godot;
using System;

/// <summary>
/// Example Godot `Node2D` demonstrating basic FMOD usage.
/// - Loads banks on ready.
/// - Creates an FMOD event instance and adds it as a child so it follows the node's position.
/// - Plays a one-shot when the "ui_accept" action is pressed.
/// </summary>
public partial class FmodEventsExample : Node2D
{
    private readonly Godot.Collections.Array _loadedBanks = [];

    public override void _Ready()
    {
        LoadBanks();

        // Create an FMOD event instance and add it as a child so it follows this node's transform.
        var _eventInstance = FmodServerWrapper.CreateEventInstance("event:/example_path");

        AddChild(_eventInstance);
        _eventInstance.Start();

        GD.Print("FmodExample initialized");
    }

    /// <summary>
    /// Load required FMOD banks. In a production project, consider moving bank
    /// loading to a dedicated AutoLoad singleton.
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

    /// <summary>
    /// Play a one-shot event. Replace the event path with your project's event.
    /// </summary>
    public void PlayOneShotOnAccept()
    {
        FmodServerWrapper.PlayOneShot("event:/example_path");
        GD.Print("Played one-shot event");
    }
}
