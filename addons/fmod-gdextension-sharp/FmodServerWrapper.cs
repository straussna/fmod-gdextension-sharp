using System;
using Godot;

namespace FmodSharp;

/// <summary>
/// C# wrapper for the FMOD GDScript singleton (FmodServer).
/// Provides type-safe access to FMOD audio functionality.
/// Add this to Project Settings -> Autoload as "FmodWrapper".
/// </summary>
public partial class FmodServerWrapper : Node
{
    private static GodotObject _fmodServer;

    private static GodotObject FmodServer
    {
        get
        {
            if (_fmodServer != null)
            {
                return _fmodServer;
            }

            GodotObject server = Engine.GetSingleton("FmodServer");
            if (server == null)
            {
                GD.PushError("FmodWrapper: FmodServer singleton not found! Make sure FMOD addon is properly installed and enabled.");
                throw new InvalidOperationException("FmodServer singleton not found");
            }

            _fmodServer = server;
            return _fmodServer;
        }
    }

    // FMOD constants
    #region FMOD Constants
    public const int FMOD_INIT_3D_RIGHTHANDED = 4;
    public const int FMOD_INIT_CHANNEL_DISTANCEFILTER = 512;
    public const int FMOD_INIT_CHANNEL_LOWPASS = 256;
    public const int FMOD_INIT_GEOMETRY_USECLOSEST = 262144;
    public const int FMOD_INIT_MIX_FROM_UPDATE = 2;
    public const int FMOD_INIT_NORMAL = 0;
    public const int FMOD_INIT_PREFER_DOLBY_DOWNMIX = 524288;
    public const int FMOD_INIT_PROFILE_ENABLE = 65536;
    public const int FMOD_INIT_PROFILE_METER_ALL = 2097152;
    public const int FMOD_INIT_STREAM_FROM_UPDATE = 1;
    public const int FMOD_INIT_THREAD_UNSAFE = 1048576;
    public const int FMOD_INIT_VOL0_BECOMES_VIRTUAL = 131072;

    public const int FMOD_STUDIO_INIT_NORMAL = 0;
    public const int FMOD_STUDIO_INIT_LIVEUPDATE = 1;
    public const int FMOD_STUDIO_INIT_ALLOW_MISSING_PLUGINS = 2;
    public const int FMOD_STUDIO_INIT_SYNCHRONOUS_UPDATE = 4;
    public const int FMOD_STUDIO_INIT_DEFERRED_CALLBACKS = 8;
    public const int FMOD_STUDIO_INIT_LOAD_FROM_UPDATE = 16;

    public const int FMOD_SPEAKERMODE_5POINT1 = 6;
    public const int FMOD_SPEAKERMODE_7POINT1 = 7;
    public const int FMOD_SPEAKERMODE_7POINT1POINT4 = 8;
    public const int FMOD_SPEAKERMODE_DEFAULT = 0;
    public const int FMOD_SPEAKERMODE_MAX = 9;
    public const int FMOD_SPEAKERMODE_MONO = 2;
    public const int FMOD_SPEAKERMODE_QUAD = 4;
    public const int FMOD_SPEAKERMODE_RAW = 1;
    public const int FMOD_SPEAKERMODE_STEREO = 3;
    public const int FMOD_SPEAKERMODE_SURROUND = 5;

    public const int FMOD_STUDIO_LOAD_BANK_NORMAL = 0;
    public const int FMOD_STUDIO_LOAD_BANK_NONBLOCKING = 1;
    public const int FMOD_STUDIO_LOAD_BANK_DECOMPRESS_SAMPLES = 2;

    public const int FMOD_2D = 8;
    public const int FMOD_3D = 16;
    public const int FMOD_3D_CUSTOMROLLOFF = 67108864;
    public const int FMOD_3D_HEADRELATIVE = 262144;
    public const int FMOD_3D_IGNOREGEOMETRY = 1073741824;
    public const int FMOD_3D_INVERSEROLLOFF = 1048576;
    public const int FMOD_3D_INVERSETAPEREDROLLOFF = 8388608;
    public const int FMOD_3D_LINEARROLLOFF = 2097152;
    public const int FMOD_3D_LINEARSQUAREROLLOFF = 4194304;
    public const int FMOD_3D_WORLDRELATIVE = 524288;

