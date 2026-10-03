using System;
using Godot;

namespace FmodSharp;

/// <summary>Static C# access to the FmodServer singleton of the FMOD GDExtension.
/// The plugin registers it as the FmodServerWrapper autoload.</summary>
public partial class FmodServerWrapper : Node
{
    private static GodotObject _fmodServer = null!;

    private static GodotObject FmodServer
    {
        get
        {
            if (_fmodServer != null)
            {
                return _fmodServer;
            }

            var server = Engine.GetSingleton("FmodServer");
            if (server == null)
            {
                GD.PushError("FmodWrapper: FmodServer singleton not found! Make sure FMOD addon is properly installed and enabled.");
                throw new InvalidOperationException("FmodServer singleton not found");
            }

            _fmodServer = server;
            return _fmodServer;
        }
    }

    #region FMOD Constants
    /// <summary>Core init flag: use a right-handed 3D coordinate system.</summary>
    public const int FMOD_INIT_3D_RIGHTHANDED = 4;
    /// <summary>Core init flag: apply a distance-based low-pass filter to 3D channels.</summary>
    public const int FMOD_INIT_CHANNEL_DISTANCEFILTER = 512;
    /// <summary>Core init flag: enable the per-channel low-pass filter.</summary>
    public const int FMOD_INIT_CHANNEL_LOWPASS = 256;
    /// <summary>Core init flag: use the closest geometry polygon for occlusion.</summary>
    public const int FMOD_INIT_GEOMETRY_USECLOSEST = 262144;
    /// <summary>Core init flag: mix from the update call instead of a mixer thread.</summary>
    public const int FMOD_INIT_MIX_FROM_UPDATE = 2;
    /// <summary>Core init flag: default initialization.</summary>
    public const int FMOD_INIT_NORMAL = 0;
    /// <summary>Core init flag: prefer Dolby Pro Logic II downmixing.</summary>
    public const int FMOD_INIT_PREFER_DOLBY_DOWNMIX = 524288;
    /// <summary>Core init flag: enable the profiler connection.</summary>
    public const int FMOD_INIT_PROFILE_ENABLE = 65536;
    /// <summary>Core init flag: enable level metering on every DSP.</summary>
    public const int FMOD_INIT_PROFILE_METER_ALL = 2097152;
    /// <summary>Core init flag: decode streams from the update call instead of a stream thread.</summary>
    public const int FMOD_INIT_STREAM_FROM_UPDATE = 1;
    /// <summary>Core init flag: disable internal thread safety.</summary>
    public const int FMOD_INIT_THREAD_UNSAFE = 1048576;
    /// <summary>Core init flag: virtualize channels whose volume reaches zero.</summary>
    public const int FMOD_INIT_VOL0_BECOMES_VIRTUAL = 131072;

    /// <summary>Studio init flag: default initialization.</summary>
    public const int FMOD_STUDIO_INIT_NORMAL = 0;
    /// <summary>Studio init flag: enable Live Update connections from FMOD Studio.</summary>
    public const int FMOD_STUDIO_INIT_LIVEUPDATE = 1;
    /// <summary>Studio init flag: load banks even when plugins they reference are missing.</summary>
    public const int FMOD_STUDIO_INIT_ALLOW_MISSING_PLUGINS = 2;
    /// <summary>Studio init flag: run Studio updates on the calling thread.</summary>
    public const int FMOD_STUDIO_INIT_SYNCHRONOUS_UPDATE = 4;
    /// <summary>Studio init flag: defer callbacks to the next update.</summary>
    public const int FMOD_STUDIO_INIT_DEFERRED_CALLBACKS = 8;
    /// <summary>Studio init flag: load banks from the update call instead of a loading thread.</summary>
    public const int FMOD_STUDIO_INIT_LOAD_FROM_UPDATE = 16;

    /// <summary>Speaker mode: 5.1 surround.</summary>
    public const int FMOD_SPEAKERMODE_5POINT1 = 6;
    /// <summary>Speaker mode: 7.1 surround.</summary>
    public const int FMOD_SPEAKERMODE_7POINT1 = 7;
    /// <summary>Speaker mode: 7.1.4 surround with height speakers.</summary>
    public const int FMOD_SPEAKERMODE_7POINT1POINT4 = 8;
    /// <summary>Speaker mode: the output device's default.</summary>
    public const int FMOD_SPEAKERMODE_DEFAULT = 0;
    /// <summary>Number of speaker modes.</summary>
    public const int FMOD_SPEAKERMODE_MAX = 9;
    /// <summary>Speaker mode: mono.</summary>
    public const int FMOD_SPEAKERMODE_MONO = 2;
    /// <summary>Speaker mode: quad.</summary>
    public const int FMOD_SPEAKERMODE_QUAD = 4;
    /// <summary>Speaker mode: raw channels with no speaker mapping.</summary>
    public const int FMOD_SPEAKERMODE_RAW = 1;
    /// <summary>Speaker mode: stereo.</summary>
    public const int FMOD_SPEAKERMODE_STEREO = 3;
    /// <summary>Speaker mode: 5.0 surround.</summary>
    public const int FMOD_SPEAKERMODE_SURROUND = 5;

