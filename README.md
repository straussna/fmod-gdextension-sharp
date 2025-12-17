# FMOD GDExtension Sharp

A C# wrapper for FMOD audio integration in Godot 4.x, designed to work with the GDExtension by utopia-rise.

## Overview

This addon provides a pure C# interface for integrating FMOD Studio audio into your Godot 4 projects. It offers a high-level API for:

- Playing FMOD events (2D and 3D)
- Managing audio parameters
- Controlling buses and mix groups
- Spatial audio with automatic position updates
- Global audio parameter management

## Installation

1. Copy the `addons/fmod-gdextension-sharp` folder to your Godot project's `addons/` directory
2. Open your project in Godot
3. Go to Project > Project Settings > Plugins
4. Enable "FMOD GDExtension Sharp"

The addon will automatically add an autoload singleton called `FmodManager` that you can access from any script.

## Requirements

- Godot 4.3 or later with .NET support
- .NET 8.0 SDK
- FMOD Studio (for creating audio banks)
- FMOD GDExtension (utopia-rise) installed in your project

## Quick Start

### Playing a Simple Event

```csharp
using FmodGDExtensionSharp;

public partial class MyScript : Node
{
    public override void _Ready()
    {
        // Play a music event
        FmodManager.Instance.PlayEvent("event:/Music/MainTheme");
        
        // Play a sound effect
        FmodManager.Instance.PlayEvent("event:/SFX/Explosion");
    }
}
```

### Playing Events in 3D Space

```csharp
// Play at a specific position
Vector3 position = new Vector3(10, 0, 5);
FmodManager.Instance.PlayEventAtPosition("event:/SFX/Gunshot", position);

// Or use the FmodEventEmitter3D component
var emitter = new FmodEventEmitter3D
{
    EventPath = "event:/Ambience/Wind",
    AutoPlay = true
};
AddChild(emitter);
```

### Setting Parameters

```csharp
// Set an event parameter
var musicEvent = FmodManager.Instance.PlayEvent("event:/Music/Combat");
musicEvent.SetParameter("Intensity", 0.8f);

// Set a global parameter
FmodManager.Instance.SetGlobalParameter("TimeOfDay", 18.0f);
```

### Controlling Buses

```csharp
// Adjust bus volumes
FmodManager.Instance.SetBusVolume("bus:/Music", 0.7f);
FmodManager.Instance.SetBusVolume("bus:/SFX", 1.0f);

// Pause a bus
FmodManager.Instance.SetBusPaused("bus:/Music", true);
```

## Core Classes

### FmodManager

The main singleton class for managing FMOD. Accessible via `FmodManager.Instance`.

**Key Methods:**
- `PlayEvent(string eventPath)` - Play an event
- `PlayEventAtPosition(string eventPath, Vector3 position)` - Play event at 3D position
- `StopEvent(string eventPath, bool immediate)` - Stop an event
- `SetGlobalParameter(string name, float value)` - Set global parameter
- `SetBusVolume(string busPath, float volume)` - Control bus volume
- `SetBusPaused(string busPath, bool paused)` - Pause/unpause bus

### FmodEvent

Represents an instance of an FMOD event with full playback control.

**Key Methods:**
- `Play()` - Start playback
- `Stop(bool immediate)` - Stop playback
- `Pause()` / `Resume()` - Pause/resume playback
- `SetParameter(string name, float value)` - Set event parameter
- `Set3DAttributes(Vector3 position)` - Update 3D position
- `SetVolume(float volume)` - Adjust event volume

### FmodEventEmitter3D / FmodEventEmitter2D

Node components for playing FMOD events attached to game objects. Automatically updates position and velocity.

**Properties:**
- `EventPath` - The FMOD event to play
- `AutoPlay` - Start playing when node enters tree
- `StopOnExit` - Stop when node exits tree

### FmodBus

Represents an FMOD bus for controlling groups of events.

**Properties:**
- `Volume` - Bus volume (0.0 to 1.0)
- `IsMuted` - Mute state
- `IsPaused` - Pause state

## Examples

Check the `examples/` folder for complete working examples:

- `BasicExample.cs` - Basic event playback and parameter control
- `SpatialAudioExample.cs` - 3D audio with moving sound sources

## Architecture

This addon is designed as a pure C# wrapper around the FMOD GDExtension. The C# classes provide:

1. **High-level API** - Easy-to-use methods for common audio tasks
2. **Type safety** - Full C# type checking and IntelliSense support
3. **Godot integration** - Works seamlessly with Godot's node system
4. **No C/C++ required** - Pure C# implementation

## Development Status

This is the initial structure for the addon. The core classes and API are in place, ready for integration with the actual FMOD GDExtension native bindings.

**Current Status:**
- ✅ Core class structure
- ✅ C# API design
- ✅ Plugin system integration
- ✅ Example scripts
- ⏳ FMOD native bindings (requires FMOD GDExtension)

## Contributing

Contributions are welcome! Please feel free to submit pull requests or open issues for bugs and feature requests.

## License

See [LICENSE](LICENSE) file for details.

## Credits

- FMOD Studio by Firelight Technologies
- GDExtension wrapper by utopia-rise
- This C# wrapper by straussna
