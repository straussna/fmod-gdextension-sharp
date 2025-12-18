# FMOD Sharp (fmod-gdextension-sharp)

C# wrapper for the FMOD GDExtension for Godot 4.x. This addon provides a managed, type-safe C# API that wraps the GDScript API exposed by the `utopia-rise/fmod-gdextension` project, enabling easy integration of FMOD Studio audio (events, buses, parameters, spatial audio) into Godot projects using C#.

- Project: https://github.com/straussna/fmod-gdextension-sharp
- GDExtension dependency: https://github.com/utopia-rise/fmod-gdextension

## Key features

- Create and control FMOD event instances from C# (`FmodEvent`).
- Play one-shot events and attach them to Godot nodes.
- Manage banks, buses, VCAs, and global parameters through `FmodServerWrapper`.
- Support for 2D and 3D positional audio with automatic transform updates.
- Example scenes and scripts demonstrating common workflows.

## Requirements

- Godot 4.3 or later with .NET support enabled.
- .NET SDK compatible with the project (project targets .NET 10).
- FMOD Studio (for building banks) and FMOD banks exported for use in your project.
- The upstream GDExtension `utopia-rise/fmod-gdextension` must be installed in the project. This addon is a wrapper and depends on that extension at runtime.

## Installation

1. Clone or download this repository and copy its `addons/fmod-gdextension-sharp` folder into your Godot project's `res://addons/` directory.

2. Install the required GDExtension (prerequisite):
   - Install `utopia-rise/fmod-gdextension` following its instructions.
   - The GDExtension provides the native bindings and the `FmodServer` singleton that this C# wrapper calls into.

3. Open the Godot project.

4. In the Godot editor, go to `Project` → `Project Settings` → `Plugins` and enable the `FMOD Sharp` plugin.
   - Enabling the plugin registers any runtime/autoload hooks defined by the plugin. The wrapper will attempt to resolve the `FmodServer` singleton at runtime and will log an error if the GDExtension is missing.

5. Place your FMOD banks (e.g. `Master.bank`, `Master.strings.bank`, etc.) in the project and load them via the wrapper or examples.

## Usage

This addon exposes a thin C# wrapper around the GDScript API. Typical usage patterns:

- Loading banks and initializing (example):

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

See the `addons/fmod-gdextension-sharp/examples/` folder for complete example scripts and usage patterns.

## API summary

Primary entry points provided by this addon:

- `FmodServerWrapper` — static wrappers for the GDScript `FmodServer` singleton. Use for loading banks, querying events, playing one-shots, controlling buses and global parameters.
- `FmodEvent` — Node wrapper for an FMOD event instance with lifecycle and transform-following behavior for positional audio.
- Example components (in `examples/`) demonstrating event playback and spatial audio integration.

Note: The wrapper forwards calls to the underlying GDScript implementation. If the `FmodServer` singleton is not available at runtime, the wrapper will log errors — this indicates the `utopia-rise/fmod-gdextension` dependency is not installed or initialized.

## Troubleshooting

- Error: `FmodWrapper: FmodServer singleton not found` — Install and enable the upstream `fmod-gdextension` GDExtension in `res://addons/fmod-gdextension` and restart the project.
- If banks fail to load, verify paths are correct and banks were exported from FMOD Studio.
- For C# compilation/runtime issues, confirm the project .NET target matches your installed SDK and the Godot editor Mono/.NET configuration.

## Examples

The `addons/fmod-gdextension-sharp/examples/` directory contains sample scripts demonstrating how to load banks, create event instances, and play one-shot events. Use these as a starting point.

## Contributing

Contributions, bug reports, and pull requests are welcome. Please:

1. Open issues for bugs or feature requests.
2. Target pull requests at the `main` branch and provide clear descriptions and test steps.
3. Keep API changes backward compatible where possible; use semantic versioning for releases.

## License

This repository is distributed under the `MIT` license. See the `LICENSE` file for details.

## Credits

- FMOD Studio — Firelight Technologies
- `utopia-rise/fmod-gdextension` — native GDExtension providing FMOD bindings for Godot
- This C# wrapper — `straussna`