    public const int FMOD_ACCURATETIME = 16384;
    public const int FMOD_CREATECOMPRESSEDSAMPLE = 512;
    public const int FMOD_CREATESAMPLE = 256;
    public const int FMOD_CREATESTREAM = 128;
    public const int FMOD_DEFAULT = 0;
    public const int FMOD_IGNORETAGS = 33554432;
    public const int FMOD_LOOP_BIDI = 4;
    public const int FMOD_LOOP_NORMAL = 2;
    public const int FMOD_LOOP_OFF = 1;
    public const int FMOD_LOWMEM = 134217728;
    public const int FMOD_MPEGSEARCH = 32768;
    public const int FMOD_NONBLOCKING = 65536;
    public const int FMOD_OPENMEMORY = 2048;
    public const int FMOD_OPENMEMORY_POINT = 268435456;
    public const int FMOD_OPENONLY = 8192;
    public const int FMOD_OPENRAW = 4096;
    public const int FMOD_OPENUSER = 1024;
    public const int FMOD_UNIQUE = 131072;
    public const long FMOD_VIRTUAL_PLAYFROMSTART = 2147483648;

    public const int FMOD_STUDIO_STOP_ALLOWFADEOUT = 0;
    public const int FMOD_STUDIO_STOP_IMMEDIATE = 1;
    public const int FMOD_STUDIO_STOP_FORCEINT = 65536;

    public const int FMOD_STUDIO_SYSTEM_CALLBACK_PREUPDATE = 1;
    public const int FMOD_STUDIO_SYSTEM_CALLBACK_POSTUPDATE = 2;
    public const int FMOD_STUDIO_SYSTEM_CALLBACK_BANK_UNLOAD = 4;
    public const int FMOD_STUDIO_SYSTEM_CALLBACK_LIVEUPDATE_CONNECTED = 8;
    public const int FMOD_STUDIO_SYSTEM_CALLBACK_LIVEUPDATE_DISCONNECTED = 16;
    public const uint FMOD_STUDIO_SYSTEM_CALLBACK_ALL = 0xFFFFFFFF;

    public const int FMOD_STUDIO_EVENT_CALLBACK_CREATED = 1;
    public const int FMOD_STUDIO_EVENT_CALLBACK_DESTROYED = 2;
    public const int FMOD_STUDIO_EVENT_CALLBACK_STARTING = 4;
    public const int FMOD_STUDIO_EVENT_CALLBACK_STARTED = 8;
    public const int FMOD_STUDIO_EVENT_CALLBACK_RESTARTED = 16;
    public const int FMOD_STUDIO_EVENT_CALLBACK_STOPPED = 32;
    public const int FMOD_STUDIO_EVENT_CALLBACK_START_FAILED = 64;
    public const int FMOD_STUDIO_EVENT_CALLBACK_CREATE_PROGRAMMER_SOUND = 128;
    public const int FMOD_STUDIO_EVENT_CALLBACK_DESTROY_PROGRAMMER_SOUND = 256;
    public const int FMOD_STUDIO_EVENT_CALLBACK_PLUGIN_CREATED = 512;
    public const int FMOD_STUDIO_EVENT_CALLBACK_PLUGIN_DESTROYED = 1024;
    public const int FMOD_STUDIO_EVENT_CALLBACK_TIMELINE_MARKER = 2048;
    public const int FMOD_STUDIO_EVENT_CALLBACK_TIMELINE_BEAT = 4096;
    public const int FMOD_STUDIO_EVENT_CALLBACK_SOUND_PLAYED = 8192;
    public const int FMOD_STUDIO_EVENT_CALLBACK_SOUND_STOPPED = 16384;
    public const int FMOD_STUDIO_EVENT_CALLBACK_REAL_TO_VIRTUAL = 32768;
    public const int FMOD_STUDIO_EVENT_CALLBACK_VIRTUAL_TO_REAL = 65536;
    public const int FMOD_STUDIO_EVENT_CALLBACK_START_EVENT_COMMAND = 131072;
    public const int FMOD_STUDIO_EVENT_CALLBACK_NESTED_TIMELINE_BEAT = 262144;
    public const uint FMOD_STUDIO_EVENT_CALLBACK_ALL = 0xFFFFFFFF;

