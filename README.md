# FMOD Sharp (fmod-gdextension-sharp)

C# wrapper for the FMOD GDExtension for Godot 4.x. This addon provides a managed, type-safe C# API that wraps the GDScript API exposed by the `utopia-rise/fmod-gdextension` project, enabling easy integration of FMOD Studio audio (events, buses, parameters, spatial audio) into Godot projects using C#.

- GDExtension dependency: https://github.com/utopia-rise/fmod-gdextension
- Release (v1.0.0): https://github.com/straussna/fmod-gdextension-sharp/releases/tag/1.0.0

## Key features

- Create and control FMOD event instances from C# (`FmodEvent`).
- Play one-shot events and attach them to Godot nodes.
- Manage banks, buses, VCAs, and global parameters through `FmodServerWrapper`.
- Support for 2D and 3D positional audio with automatic transform updates.
- Example scripts demonstrating common workflows are provided in `addons/fmod-sharp/examples/`.

## Requirements

- Godot editor built/run with .NET (Mono) enabled to compile and run the C# editor plugin.
- FMOD Studio (for building banks) and FMOD banks exported for use in your project.
- The upstream GDExtension https://github.com/utopia-rise/fmod-gdextension must be installed in the project. This addon is a C# wrapper and depends on that extension at runtime.

## Installation

1. Copy `addons/fmod-sharp` into your Godot project's `res://addons/` directory.

2. Install the required GDExtension (prerequisite):
   - Follow the installation instructions for https://github.com/utopia-rise/fmod-gdextension and place it under `res://addons/fmod-gdextension`.
   - The GDExtension provides the native bindings and the `FmodServer` singleton that this C# wrapper forwards to.

3. In the Godot editor, go to `Project` → `Project Settings` → `Plugins` and enable the `FMOD Sharp` plugin.
   - When enabled in the Mono editor, the plugin attempts to register the `FmodServerWrapper` autoload entry pointing to `res://addons/fmod-sharp/src/FmodServerWrapper.cs`. On plugin disable or when the plugin exits, it will attempt to remove the autoload entry it created.

4. If for some reason the FmodServerWrapper autoload was not added automatically:
   - Open `Project` → `Project Settings` → `Autoload` and add an entry:
     - Name: `FmodServerWrapper`
     - Path: `res://addons/fmod-sharp/src/FmodServerWrapper.cs`

5. Place your FMOD banks (e.g. `Master.bank`, `Master.strings.bank`, etc.) in the project and load them via the wrapper or example scripts.

## Usage

This addon exposes a thin C# wrapper around the GDScript API exposed by the GDExtension. Typical usage patterns:

- Loading banks and initializing (usually done in a separate autoload):

```csharp
// Load banks (see examples/ for a full example)
FmodServerWrapper.LoadBank("res://Master.bank");
FmodServerWrapper.LoadBank("res://Master.strings.bank");
```

- Playing a one-shot event:

```csharp
FmodServerWrapper.PlayOneShot("event:/SFX/Explosion");
```

- Creating and attaching an event instance so it follows a Node2D/Node3D transform:

```csharp
var fmodEvent = FmodServerWrapper.CreateEventInstance("event:/Music/Loop");
AddChild(fmodEvent); // ensures FmodEvent updates its transform from this node's parent
fmodEvent.Start();

// Stop with fadeout
fmodEvent.Stop(immediate: false);
```

- Controlling global parameters and buses:

```csharp
FmodServerWrapper.SetGlobalParameterByName("TimeOfDay", 18.0f);
FmodServerWrapper.SetDriver(0);
FmodServerWrapper.SetListenerNumber(1);
```

See the `addons/fmod-sharp/examples/` folder for complete example scripts and usage patterns.

## Contributing

Contributions, bug reports, and pull requests are welcome!

1. Open issues for bugs or feature requests.
2. Target pull requests at the `main` branch and provide clear descriptions and test steps.
3. Keep API changes backward compatible where possible; use semantic versioning for releases.

## License

This repository is distributed under the `MIT` license. See the `LICENSE` file for details.

## Credits

- FMOD Studio — Firelight Technologies
- https://github.com/utopia-rise/fmod-gdextension — GDExtension providing FMOD bindings for Godot
- This C# wrapper — `straussna`

