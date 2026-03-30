using FmodSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FmodSharp.Tests;

[TestClass]
public class FmodServerWrapperConstantsTests
{
    [DataTestMethod]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_NORMAL), 0)]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_STREAM_FROM_UPDATE), 1)]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_MIX_FROM_UPDATE), 2)]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_3D_RIGHTHANDED), 4)]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_CHANNEL_LOWPASS), 256)]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_CHANNEL_DISTANCEFILTER), 512)]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_PROFILE_ENABLE), 65536)]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_VOL0_BECOMES_VIRTUAL), 131072)]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_GEOMETRY_USECLOSEST), 262144)]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_PREFER_DOLBY_DOWNMIX), 524288)]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_THREAD_UNSAFE), 1048576)]
    [DataRow(nameof(FmodServerWrapper.FMOD_INIT_PROFILE_METER_ALL), 2097152)]
    public void FMOD_INIT_Constants_MatchExpectedValues(string name, int expected)
    {
        int actual = (int)typeof(FmodServerWrapper).GetField(name)!.GetRawConstantValue()!;
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_INIT_NORMAL), 0)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_INIT_LIVEUPDATE), 1)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_INIT_ALLOW_MISSING_PLUGINS), 2)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_INIT_SYNCHRONOUS_UPDATE), 4)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_INIT_DEFERRED_CALLBACKS), 8)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_INIT_LOAD_FROM_UPDATE), 16)]
    public void FMOD_STUDIO_INIT_Constants_MatchExpectedValues(string name, int expected)
    {
        int actual = (int)typeof(FmodServerWrapper).GetField(name)!.GetRawConstantValue()!;
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(nameof(FmodServerWrapper.FMOD_SPEAKERMODE_DEFAULT), 0)]
    [DataRow(nameof(FmodServerWrapper.FMOD_SPEAKERMODE_RAW), 1)]
    [DataRow(nameof(FmodServerWrapper.FMOD_SPEAKERMODE_MONO), 2)]
    [DataRow(nameof(FmodServerWrapper.FMOD_SPEAKERMODE_STEREO), 3)]
    [DataRow(nameof(FmodServerWrapper.FMOD_SPEAKERMODE_QUAD), 4)]
    [DataRow(nameof(FmodServerWrapper.FMOD_SPEAKERMODE_SURROUND), 5)]
    [DataRow(nameof(FmodServerWrapper.FMOD_SPEAKERMODE_5POINT1), 6)]
    [DataRow(nameof(FmodServerWrapper.FMOD_SPEAKERMODE_7POINT1), 7)]
    [DataRow(nameof(FmodServerWrapper.FMOD_SPEAKERMODE_7POINT1POINT4), 8)]
    [DataRow(nameof(FmodServerWrapper.FMOD_SPEAKERMODE_MAX), 9)]
    public void FMOD_SPEAKERMODE_Constants_MatchExpectedValues(string name, int expected)
    {
        int actual = (int)typeof(FmodServerWrapper).GetField(name)!.GetRawConstantValue()!;
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_LOAD_BANK_NORMAL), 0)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_LOAD_BANK_NONBLOCKING), 1)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_LOAD_BANK_DECOMPRESS_SAMPLES), 2)]
    public void FMOD_STUDIO_LOAD_BANK_Constants_MatchExpectedValues(string name, int expected)
    {
        int actual = (int)typeof(FmodServerWrapper).GetField(name)!.GetRawConstantValue()!;
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_STOP_ALLOWFADEOUT), 0)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_STOP_IMMEDIATE), 1)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_STOP_FORCEINT), 65536)]
    public void FMOD_STUDIO_STOP_Constants_MatchExpectedValues(string name, int expected)
    {
        int actual = (int)typeof(FmodServerWrapper).GetField(name)!.GetRawConstantValue()!;
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_LOADING_STATE_UNLOADING), 0)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_LOADING_STATE_UNLOADED), 1)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_LOADING_STATE_LOADING), 2)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_LOADING_STATE_LOADED), 3)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_LOADING_STATE_ERROR), 4)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_LOADING_STATE_FORCEINT), 65536)]
    public void FMOD_STUDIO_LOADING_STATE_Constants_MatchExpectedValues(string name, int expected)
    {
        int actual = (int)typeof(FmodServerWrapper).GetField(name)!.GetRawConstantValue()!;
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_PLAYBACK_PLAYING), 0)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_PLAYBACK_SUSTAINING), 1)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_PLAYBACK_STOPPED), 2)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_PLAYBACK_STARTING), 3)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_PLAYBACK_STOPPING), 4)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_PLAYBACK_FORCEINT), 65536)]
    public void FMOD_STUDIO_PLAYBACK_Constants_MatchExpectedValues(string name, int expected)
    {
        int actual = (int)typeof(FmodServerWrapper).GetField(name)!.GetRawConstantValue()!;
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(nameof(FmodServerWrapper.FMOD_2D), 8)]
    [DataRow(nameof(FmodServerWrapper.FMOD_3D), 16)]
    [DataRow(nameof(FmodServerWrapper.FMOD_3D_HEADRELATIVE), 262144)]
    [DataRow(nameof(FmodServerWrapper.FMOD_3D_WORLDRELATIVE), 524288)]
    [DataRow(nameof(FmodServerWrapper.FMOD_3D_INVERSEROLLOFF), 1048576)]
    [DataRow(nameof(FmodServerWrapper.FMOD_3D_LINEARROLLOFF), 2097152)]
    [DataRow(nameof(FmodServerWrapper.FMOD_3D_LINEARSQUAREROLLOFF), 4194304)]
    [DataRow(nameof(FmodServerWrapper.FMOD_3D_INVERSETAPEREDROLLOFF), 8388608)]
    [DataRow(nameof(FmodServerWrapper.FMOD_3D_CUSTOMROLLOFF), 67108864)]
    [DataRow(nameof(FmodServerWrapper.FMOD_3D_IGNOREGEOMETRY), 1073741824)]
    public void FMOD_3D_Constants_MatchExpectedValues(string name, int expected)
    {
        int actual = (int)typeof(FmodServerWrapper).GetField(name)!.GetRawConstantValue()!;
        Assert.AreEqual(expected, actual);
    }

    [DataTestMethod]
    [DataRow(nameof(FmodServerWrapper.FMOD_DEFAULT), 0)]
    [DataRow(nameof(FmodServerWrapper.FMOD_LOOP_OFF), 1)]
    [DataRow(nameof(FmodServerWrapper.FMOD_LOOP_NORMAL), 2)]
    [DataRow(nameof(FmodServerWrapper.FMOD_LOOP_BIDI), 4)]
    [DataRow(nameof(FmodServerWrapper.FMOD_CREATESTREAM), 128)]
    [DataRow(nameof(FmodServerWrapper.FMOD_CREATESAMPLE), 256)]
    [DataRow(nameof(FmodServerWrapper.FMOD_CREATECOMPRESSEDSAMPLE), 512)]
    [DataRow(nameof(FmodServerWrapper.FMOD_OPENUSER), 1024)]
    [DataRow(nameof(FmodServerWrapper.FMOD_OPENMEMORY), 2048)]
    [DataRow(nameof(FmodServerWrapper.FMOD_OPENRAW), 4096)]
    [DataRow(nameof(FmodServerWrapper.FMOD_OPENONLY), 8192)]
    [DataRow(nameof(FmodServerWrapper.FMOD_ACCURATETIME), 16384)]
    [DataRow(nameof(FmodServerWrapper.FMOD_MPEGSEARCH), 32768)]
    [DataRow(nameof(FmodServerWrapper.FMOD_NONBLOCKING), 65536)]
    [DataRow(nameof(FmodServerWrapper.FMOD_UNIQUE), 131072)]
    [DataRow(nameof(FmodServerWrapper.FMOD_IGNORETAGS), 33554432)]
    [DataRow(nameof(FmodServerWrapper.FMOD_LOWMEM), 134217728)]
    [DataRow(nameof(FmodServerWrapper.FMOD_OPENMEMORY_POINT), 268435456)]
    public void FMOD_SoundMode_Constants_MatchExpectedValues(string name, int expected)
    {
        int actual = (int)typeof(FmodServerWrapper).GetField(name)!.GetRawConstantValue()!;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FMOD_VIRTUAL_PLAYFROMSTART_IsLongType()
    {
        Assert.AreEqual(2147483648L, FmodServerWrapper.FMOD_VIRTUAL_PLAYFROMSTART);
        Assert.IsInstanceOfType<long>(FmodServerWrapper.FMOD_VIRTUAL_PLAYFROMSTART);
    }

    [DataTestMethod]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_CREATED), 1)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_DESTROYED), 2)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_STARTING), 4)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_STARTED), 8)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_RESTARTED), 16)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_STOPPED), 32)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_START_FAILED), 64)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_CREATE_PROGRAMMER_SOUND), 128)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_DESTROY_PROGRAMMER_SOUND), 256)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_PLUGIN_CREATED), 512)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_PLUGIN_DESTROYED), 1024)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_TIMELINE_MARKER), 2048)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_TIMELINE_BEAT), 4096)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_SOUND_PLAYED), 8192)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_SOUND_STOPPED), 16384)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_REAL_TO_VIRTUAL), 32768)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_VIRTUAL_TO_REAL), 65536)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_START_EVENT_COMMAND), 131072)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_NESTED_TIMELINE_BEAT), 262144)]
    public void FMOD_STUDIO_EVENT_CALLBACK_Constants_MatchExpectedValues(string name, int expected)
    {
        int actual = (int)typeof(FmodServerWrapper).GetField(name)!.GetRawConstantValue()!;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FMOD_STUDIO_EVENT_CALLBACK_ALL_IsMaxUint()
    {
        Assert.AreEqual(0xFFFFFFFF, FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_ALL);
    }

    [DataTestMethod]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_SYSTEM_CALLBACK_PREUPDATE), 1)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_SYSTEM_CALLBACK_POSTUPDATE), 2)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_SYSTEM_CALLBACK_BANK_UNLOAD), 4)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_SYSTEM_CALLBACK_LIVEUPDATE_CONNECTED), 8)]
    [DataRow(nameof(FmodServerWrapper.FMOD_STUDIO_SYSTEM_CALLBACK_LIVEUPDATE_DISCONNECTED), 16)]
    public void FMOD_STUDIO_SYSTEM_CALLBACK_Constants_MatchExpectedValues(string name, int expected)
    {
        int actual = (int)typeof(FmodServerWrapper).GetField(name)!.GetRawConstantValue()!;
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void FMOD_STUDIO_SYSTEM_CALLBACK_ALL_IsMaxUint()
    {
        Assert.AreEqual(0xFFFFFFFF, FmodServerWrapper.FMOD_STUDIO_SYSTEM_CALLBACK_ALL);
    }

    [TestMethod]
    public void EventCallbackConstants_ArePowersOfTwo()
    {
        int[] callbacks =
        [
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_CREATED,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_DESTROYED,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_STARTING,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_STARTED,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_RESTARTED,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_STOPPED,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_START_FAILED,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_CREATE_PROGRAMMER_SOUND,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_DESTROY_PROGRAMMER_SOUND,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_PLUGIN_CREATED,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_PLUGIN_DESTROYED,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_TIMELINE_MARKER,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_TIMELINE_BEAT,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_SOUND_PLAYED,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_SOUND_STOPPED,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_REAL_TO_VIRTUAL,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_VIRTUAL_TO_REAL,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_START_EVENT_COMMAND,
            FmodServerWrapper.FMOD_STUDIO_EVENT_CALLBACK_NESTED_TIMELINE_BEAT,
        ];

        foreach (int flag in callbacks)
        {
            Assert.IsTrue((flag & (flag - 1)) == 0, $"Flag value {flag} is not a power of 2");
        }
    }
}

[TestClass]
public class PlaybackStateEnumTests
{
    [DataTestMethod]
    [DataRow(FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_PLAYING, 0)]
    [DataRow(FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_SUSTAINING, 1)]
    [DataRow(FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_STOPPED, 2)]
    [DataRow(FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_STARTING, 3)]
    [DataRow(FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_STOPPING, 4)]
    [DataRow(FMOD_STUDIO_PLAYBACK_STATE.FMOD_STUDIO_PLAYBACK_FORCEINT, 65536)]
    public void PlaybackState_HasCorrectValue(FMOD_STUDIO_PLAYBACK_STATE state, int expectedValue)
    {
        Assert.AreEqual(expectedValue, (int)state);
    }

    [TestMethod]
    public void PlaybackState_HasExactly6Values()
    {
        Assert.AreEqual(6, Enum.GetValues<FMOD_STUDIO_PLAYBACK_STATE>().Length);
    }
}
