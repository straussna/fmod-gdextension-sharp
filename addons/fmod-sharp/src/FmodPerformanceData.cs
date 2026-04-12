using Godot;

namespace FmodSharp;

/// <summary>
/// Wrapper for FMOD performance data, providing CPU usage, memory allocation,
/// and I/O statistics. All properties are read-only snapshots from the last
/// <see cref="FmodServerWrapper.GetPerformanceData"/> call.
/// </summary>
public class FmodPerformanceData(GodotObject perfInstance)
{
    /// <summary>
    /// The underlying FMOD performance data GodotObject for advanced usage.
    /// </summary>
    public GodotObject FmodInstance { get; } = perfInstance ?? throw new ArgumentNullException(nameof(perfInstance));

    // CPU usage (float, percentage)

    /// <summary>DSP engine CPU usage.</summary>
    public float Dsp => FmodInstance.Get("dsp").AsSingle();

    /// <summary>Geometry processing CPU usage.</summary>
    public float Geometry => FmodInstance.Get("geometry").AsSingle();

    /// <summary>Stream decoding CPU usage.</summary>
    public float Stream => FmodInstance.Get("stream").AsSingle();

    /// <summary>FMOD update CPU usage.</summary>
    public float Update => FmodInstance.Get("update").AsSingle();

    /// <summary>Convolution reverb processing CPU usage (slot 1).</summary>
    public float Convolution1 => FmodInstance.Get("convolution1").AsSingle();

    /// <summary>Convolution reverb processing CPU usage (slot 2).</summary>
    public float Convolution2 => FmodInstance.Get("convolution2").AsSingle();

    /// <summary>FMOD Studio CPU usage.</summary>
    public float Studio => FmodInstance.Get("studio").AsSingle();

    // Memory allocation (int, bytes)

    /// <summary>Currently allocated memory in bytes.</summary>
    public int CurrentlyAllocated => FmodInstance.Get("currently_allocated").AsInt32();

    /// <summary>Peak allocated memory in bytes.</summary>
    public int MaxAllocated => FmodInstance.Get("max_allocated").AsInt32();

    // I/O (int, bytes)

    /// <summary>Sample data bytes read.</summary>
    public int SampleBytesRead => FmodInstance.Get("sample_bytes_read").AsInt32();

    /// <summary>Stream data bytes read.</summary>
    public int StreamBytesRead => FmodInstance.Get("stream_bytes_read").AsInt32();

    /// <summary>Other data bytes read.</summary>
    public int OtherBytesRead => FmodInstance.Get("other_bytes_read").AsInt32();
}
