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
        YG.YandexGame.savesData.isSound = isMute;
        MusicBox.Instance.UpdateVolumeSettings(IsMusicMute, IsSoundMute);
    }

    /// <summary>
    /// Update music settings 
    /// </summary>
    public static void UpdateMusicMute(bool isMute)
    {
        IsMusicMute = isMute;
        YG.YandexGame.savesData.isMusic = isMute;
        MusicBox.Instance.UpdateVolumeSettings(IsMusicMute, IsSoundMute);
    }    
}