    public const int FMOD_STUDIO_LOADING_STATE_UNLOADING = 0;
    public const int FMOD_STUDIO_LOADING_STATE_UNLOADED = 1;
    public const int FMOD_STUDIO_LOADING_STATE_LOADING = 2;
    public const int FMOD_STUDIO_LOADING_STATE_LOADED = 3;
    public const int FMOD_STUDIO_LOADING_STATE_ERROR = 4;
    public const int FMOD_STUDIO_LOADING_STATE_FORCEINT = 65536;

    public const int FMOD_STUDIO_PLAYBACK_PLAYING = 0;
    public const int FMOD_STUDIO_PLAYBACK_SUSTAINING = 1;
    public const int FMOD_STUDIO_PLAYBACK_STOPPED = 2;
    public const int FMOD_STUDIO_PLAYBACK_STARTING = 3;
    public const int FMOD_STUDIO_PLAYBACK_STOPPING = 4;
    public const int FMOD_STUDIO_PLAYBACK_FORCEINT = 65536;
    #endregion

    public override void _Ready()
    {
        _fmodServer = Engine.GetSingleton("FmodServer") as GodotObject;

        if (_fmodServer == null)
        {
            GD.PushError("FmodWrapper: FmodServer singleton not found! Make sure FMOD addon is properly installed and enabled.");
            return;
        }

        GD.Print("FmodWrapper initialized successfully");
    }

    #region FMOD API

    // 1. add_listener(index: int, game_obj: Node)
    public static void AddListener(int index, Node gameObj) => FmodServer.Call("add_listener", index, gameObj);

    // 2. banks_still_loading()
    public static bool BanksStillLoading()
    {
        Variant result = FmodServer.Call("banks_still_loading");
        return result.AsBool();
    }

    // 3. check_bus_guid(guid: String)
    public static bool CheckBusGuid(string guid)
    {
        Variant result = FmodServer.Call("check_bus_guid", guid);
        return result.AsBool();
    }

    // 4. check_bus_path(busPath: String)
    public static bool CheckBusPath(string busPath)
    {
        Variant result = FmodServer.Call("check_bus_path", busPath);
        return result.AsBool();
    }

    // 5. check_event_guid(guid: String)
    public static bool CheckEventGuid(string guid)
    {
        Variant result = FmodServer.Call("check_event_guid", guid);
        return result.AsBool();
    }

    // 6. check_event_path(eventPath: String)
    public static bool CheckEventPath(string eventPath)
    {
        Variant result = FmodServer.Call("check_event_path", eventPath);
        return result.AsBool();
    }

    // 7. check_vca_guid(guid: String)
    public static bool CheckVcaGuid(string guid)
    {
        Variant result = FmodServer.Call("check_vca_guid", guid);
        return result.AsBool();
    }

    // 8. check_vca_path(cvaPath: String)
    public static bool CheckVcaPath(string cvaPath)
    {
        Variant result = FmodServer.Call("check_vca_path", cvaPath);
        return result.AsBool();
    }

