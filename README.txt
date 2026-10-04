FMOD Sharp (fmod-gdextension-sharp)

C# wrapper for the FMOD GDExtension for Godot 4.x.
https://github.com/utopia-rise/fmod-gdextension

Latest release: https://github.com/straussna/fmod-gdextension-sharp/releases/latest


REQUIREMENTS

- Godot .NET (Mono) build
- utopia-rise/fmod-gdextension installed in your project
- FMOD Studio banks exported for your project


INSTALLATION

1. Install the FMOD GDExtension following its instructions.
2. Copy addons/fmod-sharp into your project's res://addons/ directory.
3. Enable the "FMOD Sharp" plugin in Project > Project Settings > Plugins.


USAGE

    FmodServerWrapper.LoadBank("res://Master.bank");
    FmodServerWrapper.LoadBank("res://Master.strings.bank");

    FmodServerWrapper.PlayOneShot("event:/SFX/Explosion");

    var fmodEvent = FmodServerWrapper.CreateEventInstance("event:/Music/Loop");
    AddChild(fmodEvent);
    fmodEvent.Start();
    fmodEvent.Stop(immediate: false);

    FmodServerWrapper.SetGlobalParameterByName("TimeOfDay", 18.0f);

See addons/fmod-sharp/examples/ for more.


LICENSE

MIT. See LICENSE.


CREDITS

- FMOD Studio, Firelight Technologies: https://www.fmod.com/
- utopia-rise/fmod-gdextension: https://github.com/utopia-rise/fmod-gdextension
