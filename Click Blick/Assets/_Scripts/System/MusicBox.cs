using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBox : MonoBehaviour
{
    [Header("Сила искажения")]
    [Range(0, 0.5f)]
    [SerializeField] float _pitch;

    public static MusicBox Instance;

    AudioSource sound;
    AudioSource music;

    private void Awake()
    {
        var ite = GetComponentsInChildren<AudioSource>();
        music = ite[0];
        sound = ite[1];

        if (Instance == null)
            Instance = this;

        UpdateVolumeSettings(PlayerSetting.IsMusicMute, PlayerSetting.IsSoundMute);
    }

    /// <summary>
    /// Play sound with this volume 
    /// </summary> 
    public void PlaySound(AudioClip clip, float volume = 0.2f)
    {
        sound.pitch = Random.Range(1 - _pitch, 1 + _pitch);
        sound.PlayOneShot(clip, volume);
    }

    /// <summary>
    /// Make mute or unmute sounds and music
    /// </summary>
    public void UpdateVolumeSettings(bool isMusicMute = false, bool isSoundMute = false)
    {
        sound.mute = isSoundMute;
        music.mute = isMusicMute;
    }
}
