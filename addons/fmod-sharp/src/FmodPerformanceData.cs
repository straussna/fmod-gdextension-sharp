using System;
using Godot;

namespace FmodSharp;

/// <summary>Snapshot of FMOD CPU, memory and I/O statistics from <see cref="FmodServerWrapper.GetPerformanceData"/>.</summary>
public class FmodPerformanceData(GodotObject perfInstance)
{
    /// <summary>The underlying FMOD performance data object.</summary>
    public GodotObject FmodInstance { get; } = perfInstance ?? throw new ArgumentNullException(nameof(perfInstance));

    /// <summary>DSP engine CPU usage, in percent.</summary>
    public float Dsp => FmodInstance.Get("dsp").AsSingle();

    /// <summary>Geometry processing CPU usage, in percent.</summary>
    public float Geometry => FmodInstance.Get("geometry").AsSingle();

    /// <summary>Stream decoding CPU usage, in percent.</summary>
    public float Stream => FmodInstance.Get("stream").AsSingle();

    /// <summary>FMOD update CPU usage, in percent.</summary>
    public float Update => FmodInstance.Get("update").AsSingle();

    /// <summary>Convolution reverb slot 1 CPU usage, in percent.</summary>
    public float Convolution1 => FmodInstance.Get("convolution1").AsSingle();

    /// <summary>Convolution reverb slot 2 CPU usage, in percent.</summary>
    public float Convolution2 => FmodInstance.Get("convolution2").AsSingle();

    /// <summary>FMOD Studio CPU usage, in percent.</summary>
    public float Studio => FmodInstance.Get("studio").AsSingle();

    /// <summary>Currently allocated memory, in bytes.</summary>
    public int CurrentlyAllocated => FmodInstance.Get("currently_allocated").AsInt32();

    /// <summary>Peak allocated memory, in bytes.</summary>
    public int MaxAllocated => FmodInstance.Get("max_allocated").AsInt32();

    /// <summary>Sample data read, in bytes.</summary>
    public int SampleBytesRead => FmodInstance.Get("sample_bytes_read").AsInt32();

    /// <summary>Stream data read, in bytes.</summary>
    public int StreamBytesRead => FmodInstance.Get("stream_bytes_read").AsInt32();

    /// <summary>Other data read, in bytes.</summary>
    public int OtherBytesRead => FmodInstance.Get("other_bytes_read").AsInt32();
}
