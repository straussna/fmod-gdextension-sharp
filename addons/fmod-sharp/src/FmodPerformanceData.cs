using System;
using Godot;

namespace FmodSharp;

/// <summary>
/// Wrapper for FMOD performance data, providing CPU usage, memory allocation,
/// and I/O statistics. All properties are read-only snapshots from the last
/// <see cref="FmodServerWrapper.GetPerformanceData"/> call.
/// </summary>
public class FmodPerformanceData
{
    private readonly GodotObject _perfInstance;

    /// <summary>
    /// The underlying FMOD performance data GodotObject for advanced usage.
    /// </summary>
    public GodotObject FmodInstance => _perfInstance;

    // CPU usage (float, percentage)

    /// <summary>DSP engine CPU usage.</summary>
    public float Dsp => _perfInstance.Get("dsp").AsSingle();

    /// <summary>Geometry processing CPU usage.</summary>
    public float Geometry => _perfInstance.Get("geometry").AsSingle();

    /// <summary>Stream decoding CPU usage.</summary>
    public float Stream => _perfInstance.Get("stream").AsSingle();

    /// <summary>FMOD update CPU usage.</summary>
    public float Update => _perfInstance.Get("update").AsSingle();

    /// <summary>Convolution reverb processing CPU usage (slot 1).</summary>
    public float Convolution1 => _perfInstance.Get("convolution1").AsSingle();

    /// <summary>Convolution reverb processing CPU usage (slot 2).</summary>
    public float Convolution2 => _perfInstance.Get("convolution2").AsSingle();

    /// <summary>FMOD Studio CPU usage.</summary>
    public float Studio => _perfInstance.Get("studio").AsSingle();

    // Memory allocation (int, bytes)

    /// <summary>Currently allocated memory in bytes.</summary>
    public int CurrentlyAllocated => _perfInstance.Get("currently_allocated").AsInt32();

    /// <summary>Peak allocated memory in bytes.</summary>
    public int MaxAllocated => _perfInstance.Get("max_allocated").AsInt32();

    // I/O (int, bytes)

    /// <summary>Sample data bytes read.</summary>
    public int SampleBytesRead => _perfInstance.Get("sample_bytes_read").AsInt32();

    /// <summary>Stream data bytes read.</summary>
    public int StreamBytesRead => _perfInstance.Get("stream_bytes_read").AsInt32();

    /// <summary>Other data bytes read.</summary>
    public int OtherBytesRead => _perfInstance.Get("other_bytes_read").AsInt32();

    public FmodPerformanceData(GodotObject perfInstance)
    {
        _perfInstance = perfInstance ?? throw new ArgumentNullException(nameof(perfInstance));
    }
}
