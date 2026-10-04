using System;
using System.Collections.Generic;
using Godot;

namespace FmodSharp.Examples;

/// <summary>Example node that loads banks, plays an event that follows the node,
/// and plays a one-shot when ui_accept is pressed.</summary>
public partial class FmodEventsExample : Node2D
{
    private readonly List<FmodBank> _loadedBanks = [];

    /// <inheritdoc/>
    public override void _Ready()
    {
        LoadBanks();

        var eventInstance = FmodServerWrapper.CreateEventInstance("event:/example_path");
        if (eventInstance == null)
        {
            GD.PushError("FmodExample: Failed to create event instance");
            return;
        }

        AddChild(eventInstance);
        eventInstance.Start();

        GD.Print("FmodExample initialized");
    }

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

    /// <inheritdoc/>
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("ui_accept"))
        {
            PlayOneShotOnAccept();
        }
    }

    /// <summary>Plays the example one-shot event; replace the path with a project event.</summary>
    public static void PlayOneShotOnAccept()
    {
        FmodServerWrapper.PlayOneShot("event:/example_path");
        GD.Print("Played one-shot event");
    }
}
