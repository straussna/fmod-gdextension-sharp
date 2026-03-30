using Godot;

namespace FmodSharp;

/// <summary>
/// Wrapper for an FMOD bank object. Banks contain events, buses, VCAs, and other FMOD data.
/// This is a RefCounted-backed object, not a scene node.
/// </summary>
public class FmodBank(GodotObject bankInstance)
{
    private readonly GodotObject _bankInstance = bankInstance ?? throw new ArgumentNullException(nameof(bankInstance));

    /// <summary>
    /// The underlying FMOD bank GodotObject for advanced usage.
    /// </summary>
    public GodotObject FmodInstance => _bankInstance;

    public int GetLoadingState()
    {
        return _bankInstance.Call("get_loading_state").AsInt32();
    }

    public long GetEventDescriptionCount()
    {
        return _bankInstance.Call("get_event_description_count").AsInt64();
    }

    public long GetBusCount()
    {
        return _bankInstance.Call("get_bus_count").AsInt64();
    }

    public long GetVcaCount()
    {
        return _bankInstance.Call("get_VCA_count").AsInt64();
    }

    public int GetStringCount()
    {
        return _bankInstance.Call("get_string_count").AsInt32();
    }

    public Godot.Collections.Array GetDescriptionList()
    {
        return (Godot.Collections.Array)_bankInstance.Call("get_description_list");
    }

    public Godot.Collections.Array GetBusList()
    {
        return (Godot.Collections.Array)_bankInstance.Call("get_bus_list");
    }

    public Godot.Collections.Array GetVcaList()
    {
        return (Godot.Collections.Array)_bankInstance.Call("get_vca_list");
    }

    public bool IsValid()
    {
        return _bankInstance.Call("is_valid").AsBool();
    }

    public string GetGodotResPath()
    {
        return _bankInstance.Call("get_godot_res_path").AsString();
    }

    public string GetPath()
    {
        return _bankInstance.Call("get_path").AsString();
    }

    public string GetGuid()
    {
        return _bankInstance.Call("get_guid").AsString();
    }
}
