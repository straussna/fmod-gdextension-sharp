# FMOD Sharp (fmod-gdextension-sharp)

C# wrapper for the [FMOD GDExtension](https://github.com/utopia-rise/fmod-gdextension) for Godot 4.x.

[Latest Release](https://github.com/straussna/fmod-gdextension-sharp/releases/latest)

## Requirements

- Godot .NET (Mono) build
- [utopia-rise/fmod-gdextension](https://github.com/utopia-rise/fmod-gdextension) installed in your project
- FMOD Studio banks exported for your project

## Installation

1. Install the [FMOD GDExtension](https://github.com/utopia-rise/fmod-gdextension) following its instructions.
2. Copy `addons/fmod-sharp` into your project's `res://addons/` directory.
3. Enable the **FMOD Sharp** plugin in `Project → Project Settings → Plugins`.

## Usage

```csharp
// Load banks
FmodServerWrapper.LoadBank("res://Master.bank");
FmodServerWrapper.LoadBank("res://Master.strings.bank");

// One-shot event
FmodServerWrapper.PlayOneShot("event:/SFX/Explosion");

// Create an event instance with positional audio (2D or 3D)
var fmodEvent = FmodServerWrapper.CreateEventInstance("event:/Music/Loop");
AddChild(fmodEvent);
fmodEvent.Start();
fmodEvent.Stop(immediate: false);

// Global parameters
FmodServerWrapper.SetGlobalParameterByName("TimeOfDay", 18.0f);
```

See `addons/fmod-sharp/examples/` for more.

## License

MIT — see `LICENSE`.

## Credits

- [FMOD Studio](https://www.fmod.com/) — Firelight Technologies
- [utopia-rise/fmod-gdextension](https://github.com/utopia-rise/fmod-gdextension)
