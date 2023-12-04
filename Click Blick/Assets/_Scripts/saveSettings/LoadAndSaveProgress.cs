using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class LoadAndSaveProgress : MonoBehaviour
{
    private void OnEnable() => YandexGame.GetDataEvent += loadProgress;
    private void OnDisable() => YandexGame.GetDataEvent -= loadProgress;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
            loadProgress();
        YandexGame.savesData.skins["skin" + 0] = 1;
    }

    private static void loadProgress()
    {
        Debug.Log("LoadProgress");
        PlayerPrefs.SetInt(Saves.Diamond, YandexGame.savesData.Diamond);
        PlayerPrefs.SetInt(Saves.Records, YandexGame.savesData.Record);

        PlayerPrefs.SetInt("currentSkin", YandexGame.savesData.currentSkin);

        for (var i = 1; i < 6; i++)
        {
            if (!YandexGame.savesData.skins.ContainsKey("skin" + i))
                YandexGame.savesData.skins["skin" + i] = 0;

            PlayerPrefs.SetInt("skin"+i, YandexGame.savesData.skins["skin"+i]);
        }
    }

    public static void SaveProgress()
    {
        YandexGame.savesData.Diamond = PlayerPrefs.GetInt(Saves.Diamond);
        YandexGame.savesData.Record = PlayerPrefs.GetInt(Saves.Records);

        YandexGame.savesData.currentSkin = PlayerPrefs.GetInt("currentSkin");

        for (var i = 1; i < 6; i++)
        {
            YandexGame.savesData.skins["skin" + i] = PlayerPrefs.GetInt("skin" + i, 0);
        }

        YandexGame.SaveProgress();
    }
}