    /// <summary>Bank load flag: load synchronously.</summary>
    public const int FMOD_STUDIO_LOAD_BANK_NORMAL = 0;
    /// <summary>Bank load flag: load asynchronously.</summary>
    public const int FMOD_STUDIO_LOAD_BANK_NONBLOCKING = 1;
    /// <summary>Bank load flag: decompress sample data into memory on load.</summary>
    public const int FMOD_STUDIO_LOAD_BANK_DECOMPRESS_SAMPLES = 2;

    /// <summary>Sound mode: ignore 3D positioning.</summary>
    public const int FMOD_2D = 8;
    /// <summary>Sound mode: use 3D positioning.</summary>
    public const int FMOD_3D = 16;
    /// <summary>Sound mode: use a custom rolloff curve.</summary>
    public const int FMOD_3D_CUSTOMROLLOFF = 67108864;
    /// <summary>Sound mode: position relative to the listener.</summary>
    public const int FMOD_3D_HEADRELATIVE = 262144;
    /// <summary>Sound mode: skip geometry occlusion.</summary>
    public const int FMOD_3D_IGNOREGEOMETRY = 1073741824;
    /// <summary>Sound mode: inverse distance rolloff.</summary>
    public const int FMOD_3D_INVERSEROLLOFF = 1048576;
    /// <summary>Sound mode: inverse rolloff tapering to silence at max distance.</summary>
    public const int FMOD_3D_INVERSETAPEREDROLLOFF = 8388608;
    /// <summary>Sound mode: linear rolloff.</summary>
    public const int FMOD_3D_LINEARROLLOFF = 2097152;
    /// <summary>Sound mode: linear-squared rolloff.</summary>
    public const int FMOD_3D_LINEARSQUAREROLLOFF = 4194304;
    /// <summary>Sound mode: position in world space.</summary>
    public const int FMOD_3D_WORLDRELATIVE = 524288;

    /// <summary>Sound mode: compute an exact length for compressed formats.</summary>
    public const int FMOD_ACCURATETIME = 16384;
    /// <summary>Sound mode: keep sample data compressed in memory.</summary>
    public const int FMOD_CREATECOMPRESSEDSAMPLE = 512;
    /// <summary>Sound mode: decompress the whole sound into memory.</summary>
    public const int FMOD_CREATESAMPLE = 256;
    /// <summary>Sound mode: stream the sound from its source.</summary>
    public const int FMOD_CREATESTREAM = 128;
    /// <summary>Sound mode: default settings.</summary>
    public const int FMOD_DEFAULT = 0;
    /// <summary>Sound mode: skip reading tags.</summary>
    public const int FMOD_IGNORETAGS = 33554432;
    /// <summary>Sound mode: loop back and forth.</summary>
    public const int FMOD_LOOP_BIDI = 4;
    /// <summary>Sound mode: loop forward.</summary>
    public const int FMOD_LOOP_NORMAL = 2;
    /// <summary>Sound mode: play once.</summary>
    public const int FMOD_LOOP_OFF = 1;
    /// <summary>Sound mode: drop non-essential data to save memory.</summary>
    public const int FMOD_LOWMEM = 134217728;
    /// <summary>Sound mode: scan MPEG data for a valid frame when opening.</summary>
    public const int FMOD_MPEGSEARCH = 32768;
    /// <summary>Sound mode: open asynchronously.</summary>
    public const int FMOD_NONBLOCKING = 65536;
    /// <summary>Sound mode: open from a copy of a memory buffer.</summary>
    public const int FMOD_OPENMEMORY = 2048;
    /// <summary>Sound mode: open from a memory buffer without copying it.</summary>
    public const int FMOD_OPENMEMORY_POINT = 268435456;
    /// <summary>Sound mode: open without pre-buffering.</summary>
    public const int FMOD_OPENONLY = 8192;
    /// <summary>Sound mode: treat the data as raw PCM.</summary>
    public const int FMOD_OPENRAW = 4096;
    /// <summary>Sound mode: create an empty user sound.</summary>
    public const int FMOD_OPENUSER = 1024;
    /// <summary>Sound mode: allow only one instance of the sound to play.</summary>
    public const int FMOD_UNIQUE = 131072;
    /// <summary>Sound mode: restart from the beginning when becoming real.</summary>
    public const long FMOD_VIRTUAL_PLAYFROMSTART = 2147483648;

