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
        //YandexGame.savesData.skins["skin0"] = 1;
    }

    private static void loadProgress()
    {
        Debug.Log("LoadProgress");

        Debug.Log(YandexGame.savesData.skins);

        /*if (!YandexGame.savesData.skins.ContainsKey("skin0"))
        {
            YandexGame.savesData.skins["skin0"] = 1;
        }*/

        PlayerPrefs.SetInt(Saves.Diamond, YandexGame.savesData.Diamond);
        PlayerPrefs.SetInt(Saves.Records, YandexGame.savesData.Record);

        PlayerPrefs.SetInt("currentSkin", YandexGame.savesData.currentSkin);

        PlayerPrefs.SetInt("skin0", (YandexGame.savesData.skins["skin0"]));

        for (var i = 1; i <= AllSkins.Instanse.AllSkinsInfo.Length+1; i++)
        {
            if (!YandexGame.savesData.skins.ContainsKey("skin" + i.ToString()))
                YandexGame.savesData.skins["skin" + i.ToString()] = 0;

            //Debug.Log(YandexGame.savesData.skins["skin" + i.ToString()]);
            PlayerPrefs.SetInt("skin"+i.ToString(), YandexGame.savesData.skins["skin"+i.ToString()]);
            //Debug.Log(YandexGame.savesData.skins["skin" + i.ToString()]);
        }
    }

    public static void SaveProgress()
    {
        Debug.Log("Save progress data");

        YandexGame.savesData.Diamond = PlayerPrefs.GetInt(Saves.Diamond);
        YandexGame.savesData.Record = PlayerPrefs.GetInt(Saves.Records);

        YandexGame.savesData.currentSkin = PlayerPrefs.GetInt("currentSkin");

        for (var i = 1; i <= AllSkins.Instanse.AllSkinsInfo.Length+1; i++)
        {
            YandexGame.savesData.skins["skin" + i.ToString()] = PlayerPrefs.GetInt("skin" + i.ToString());
            //Debug.Log(YandexGame.savesData.skins["skin" + i.ToString()]);
        }

        YandexGame.SaveProgress();
    }
}
