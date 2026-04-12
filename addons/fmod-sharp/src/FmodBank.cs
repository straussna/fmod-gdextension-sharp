using Godot;

namespace FmodSharp;

/// <summary>
/// Wrapper for an FMOD bank object. Banks contain events, buses, VCAs, and other FMOD data.
/// This is a RefCounted-backed object, not a scene node.
/// </summary>
public class FmodBank(GodotObject bankInstance)
{
    /// <summary>
    /// The underlying FMOD bank GodotObject for advanced usage.
    /// </summary>
    public GodotObject FmodInstance { get; } = bankInstance ?? throw new ArgumentNullException(nameof(bankInstance));

    public int GetLoadingState()
    {
        return FmodInstance.Call("get_loading_state").AsInt32();
    }

    public long GetEventDescriptionCount()
    {
        return FmodInstance.Call("get_event_description_count").AsInt64();
    }

    public long GetBusCount()
    {
        return FmodInstance.Call("get_bus_count").AsInt64();
    }

    public long GetVcaCount()
    {
        return FmodInstance.Call("get_VCA_count").AsInt64();
    }

    public int GetStringCount()
    {
        return FmodInstance.Call("get_string_count").AsInt32();
    }

    public Godot.Collections.Array GetDescriptionList()
    {
        return (Godot.Collections.Array)FmodInstance.Call("get_description_list");
    }

    public Godot.Collections.Array GetBusList()
    {
        return (Godot.Collections.Array)FmodInstance.Call("get_bus_list");
    }

    public Godot.Collections.Array GetVcaList()
    {
        return (Godot.Collections.Array)FmodInstance.Call("get_vca_list");
    }

    public bool IsValid()
    {
        return FmodInstance.Call("is_valid").AsBool();
    }

    public string GetGodotResPath()
    {
        return FmodInstance.Call("get_godot_res_path").AsString();
    }

    public string GetPath()
    {
        return FmodInstance.Call("get_path").AsString();
    }

    public string GetGuid()
    {
        return FmodInstance.Call("get_guid").AsString();
    }
}