    /// <summary>Stop mode: allow AHDSR fade-out.</summary>
    public const int FMOD_STUDIO_STOP_ALLOWFADEOUT = 0;
    /// <summary>Stop mode: stop immediately.</summary>
    public const int FMOD_STUDIO_STOP_IMMEDIATE = 1;
    /// <summary>Forces the stop mode type to 32 bits.</summary>
    public const int FMOD_STUDIO_STOP_FORCEINT = 65536;

    /// <summary>System callback: before each Studio update.</summary>
    public const int FMOD_STUDIO_SYSTEM_CALLBACK_PREUPDATE = 1;
    /// <summary>System callback: after each Studio update.</summary>
    public const int FMOD_STUDIO_SYSTEM_CALLBACK_POSTUPDATE = 2;
    /// <summary>System callback: a bank is unloading.</summary>
    public const int FMOD_STUDIO_SYSTEM_CALLBACK_BANK_UNLOAD = 4;
    /// <summary>System callback: Live Update connected.</summary>
    public const int FMOD_STUDIO_SYSTEM_CALLBACK_LIVEUPDATE_CONNECTED = 8;
    /// <summary>System callback: Live Update disconnected.</summary>
    public const int FMOD_STUDIO_SYSTEM_CALLBACK_LIVEUPDATE_DISCONNECTED = 16;
    /// <summary>System callback mask: all system callbacks.</summary>
    public const uint FMOD_STUDIO_SYSTEM_CALLBACK_ALL = 0xFFFFFFFF;

    /// <summary>Event callback: instance created.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_CREATED = 1;
    /// <summary>Event callback: instance destroyed.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_DESTROYED = 2;
    /// <summary>Event callback: instance starting.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_STARTING = 4;
    /// <summary>Event callback: instance started.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_STARTED = 8;
    /// <summary>Event callback: instance restarted.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_RESTARTED = 16;
    /// <summary>Event callback: instance stopped.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_STOPPED = 32;
    /// <summary>Event callback: instance failed to start.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_START_FAILED = 64;
    /// <summary>Event callback: a programmer sound needs creating.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_CREATE_PROGRAMMER_SOUND = 128;
    /// <summary>Event callback: a programmer sound needs destroying.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_DESTROY_PROGRAMMER_SOUND = 256;
    /// <summary>Event callback: a DSP plugin was created.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_PLUGIN_CREATED = 512;
    /// <summary>Event callback: a DSP plugin was destroyed.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_PLUGIN_DESTROYED = 1024;
    /// <summary>Event callback: the timeline passed a marker.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_TIMELINE_MARKER = 2048;
    /// <summary>Event callback: the timeline hit a beat.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_TIMELINE_BEAT = 4096;
    /// <summary>Event callback: a sound started playing.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_SOUND_PLAYED = 8192;
    /// <summary>Event callback: a sound stopped playing.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_SOUND_STOPPED = 16384;
    /// <summary>Event callback: instance became virtual.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_REAL_TO_VIRTUAL = 32768;
    /// <summary>Event callback: instance became real.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_VIRTUAL_TO_REAL = 65536;
    /// <summary>Event callback: a command instrument started an event.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_START_EVENT_COMMAND = 131072;
    /// <summary>Event callback: a nested event's timeline hit a beat.</summary>
    public const int FMOD_STUDIO_EVENT_CALLBACK_NESTED_TIMELINE_BEAT = 262144;
    /// <summary>Event callback mask: all event callbacks.</summary>
    public const uint FMOD_STUDIO_EVENT_CALLBACK_ALL = 0xFFFFFFFF;

    /// <summary>Loading state: unloading.</summary>
    public const int FMOD_STUDIO_LOADING_STATE_UNLOADING = 0;
    /// <summary>Loading state: not loaded.</summary>
    public const int FMOD_STUDIO_LOADING_STATE_UNLOADED = 1;
    /// <summary>Loading state: loading.</summary>
    public const int FMOD_STUDIO_LOADING_STATE_LOADING = 2;
    /// <summary>Loading state: loaded.</summary>
    public const int FMOD_STUDIO_LOADING_STATE_LOADED = 3;
    /// <summary>Loading state: failed to load.</summary>
    public const int FMOD_STUDIO_LOADING_STATE_ERROR = 4;
    /// <summary>Forces the loading state type to 32 bits.</summary>
    public const int FMOD_STUDIO_LOADING_STATE_FORCEINT = 65536;

