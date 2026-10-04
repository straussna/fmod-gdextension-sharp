FMOD Sharp - typed C# API for the FMOD GDExtension in Godot 4 .NET.

SETUP
  1. Install utopia-rise/fmod-gdextension: https://github.com/utopia-rise/fmod-gdextension
  2. Copy addons/fmod-sharp into your project.
  3. Enable "FMOD Sharp" in Project Settings > Plugins. This adds the FmodServerWrapper autoload.

USAGE (namespace FmodSharp)
  FmodServerWrapper.LoadBank("res://Master.bank");
  FmodServerWrapper.LoadBank("res://Master.strings.bank");

  FmodServerWrapper.PlayOneShot("event:/SFX/Explosion");
  FmodServerWrapper.PlayOneShotAttached("event:/SFX/Step", this);

  var music = FmodServerWrapper.CreateEventInstance("event:/Music/Loop");
  AddChild(music);   // follows a Node2D/Node3D parent; released when it leaves the tree
  music.Start();
  music.SetParameterByName("Intensity", 0.8f);
  music.Stop();      // Stop(immediate: true) cuts without fade-out

  FmodServerWrapper.GetBus("bus:/SFX")!.Volume = 0.5f;
  FmodServerWrapper.GetVca("vca:/Music")!.Volume = 0.5f;
  FmodServerWrapper.SetGlobalParameterByName("TimeOfDay", 18f);

  Methods that create or look up FMOD objects return null and log an error on failure.
  Flag and enum constants (FMOD_STUDIO_*) are on FmodServerWrapper.
  Full example: addons/fmod-sharp/examples/FmodEventsExample.cs

MIT license. FMOD Studio by Firelight Technologies.
