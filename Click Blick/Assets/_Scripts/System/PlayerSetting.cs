using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerSetting 
{
    public static bool IsMusicMute { private set; get;}
    public static bool IsSoundMute { private set; get;}

    /// <summary>
    /// Update sound settings 
    /// </summary>
    public static void UpdateSoundMute(bool isMute)
    {
        IsSoundMute = isMute;
        Debug.Log("Save to YSDK");
        MusicBox.Instance.UpdateVolumeSettings(IsMusicMute, IsSoundMute);
    }

    /// <summary>
    /// Update music settings 
    /// </summary>
    public static void UpdateMusicMute(bool isMute)
    {
        IsMusicMute = isMute;
        Debug.Log("Save to YSDK");
        MusicBox.Instance.UpdateVolumeSettings(IsMusicMute, IsSoundMute);
    }

    public static int Diamonds { private set; get; }
    public static int Record { private set; get; }
    public static int CurrentRecord { private set; get; }

    /// <summary>
    /// Update record if player get more points
    /// </summary>
    public static void UpdateRecord(int sum)
    {
        if (Record < sum)
        {
            Record = sum;
            Debug.LogWarning("Save to SDK");
            Debug.LogWarning("Leaderbord update");
        }
    }

    /// <summary>
    /// Add more coins
    /// </summary>
    /// <param name="sum"></param>
    /// <exception cref="System.Exception"></exception>
    public static void AddCoin(int sum)
    {
        if (sum > 0)
        {
            Diamonds += sum;
            Debug.LogWarning("Save to SDK");
        }
        else throw new System.Exception("Trying to add under zero coins");
    }

    /// <summary>
    /// Add record points
    /// </summary>
    public static void AddCurrentRecord(int sum)
    {
        CurrentRecord += sum;
    }
}