    /// <summary>Playback state: playing.</summary>
    public const int FMOD_STUDIO_PLAYBACK_PLAYING = 0;
    /// <summary>Playback state: paused on a sustain point.</summary>
    public const int FMOD_STUDIO_PLAYBACK_SUSTAINING = 1;
    /// <summary>Playback state: stopped.</summary>
    public const int FMOD_STUDIO_PLAYBACK_STOPPED = 2;
    /// <summary>Playback state: starting.</summary>
    public const int FMOD_STUDIO_PLAYBACK_STARTING = 3;
    /// <summary>Playback state: fading out before stopping.</summary>
    public const int FMOD_STUDIO_PLAYBACK_STOPPING = 4;
    /// <summary>Forces the playback state type to 32 bits.</summary>
    public const int FMOD_STUDIO_PLAYBACK_FORCEINT = 65536;
    #endregion

    /// <inheritdoc/>
    public override void _Ready()
    {
        _fmodServer = Engine.GetSingleton("FmodServer");

        if (_fmodServer == null)
        {
            GD.PushError("FmodWrapper: FmodServer singleton not found! Make sure FMOD addon is properly installed and enabled.");
            return;
        }

        GD.Print("FmodWrapper initialized successfully");
    }

    #region FMOD API
    /// <summary>Attaches listener <paramref name="index"/> to a node.</summary>
    public static void AddListener(int index, Node gameObj) => FmodServer.Call("add_listener", index, gameObj);

    /// <summary>Returns whether any bank is still loading.</summary>
    public static bool BanksStillLoading()
    {
        var result = FmodServer.Call("banks_still_loading");
        return result.AsBool();
    }

    /// <summary>Returns whether a bus with the GUID exists in the loaded banks.</summary>
    public static bool CheckBusGuid(string guid)
    {
        var result = FmodServer.Call("check_bus_guid", guid);
        return result.AsBool();
    }

    /// <summary>Returns whether a bus with the path exists in the loaded banks.</summary>
    public static bool CheckBusPath(string busPath)
    {
        var result = FmodServer.Call("check_bus_path", busPath);
        return result.AsBool();
    }

    /// <summary>Returns whether an event with the GUID exists in the loaded banks.</summary>
    public static bool CheckEventGuid(string guid)
    {
        var result = FmodServer.Call("check_event_guid", guid);
        return result.AsBool();
    }

    /// <summary>Returns whether an event with the path exists in the loaded banks.</summary>
    public static bool CheckEventPath(string eventPath)
    {
        var result = FmodServer.Call("check_event_path", eventPath);
        return result.AsBool();
    }

    /// <summary>Returns whether a VCA with the GUID exists in the loaded banks.</summary>
    public static bool CheckVcaGuid(string guid)
    {
        var result = FmodServer.Call("check_vca_guid", guid);
        return result.AsBool();
    }

    /// <summary>Returns whether a VCA with the path exists in the loaded banks.</summary>
    public static bool CheckVcaPath(string vcaPath)
    {
        var result = FmodServer.Call("check_vca_path", vcaPath);
        return result.AsBool();
    }

    /// <summary>Creates an event instance from an event path, or null if the path is not loaded.</summary>
    public static FmodEvent? CreateEventInstance(string eventPath)
    {
        if (!ValidateEventPath(eventPath)) return null;
        var result = FmodServer.Call("create_event_instance", eventPath);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: create_event_instance returned null for path '{eventPath}'");
            return null;
        }