    // 9. create_event_instance(eventPath: String)
    public static FmodEvent CreateEventInstance(string eventPath)
    {
        Variant result = FmodServer.Call("create_event_instance", eventPath);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: create_event_instance returned null for path '{eventPath}'");
        }
        return new FmodEvent(obj!);
    }

    // 10. create_event_instance_from_description(eventDescription: FmodEventDescription)
    public static FmodEvent CreateEventInstanceFromDescription(GodotObject eventDescription)
    {
        Variant result = FmodServer.Call("create_event_instance_from_description", eventDescription);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError("FmodWrapper: create_event_instance_from_description returned null");
        }
        return new FmodEvent(obj!);
    }

    // 11. create_event_instance_with_guid(guid: String)
    public static FmodEvent CreateEventInstanceWithGuid(string guid)
    {
        Variant result = FmodServer.Call("create_event_instance_with_guid", guid);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: create_event_instance_with_guid returned null for guid '{guid}'");
        }
        return new FmodEvent(obj!);
    }

    // 12. create_sound_instance(path: String)
    public static GodotObject CreateSoundInstance(string path)
    {
        Variant result = FmodServer.Call("create_sound_instance", path);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: create_sound_instance returned null for path '{path}'");
            return null!;
        }
        return obj;
    }

    // 13. get_all_banks()
    public static Godot.Collections.Array GetAllBanks() => (Godot.Collections.Array)FmodServer.Call("get_all_banks");

    // 14. get_all_buses()
    public static Godot.Collections.Array GetAllBuses() => (Godot.Collections.Array)FmodServer.Call("get_all_buses");

    // 15. get_all_event_descriptions()
    public static Godot.Collections.Array GetAllEventDescriptions() => (Godot.Collections.Array)FmodServer.Call("get_all_event_descriptions");

    // 16. get_all_vca()
    public static Godot.Collections.Array GetAllVca() => (Godot.Collections.Array)FmodServer.Call("get_all_vca");

    // 17. get_available_drivers()
    public static Godot.Collections.Array GetAvailableDrivers() => (Godot.Collections.Array)FmodServer.Call("get_available_drivers");

    // 18. get_bus(busPath: String)
    public static GodotObject GetBus(string busPath)
    {
        Variant result = FmodServer.Call("get_bus", busPath);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_bus returned null for path '{busPath}'");
            return null!;
        }
        return obj;
    }

    // 19. get_bus_from_guid(guid: String)
    public static GodotObject GetBusFromGuid(string guid)
    {
        Variant result = FmodServer.Call("get_bus_from_guid", guid);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_bus_from_guid returned null for guid '{guid}'");
            return null!;
        }
        return obj;
    }

    // 20. get_driver()
    public static int GetDriver()
    {
        Variant result = FmodServer.Call("get_driver");
        return result.AsInt32();
    }

    // 21. get_event(eventPath: String)
    public static GodotObject GetEvent(string eventPath)
    {
        Variant result = FmodServer.Call("get_event", eventPath);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_event returned null for path '{eventPath}'");
            return null!;
        }
        return obj;
    }

    // 22. get_event_from_guid(guid: String)
    public static GodotObject GetEventFromGuid(string guid)
    {
        Variant result = FmodServer.Call("get_event_from_guid", guid);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_event_from_guid returned null for guid '{guid}'");
            return null!;
        }
        return obj;
    }

    // 23. get_event_guid(event_path: String)
    public static string GetEventGuid(string eventPath)
    {
        Variant result = FmodServer.Call("get_event_guid", eventPath);
        return result.AsString();
    }

    // 24. get_event_path(guid: String)
    public static string GetEventPath(string guid)
    {
        Variant result = FmodServer.Call("get_event_path", guid);
        return result.AsString();
    }

    // 25. get_global_parameter_by_id(parameter_id: int)
    public static float GetGlobalParameterById(int parameterId)
    {
        Variant result = FmodServer.Call("get_global_parameter_by_id", parameterId);
        return result.AsSingle();
    }

    // 26. get_global_parameter_by_name(parameter_name: String)
    public static float GetGlobalParameterByName(string parameterName)
    {
        Variant result = FmodServer.Call("get_global_parameter_by_name", parameterName);
        return result.AsSingle();
    }

    // 27. get_global_parameter_desc_by_id(parameter_id: int)
    public static Godot.Collections.Dictionary GetGlobalParameterDescById(int parameterId) => (Godot.Collections.Dictionary)FmodServer.Call("get_global_parameter_desc_by_id", parameterId);

    // 28. get_global_parameter_desc_by_name(parameterName: String)
    public static Godot.Collections.Dictionary GetGlobalParameterDescByName(string parameterName) => (Godot.Collections.Dictionary)FmodServer.Call("get_global_parameter_desc_by_name", parameterName);

    // 29. get_global_parameter_desc_count()
    public static int GetGlobalParameterDescCount()
    {
        Variant result = FmodServer.Call("get_global_parameter_desc_count");
        return result.AsInt32();
    }

    // 30. get_global_parameter_desc_list()
    public static Godot.Collections.Array GetGlobalParameterDescList() => (Godot.Collections.Array)FmodServer.Call("get_global_parameter_desc_list");

    // 31. get_listener_2d_velocity(index: int)
    public static Vector2 GetListener2DVelocity(int index) => (Vector2)FmodServer.Call("get_listener_2d_velocity", index);

    // 32. get_listener_3d_velocity(index: int)
    public static Vector3 GetListener3DVelocity(int index) => (Vector3)FmodServer.Call("get_listener_3d_velocity", index);

    // 33. get_listener_lock(index: int)
    public static bool GetListenerLock(int index)
    {
        Variant result = FmodServer.Call("get_listener_lock", index);
        return result.AsBool();
    }

    // 34. get_listener_number() const
    public static int GetListenerNumber()
    {
        Variant result = FmodServer.Call("get_listener_number");
        return result.AsInt32();
    }

    // 35. get_listener_transform2d(index: int)
    public static Transform2D GetListenerTransform2D(int index) => (Transform2D)FmodServer.Call("get_listener_transform2d", index);

    // 36. get_listener_transform3d(index: int)
    public static Transform3D GetListenerTransform3D(int index) => (Transform3D)FmodServer.Call("get_listener_transform3d", index);

    // 37. get_listener_weight(index: int)
    public static float GetListenerWeight(int index)
    {
        Variant result = FmodServer.Call("get_listener_weight", index);
        return result.AsSingle();
    }

    // 38. get_object_attached_to_listener(index: int)
    public static GodotObject GetObjectAttachedToListener(int index)
    {
        Variant result = FmodServer.Call("get_object_attached_to_listener", index);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_object_attached_to_listener returned null for index '{index}'");
            return null!;
        }
        return obj;
    }

    // 39. get_performance_data()
    public static GodotObject GetPerformanceData()
    {
        Variant result = FmodServer.Call("get_performance_data");
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError("FmodWrapper: get_performance_data returned null");
            return null!;
        }
        return obj;
    }

    // 40. get_system_dsp_buffer_length()
    public static int GetSystemDspBufferLength()
    {
        Variant result = FmodServer.Call("get_system_dsp_buffer_length");
        return result.AsInt32();
    }

    // 41. get_system_dsp_buffer_settings()
    public static GodotObject GetSystemDspBufferSettings()
    {
        Variant result = FmodServer.Call("get_system_dsp_buffer_settings");
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError("FmodWrapper: get_system_dsp_buffer_settings returned null");
            return null!;
        }
        return obj;
    }

    // 42. get_system_dsp_num_buffers()
    public static int GetSystemDspNumBuffers()
    {
        Variant result = FmodServer.Call("get_system_dsp_num_buffers");
        return result.AsInt32();
    }

    // 43. get_vca(cvaPath: String)
    public static GodotObject GetVca(string cvaPath)
    {
        Variant result = FmodServer.Call("get_vca", cvaPath);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_vca returned null for path '{cvaPath}'");
            return null!;
        }
        return obj;
    }

    // 44. get_vca_from_guid(guid: String)
    public static GodotObject GetVcaFromGuid(string guid)
    {
        Variant result = FmodServer.Call("get_vca_from_guid", guid);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: get_vca_from_guid returned null for guid '{guid}'");
            return null!;
        }
        return obj;
    }

    // 45. init(p_settings: FmodGeneralSettings)
    public static void Init(GodotObject generalSettings) => FmodServer.Call("init", generalSettings);

    // 46. is_plugin_loaded(p_plugin_handle: int)
    public static bool IsPluginLoaded(int pluginHandle)
    {
        Variant result = FmodServer.Call("is_plugin_loaded", pluginHandle);
        return result.AsBool();
    }

    // 47. load_bank(pathToBank: String, flag: int)
    public static GodotObject LoadBank(string path, int flag = 0)
    {
        Variant result = FmodServer.Call("load_bank", path, flag);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: load_bank returned null for path '{path}'");
            return null!;
        }
        return obj;
    }

    // 48. load_file_as_music(path: String)
    public static GodotObject LoadFileAsMusic(string path)
    {
        Variant result = FmodServer.Call("load_file_as_music", path);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: load_file_as_music returned null for path '{path}'");
            return null!;
        }
        return obj;
    }

    // 49. load_file_as_sound(path: String)
    public static GodotObject LoadFileAsSound(string path)
    {
        Variant result = FmodServer.Call("load_file_as_sound", path);
        GodotObject obj = result.AsGodotObject();
        if (obj == null)
        {
            GD.PushError($"FmodWrapper: load_file_as_sound returned null for path '{path}'");
            return null!;
        }
        return obj;
    }

    // 50. load_plugin(p_plugin_path: String, p_priority: int = 0)
    public static int LoadPlugin(string pluginPath, int priority = 0)
    {
        Variant result = FmodServer.Call("load_plugin", pluginPath, priority);
        return result.AsInt32();
    }

    // 51. mute_all_events()
    public static void MuteAllEvents() => FmodServer.Call("mute_all_events");

    // 52. pause_all_events()
    public static void PauseAllEvents() => FmodServer.Call("pause_all_events");

    // 53. play_one_shot(event_name: String)
    public static void PlayOneShot(string eventPath) => FmodServer.Call("play_one_shot", eventPath);

    // 54. play_one_shot_attached(event_name: String, game_obj: Node)
    public static void PlayOneShotAttached(string eventPath, Node gameObject) => FmodServer.Call("play_one_shot_attached", eventPath, gameObject);

    // 55. play_one_shot_attached_with_params(event_name: String, game_obj: Node, parameters: Dictionary)
    public static void PlayOneShotAttachedWithParams(string eventPath, Node gameObject, Godot.Collections.Dictionary<string, float> parameters)
    {
        Godot.Collections.Dictionary godotDict = new Godot.Collections.Dictionary();
        foreach (var kvp in parameters)
        {
            godotDict[kvp.Key] = kvp.Value;
        }
        FmodServer.Call("play_one_shot_attached_with_params", eventPath, gameObject, godotDict);
    }

    // 56. play_one_shot_using_event_description(event_description: FmodEventDescription)
    public static void PlayOneShotUsingEventDescription(GodotObject eventDescription) => FmodServer.Call("play_one_shot_using_event_description", eventDescription);

    // 57. play_one_shot_using_event_description_attached(event_description: FmodEventDescription, game_obj: Node)
    public static void PlayOneShotUsingEventDescriptionAttached(GodotObject eventDescription, Node gameObj) => FmodServer.Call("play_one_shot_using_event_description_attached", eventDescription, gameObj);

    // 58. play_one_shot_using_event_description_attached_with_params(event_description: FmodEventDescription, game_obj: Node, parameters: Dictionary)
    public static void PlayOneShotUsingEventDescriptionAttachedWithParams(GodotObject eventDescription, Node gameObj, Godot.Collections.Dictionary parameters) => FmodServer.Call("play_one_shot_using_event_description_attached_with_params", eventDescription, gameObj, parameters);

    // 59. play_one_shot_using_event_description_with_params(event_description: FmodEventDescription, parameters: Dictionary)
    public static void PlayOneShotUsingEventDescriptionWithParams(GodotObject eventDescription, Godot.Collections.Dictionary parameters) => FmodServer.Call("play_one_shot_using_event_description_with_params", eventDescription, parameters);

    // 60. play_one_shot_using_guid(guid: String)
    public static void PlayOneShotUsingGuid(string guid) => FmodServer.Call("play_one_shot_using_guid", guid);

    // 61. play_one_shot_using_guid_attached(guid: String, game_obj: Node)
    public static void PlayOneShotUsingGuidAttached(string guid, Node gameObj) => FmodServer.Call("play_one_shot_using_guid_attached", guid, gameObj);

    // 62. play_one_shot_using_guid_attached_with_params(guid: String, game_obj: Node, parameters: Dictionary)
    public static void PlayOneShotUsingGuidAttachedWithParams(string guid, Node gameObj, Godot.Collections.Dictionary parameters) => FmodServer.Call("play_one_shot_using_guid_attached_with_params", guid, gameObj, parameters);

    // 63. play_one_shot_using_guid_with_params(guid: String, parameters: Dictionary)
    public static void PlayOneShotUsingGuidWithParams(string guid, Godot.Collections.Dictionary parameters) => FmodServer.Call("play_one_shot_using_guid_with_params", guid, parameters);

    // 64. play_one_shot_with_params(event_name: String, parameters: Dictionary)
    public static void PlayOneShotWithParams(string eventPath, Godot.Collections.Dictionary<string, float> parameters)
    {
        Godot.Collections.Dictionary godotDict = new Godot.Collections.Dictionary();
        foreach (var kvp in parameters)
        {
            godotDict[kvp.Key] = kvp.Value;
        }
        FmodServer.Call("play_one_shot_with_params", eventPath, godotDict);
    }

    // 65. remove_listener(index: int, game_obj: Node)
    public static void RemoveListener(int index, Node gameObj) => FmodServer.Call("remove_listener", index, gameObj);

    // 66. set_driver(id: int)
    public static void SetDriver(int id) => FmodServer.Call("set_driver", id);

    // 67. set_global_parameter_by_id(parameter_id: int, value: float)
    public static void SetGlobalParameterById(int parameterId, float value) => FmodServer.Call("set_global_parameter_by_id", parameterId, value);

    // 68. set_global_parameter_by_id_with_label(parameter_id: int, label: String)
    public static void SetGlobalParameterByIdWithLabel(int parameterId, string label) => FmodServer.Call("set_global_parameter_by_id_with_label", parameterId, label);

    // 69. set_global_parameter_by_name(parameter_name: String, value: float)
    public static void SetGlobalParameterByName(string parameterName, float value) => FmodServer.Call("set_global_parameter_by_name", parameterName, value);

    // 70. set_global_parameter_by_name_with_label(parameter_name: String, label: String)
    public static void SetGlobalParameterByNameWithLabel(string parameterName, string label) => FmodServer.Call("set_global_parameter_by_name_with_label", parameterName, label);

    // 71. set_listener_lock(index: int, isLocked: bool)
    public static void SetListenerLock(int index, bool isLocked) => FmodServer.Call("set_listener_lock", index, isLocked);

    // 72. set_listener_number(listenerNumber: int)
    public static void SetListenerNumber(int listenerNumber) => FmodServer.Call("set_listener_number", listenerNumber);

    // 73. set_listener_transform2d(index: int, transform: Transform2D)
    // Keep existing SetListener2D for compatibility and add explicit transform-named wrapper
    public static void SetListener2D(int index, Transform2D transform) => FmodServer.Call("set_listener_transform2d", index, transform);
    public static void SetListenerTransform2D(int index, Transform2D transform) => SetListener2D(index, transform);

    // 74. set_listener_transform3d(index: int, transform: Transform3D)
    public static void SetListenerTransform3D(int index, Transform3D transform) => FmodServer.Call("set_listener_transform3d", index, transform);

    // 75. set_listener_weight(index: int, weight: float)
    public static void SetListenerWeight(int index, float weight) => FmodServer.Call("set_listener_weight", index, weight);

    // 76. set_software_format(p_settings: FmodSoftwareFormatSettings)
    public static void SetSoftwareFormat(GodotObject softwareFormatSettings) => FmodServer.Call("set_software_format", softwareFormatSettings);

    // 77. set_sound_3D_settings(p_settings: FmodSound3DSettings)
    public static void SetSound3DSettings(GodotObject sound3DSettings) => FmodServer.Call("set_sound_3D_settings", sound3DSettings);

    // 78. set_system_dsp_buffer_size(dsp_settings: FmodDspSettings)
    public static void SetSystemDspBufferSize(GodotObject dspSettings) => FmodServer.Call("set_system_dsp_buffer_size", dspSettings);

    // 79. shutdown()
    public static void Shutdown() => FmodServer.Call("shutdown");

    // 80. unload_file(path: String)
    public static void UnloadFile(string path) => FmodServer.Call("unload_file", path);

    // 81. unload_plugin(p_plugin_handle: int)
    public static void UnloadPlugin(int pluginHandle) => FmodServer.Call("unload_plugin", pluginHandle);

    // 82. unmute_all_events()
    public static void UnmuteAllEvents() => FmodServer.Call("unmute_all_events");

    // 83. unpause_all_events()
    public static void UnpauseAllEvents() => FmodServer.Call("unpause_all_events");

    // 84. update()
    public static void Update() => FmodServer.Call("update");

    // 85. wait_for_all_loads()
    public static void WaitForAllLoads() => FmodServer.Call("wait_for_all_loads");

    #endregion
}
