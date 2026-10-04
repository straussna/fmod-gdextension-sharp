using System;
using Godot;

namespace FmodSharp;

/// <summary>Wrapper for an FMOD bank, which holds events, buses, VCAs and strings.</summary>
public class FmodBank(GodotObject bankInstance)
{
    /// <summary>The underlying FMOD bank object.</summary>
    public GodotObject FmodInstance { get; } = bankInstance ?? throw new ArgumentNullException(nameof(bankInstance));

    /// <summary>Returns the bank's FMOD_STUDIO_LOADING_STATE value.</summary>
    public int GetLoadingState()
    {
        return FmodInstance.Call("get_loading_state").AsInt32();
    }

    /// <summary>Returns the number of event descriptions in the bank.</summary>
    public long GetEventDescriptionCount()
    {
        return FmodInstance.Call("get_event_description_count").AsInt64();
    }

    /// <summary>Returns the number of buses in the bank.</summary>
    public long GetBusCount()
    {
        return FmodInstance.Call("get_bus_count").AsInt64();
    }

    /// <summary>Returns the number of VCAs in the bank.</summary>
    public long GetVcaCount()
    {
        return FmodInstance.Call("get_VCA_count").AsInt64();
    }

    /// <summary>Returns the number of string table entries in the bank.</summary>
    public int GetStringCount()
    {
        return FmodInstance.Call("get_string_count").AsInt32();
    }

    /// <summary>Returns the bank's event descriptions.</summary>
    public Godot.Collections.Array GetDescriptionList()
    {
        return (Godot.Collections.Array)FmodInstance.Call("get_description_list");
    }

    /// <summary>Returns the bank's buses.</summary>
    public Godot.Collections.Array GetBusList()
    {
        return (Godot.Collections.Array)FmodInstance.Call("get_bus_list");
    }

    /// <summary>Returns the bank's VCAs.</summary>
    public Godot.Collections.Array GetVcaList()
    {
        return (Godot.Collections.Array)FmodInstance.Call("get_vca_list");
    }

    /// <summary>Returns whether the bank handle is still valid.</summary>
    public bool IsValid()
    {
        return FmodInstance.Call("is_valid").AsBool();
    }

    /// <summary>Returns the res:// path the bank was loaded from.</summary>
    public string GetGodotResPath()
    {
        return FmodInstance.Call("get_godot_res_path").AsString();
    }

    /// <summary>Returns the bank's FMOD path.</summary>
    public string GetPath()
    {
        return FmodInstance.Call("get_path").AsString();
    }

    /// <summary>Returns the bank's GUID.</summary>
    public string GetGuid()
    {
        return FmodInstance.Call("get_guid").AsString();
    }
}