        return new FmodEvent(obj);
    }

    /// <summary>Creates an event instance from an event description, or null on failure.</summary>
    public static FmodEvent? CreateEventInstanceFromDescription(GodotObject eventDescription)
    {
        var result = FmodServer.Call("create_event_instance_from_description", eventDescription);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError("FmodWrapper: create_event_instance_from_description returned null");
            return null;
        }

        return new FmodEvent(obj);
    }

    /// <summary>Creates an event instance from an event GUID, or null on failure.</summary>
    public static FmodEvent? CreateEventInstanceWithGuid(string guid)
    {
        var result = FmodServer.Call("create_event_instance_with_guid", guid);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: create_event_instance_with_guid returned null for guid '{guid}'");
            return null;
        }

        return new FmodEvent(obj);
    }

    /// <summary>Creates a sound instance from a loaded file, or null on failure.</summary>
    public static GodotObject? CreateSoundInstance(string path)
    {
        var result = FmodServer.Call("create_sound_instance", path);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: create_sound_instance returned null for path '{path}'");
            return null;
        }

        return obj;
    }

    /// <summary>Returns all loaded banks.</summary>
    public static Godot.Collections.Array GetAllBanks() => (Godot.Collections.Array)FmodServer.Call("get_all_banks");

    /// <summary>Returns all buses in the loaded banks.</summary>
    public static Godot.Collections.Array GetAllBuses() => (Godot.Collections.Array)FmodServer.Call("get_all_buses");

    /// <summary>Returns all event descriptions in the loaded banks.</summary>
    public static Godot.Collections.Array GetAllEventDescriptions() => (Godot.Collections.Array)FmodServer.Call("get_all_event_descriptions");

    /// <summary>Returns all VCAs in the loaded banks.</summary>
    public static Godot.Collections.Array GetAllVca() => (Godot.Collections.Array)FmodServer.Call("get_all_vca");

    /// <summary>Returns the available output drivers.</summary>
    public static Godot.Collections.Array GetAvailableDrivers() => (Godot.Collections.Array)FmodServer.Call("get_available_drivers");

    /// <summary>Returns the bus at the path, or null if not found.</summary>
    public static FmodBus? GetBus(string busPath)
    {
        var result = FmodServer.Call("get_bus", busPath);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_bus returned null for path '{busPath}'");
            return null;
        }

        return new FmodBus(obj);
    }

    /// <summary>Returns the bus with the GUID, or null if not found.</summary>
    public static FmodBus? GetBusFromGuid(string guid)
    {
        var result = FmodServer.Call("get_bus_from_guid", guid);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_bus_from_guid returned null for guid '{guid}'");
            return null;
        }

        return new FmodBus(obj);
    }

    /// <summary>Returns the ID of the current output driver.</summary>
    public static int GetDriver()
    {
        var result = FmodServer.Call("get_driver");
        return result.AsInt32();
    }

    /// <summary>Returns the event description at the path, or null if not loaded.</summary>
    public static GodotObject? GetEvent(string eventPath)
    {
        if (!ValidateEventPath(eventPath)) return null;
        var result = FmodServer.Call("get_event", eventPath);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_event returned null for path '{eventPath}'");
            return null;
        }

        return obj;
    }

    /// <summary>Returns the event description with the GUID, or null if not found.</summary>
    public static GodotObject? GetEventFromGuid(string guid)
    {
        var result = FmodServer.Call("get_event_from_guid", guid);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_event_from_guid returned null for guid '{guid}'");
            return null;
        }

        return obj;
    }

    /// <summary>Returns the GUID of the event at the path, or an empty string if not loaded.</summary>
    public static string GetEventGuid(string eventPath)
    {
        if (!ValidateEventPath(eventPath)) return string.Empty;
        var result = FmodServer.Call("get_event_guid", eventPath);
        return result.AsString();
    }

    /// <summary>Returns the path of the event with the GUID.</summary>
    public static string GetEventPath(string guid)
    {
        var result = FmodServer.Call("get_event_path", guid);
        return result.AsString();
    }

    /// <summary>Returns the value of the global parameter with the ID.</summary>
    public static float GetGlobalParameterById(long parameterId)
    {
        var result = FmodServer.Call("get_global_parameter_by_id", parameterId);
        return result.AsSingle();
    }

    /// <summary>Returns the value of the named global parameter.</summary>
    public static float GetGlobalParameterByName(string parameterName)
    {
        var result = FmodServer.Call("get_global_parameter_by_name", parameterName);
        return result.AsSingle();
    }

    /// <summary>Returns the description of the global parameter with the ID.</summary>
    public static Godot.Collections.Dictionary GetGlobalParameterDescById(long parameterId) => (Godot.Collections.Dictionary)FmodServer.Call("get_global_parameter_desc_by_id", parameterId);

    /// <summary>Returns the description of the named global parameter.</summary>
    public static Godot.Collections.Dictionary GetGlobalParameterDescByName(string parameterName) => (Godot.Collections.Dictionary)FmodServer.Call("get_global_parameter_desc_by_name", parameterName);

    /// <summary>Returns the number of global parameters.</summary>
    public static int GetGlobalParameterDescCount()
    {
        var result = FmodServer.Call("get_global_parameter_desc_count");
        return result.AsInt32();
    }

    /// <summary>Returns the descriptions of all global parameters.</summary>
    public static Godot.Collections.Array GetGlobalParameterDescList() => (Godot.Collections.Array)FmodServer.Call("get_global_parameter_desc_list");

    /// <summary>Returns the 2D velocity of the listener at the index.</summary>
    public static Vector2 GetListener2DVelocity(int index) => (Vector2)FmodServer.Call("get_listener_2d_velocity", index);

    /// <summary>Returns the 3D velocity of the listener at the index.</summary>
    public static Vector3 GetListener3DVelocity(int index) => (Vector3)FmodServer.Call("get_listener_3d_velocity", index);

    /// <summary>Returns whether the listener at the index is locked in place.</summary>
    public static bool GetListenerLock(int index)
    {
        var result = FmodServer.Call("get_listener_lock", index);
        return result.AsBool();
    }

    /// <summary>Returns the number of listeners.</summary>
    public static int GetListenerNumber()
    {
        var result = FmodServer.Call("get_listener_number");
        return result.AsInt32();
    }

    /// <summary>Returns the 2D transform of the listener at the index.</summary>
    public static Transform2D GetListenerTransform2D(int index) => (Transform2D)FmodServer.Call("get_listener_transform2d", index);

    /// <summary>Returns the 3D transform of the listener at the index.</summary>
    public static Transform3D GetListenerTransform3D(int index) => (Transform3D)FmodServer.Call("get_listener_transform3d", index);

    /// <summary>Returns the weight of the listener at the index.</summary>
    public static float GetListenerWeight(int index)
    {
        var result = FmodServer.Call("get_listener_weight", index);
        return result.AsSingle();
    }

    /// <summary>Returns the node attached to the listener at the index, or null.</summary>
    public static GodotObject? GetObjectAttachedToListener(int index)
    {
        var result = FmodServer.Call("get_object_attached_to_listener", index);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_object_attached_to_listener returned null for index '{index}'");
            return null;
        }

        return obj;
    }

    /// <summary>Returns the current CPU, memory and I/O statistics, or null on failure.</summary>
    public static FmodPerformanceData? GetPerformanceData()
    {
        var result = FmodServer.Call("get_performance_data");
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError("FmodWrapper: get_performance_data returned null");
            return null;
        }

        return new FmodPerformanceData(obj);
    }

    /// <summary>Returns the DSP buffer length, in samples.</summary>
    public static int GetSystemDspBufferLength()
    {
        var result = FmodServer.Call("get_system_dsp_buffer_length");
        return result.AsInt32();
    }

    /// <summary>Returns the DSP buffer settings object, or null on failure.</summary>
    public static GodotObject? GetSystemDspBufferSettings()
    {
        var result = FmodServer.Call("get_system_dsp_buffer_settings");
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError("FmodWrapper: get_system_dsp_buffer_settings returned null");
            return null;
        }

        return obj;
    }

    /// <summary>Returns the number of DSP buffers.</summary>
    public static int GetSystemDspNumBuffers()
    {
        var result = FmodServer.Call("get_system_dsp_num_buffers");
        return result.AsInt32();
    }

    /// <summary>Returns the VCA at the path, or null if not found.</summary>
    public static FmodVca? GetVca(string vcaPath)
    {
        var result = FmodServer.Call("get_vca", vcaPath);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_vca returned null for path '{vcaPath}'");
            return null;
        }

        return new FmodVca(obj);
    }

    /// <summary>Returns the VCA with the GUID, or null if not found.</summary>
    public static FmodVca? GetVcaFromGuid(string guid)
    {
        var result = FmodServer.Call("get_vca_from_guid", guid);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_vca_from_guid returned null for guid '{guid}'");
            return null;
        }

        return new FmodVca(obj);
    }

    /// <summary>Initializes FMOD with a general settings object.</summary>
    public static void Init(GodotObject generalSettings) => FmodServer.Call("init", generalSettings);

    /// <summary>Returns whether the plugin with the handle is loaded.</summary>
    public static bool IsPluginLoaded(uint pluginHandle)
    {
        var result = FmodServer.Call("is_plugin_loaded", pluginHandle);
        return result.AsBool();
    }

    /// <summary>Loads a bank with FMOD_STUDIO_LOAD_BANK_* flags, or returns null on failure.</summary>
    public static FmodBank? LoadBank(string path, int flag = 0)
    {
        var result = FmodServer.Call("load_bank", path, flag);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: load_bank returned null for path '{path}'");
            return null;
        }

        return new FmodBank(obj);
    }

    /// <summary>Loads a file as a streamed music sound, or returns null on failure.</summary>
    public static GodotObject? LoadFileAsMusic(string path)
    {
        var result = FmodServer.Call("load_file_as_music", path);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: load_file_as_music returned null for path '{path}'");
            return null;
        }

        return obj;
    }

    /// <summary>Loads a file as a sample sound, or returns null on failure.</summary>
    public static GodotObject? LoadFileAsSound(string path)
    {
        var result = FmodServer.Call("load_file_as_sound", path);
        var obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: load_file_as_sound returned null for path '{path}'");
            return null;
        }

        return obj;
    }

    /// <summary>Loads an FMOD plugin and returns its handle.</summary>
    public static uint LoadPlugin(string pluginPath, uint priority = 0)
    {
        var result = FmodServer.Call("load_plugin", pluginPath, priority);
        return result.AsUInt32();
    }

    /// <summary>Mutes all events.</summary>
    public static void MuteAllEvents() => FmodServer.Call("mute_all_events");

    /// <summary>Pauses all events.</summary>
    public static void PauseAllEvents() => FmodServer.Call("pause_all_events");

    /// <summary>Plays a one-shot of the event path.</summary>
    public static void PlayOneShot(string eventPath)
    {
        if (!ValidateEventPath(eventPath)) return;
        FmodServer.Call("play_one_shot", eventPath);
    }

    /// <summary>Plays a one-shot of the event path attached to a node.</summary>
    public static void PlayOneShotAttached(string eventPath, Node gameObject)
    {
        if (!ValidateEventPath(eventPath)) return;
        FmodServer.Call("play_one_shot_attached", eventPath, gameObject);
    }

    /// <summary>Plays a one-shot of the event path attached to a node, with parameter values.</summary>
    public static void PlayOneShotAttachedWithParams(string eventPath, Node gameObject, Godot.Collections.Dictionary<string, float> parameters)
    {
        if (!ValidateEventPath(eventPath)) return;

        Godot.Collections.Dictionary godotDict = [];
        foreach (var kvp in parameters)
        {
            godotDict[kvp.Key] = kvp.Value;
        }

        FmodServer.Call("play_one_shot_attached_with_params", eventPath, gameObject, godotDict);
    }

    /// <summary>Plays a one-shot of the event description.</summary>
    public static void PlayOneShotUsingEventDescription(GodotObject eventDescription) => FmodServer.Call("play_one_shot_using_event_description", eventDescription);

    /// <summary>Plays a one-shot of the event description attached to a node.</summary>
    public static void PlayOneShotUsingEventDescriptionAttached(GodotObject eventDescription, Node gameObj) => FmodServer.Call("play_one_shot_using_event_description_attached", eventDescription, gameObj);

    /// <summary>Plays a one-shot of the event description attached to a node, with parameter values.</summary>
    public static void PlayOneShotUsingEventDescriptionAttachedWithParams(GodotObject eventDescription, Node gameObj, Godot.Collections.Dictionary parameters) => FmodServer.Call("play_one_shot_using_event_description_attached_with_params", eventDescription, gameObj, parameters);

    /// <summary>Plays a one-shot of the event description with parameter values.</summary>
    public static void PlayOneShotUsingEventDescriptionWithParams(GodotObject eventDescription, Godot.Collections.Dictionary parameters) => FmodServer.Call("play_one_shot_using_event_description_with_params", eventDescription, parameters);

    /// <summary>Plays a one-shot of the event GUID.</summary>
    public static void PlayOneShotUsingGuid(string guid) => FmodServer.Call("play_one_shot_using_guid", guid);

    /// <summary>Plays a one-shot of the event GUID attached to a node.</summary>
    public static void PlayOneShotUsingGuidAttached(string guid, Node gameObj) => FmodServer.Call("play_one_shot_using_guid_attached", guid, gameObj);

    /// <summary>Plays a one-shot of the event GUID attached to a node, with parameter values.</summary>
    public static void PlayOneShotUsingGuidAttachedWithParams(string guid, Node gameObj, Godot.Collections.Dictionary parameters) => FmodServer.Call("play_one_shot_using_guid_attached_with_params", guid, gameObj, parameters);

    /// <summary>Plays a one-shot of the event GUID with parameter values.</summary>
    public static void PlayOneShotUsingGuidWithParams(string guid, Godot.Collections.Dictionary parameters) => FmodServer.Call("play_one_shot_using_guid_with_params", guid, parameters);

    /// <summary>Plays a one-shot of the event path with parameter values.</summary>
    public static void PlayOneShotWithParams(string eventPath, Godot.Collections.Dictionary<string, float> parameters)
    {
        if (!ValidateEventPath(eventPath)) return;

        Godot.Collections.Dictionary godotDict = [];
        foreach (var kvp in parameters)
        {
            godotDict[kvp.Key] = kvp.Value;
        }

        FmodServer.Call("play_one_shot_with_params", eventPath, godotDict);
    }

    /// <summary>Detaches listener <paramref name="index"/> from a node.</summary>
    public static void RemoveListener(int index, Node gameObj) => FmodServer.Call("remove_listener", index, gameObj);

    /// <summary>Sets the output driver by ID.</summary>
    public static void SetDriver(int id) => FmodServer.Call("set_driver", id);

    /// <summary>Sets the value of the global parameter with the ID.</summary>
    public static void SetGlobalParameterById(long parameterId, float value) => FmodServer.Call("set_global_parameter_by_id", parameterId, value);

    /// <summary>Sets the global parameter with the ID to the value of a label.</summary>
    public static void SetGlobalParameterByIdWithLabel(long parameterId, string label) => FmodServer.Call("set_global_parameter_by_id_with_label", parameterId, label);

    /// <summary>Sets the value of the named global parameter.</summary>
    public static void SetGlobalParameterByName(string parameterName, float value) => FmodServer.Call("set_global_parameter_by_name", parameterName, value);

    /// <summary>Sets the named global parameter to the value of a label.</summary>
    public static void SetGlobalParameterByNameWithLabel(string parameterName, string label) => FmodServer.Call("set_global_parameter_by_name_with_label", parameterName, label);

    /// <summary>Locks or unlocks the listener at the index in place.</summary>
    public static void SetListenerLock(int index, bool isLocked) => FmodServer.Call("set_listener_lock", index, isLocked);

    /// <summary>Sets the number of listeners.</summary>
    public static void SetListenerNumber(int listenerNumber) => FmodServer.Call("set_listener_number", listenerNumber);

    /// <summary>Sets the 2D transform of the listener at the index.</summary>
    public static void SetListenerTransform2D(int index, Transform2D transform) => FmodServer.Call("set_listener_transform2d", index, transform);

    /// <summary>Sets the 3D transform of the listener at the index.</summary>
    public static void SetListenerTransform3D(int index, Transform3D transform) => FmodServer.Call("set_listener_transform3d", index, transform);

    /// <summary>Sets the weight of the listener at the index.</summary>
    public static void SetListenerWeight(int index, float weight) => FmodServer.Call("set_listener_weight", index, weight);

    /// <summary>Sets the software mixer format from a settings object.</summary>
    public static void SetSoftwareFormat(GodotObject softwareFormatSettings) => FmodServer.Call("set_software_format", softwareFormatSettings);

    /// <summary>Sets the global 3D sound settings from a settings object.</summary>
    public static void SetSound3DSettings(GodotObject sound3DSettings) => FmodServer.Call("set_sound_3D_settings", sound3DSettings);

    /// <summary>Sets the DSP buffer size from a settings object.</summary>
    public static void SetSystemDspBufferSize(GodotObject dspSettings) => FmodServer.Call("set_system_dsp_buffer_size", dspSettings);

    /// <summary>Shuts down FMOD.</summary>
    public static void Shutdown() => FmodServer.Call("shutdown");

    /// <summary>Unloads a file loaded as music or sound.</summary>
    public static void UnloadFile(string path) => FmodServer.Call("unload_file", path);

    /// <summary>Unloads the plugin with the handle.</summary>
    public static void UnloadPlugin(uint pluginHandle) => FmodServer.Call("unload_plugin", pluginHandle);

    /// <summary>Unmutes all events.</summary>
    public static void UnmuteAllEvents() => FmodServer.Call("unmute_all_events");

    /// <summary>Unpauses all events.</summary>
    public static void UnpauseAllEvents() => FmodServer.Call("unpause_all_events");

    /// <summary>Runs one FMOD update.</summary>
    public static void Update() => FmodServer.Call("update");

    /// <summary>Blocks until all pending bank loads finish.</summary>
    public static void WaitForAllLoads() => FmodServer.Call("wait_for_all_loads");

    #endregion

    #region Validation
    private static bool ValidateEventPath(string eventPath)
    {
        if (string.IsNullOrEmpty(eventPath))
        {
            GD.PushError("FmodWrapper: Event path is null or empty");
            return false;
        }

        if (!CheckEventPath(eventPath))
        {
            GD.PushError($"FmodWrapper: Event path not found in loaded banks: '{eventPath}'");
            return false;
        }

        return true;
    }

    #endregion
}
