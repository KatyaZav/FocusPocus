using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class Saves : MonoBehaviour
{
    void Awake()
    {
        Diamonds = PlayerPrefs.GetInt(Diamond, 0);
        Record = PlayerPrefs.GetInt(Records, 0);
        Points = 0;
    }

    public static int Diamonds { get; private set;}
    public static int Points { get; private set; }
    public static int Record { get; private set; }

    public readonly static string Diamond = "Diamonds";
    public readonly static string Records = "Records";
    public readonly static string Point = "Points";

    public static void AddDiamonds(int count = 1)
    {
        Diamonds += count;
        PlayerPrefs.SetInt(Diamond, Diamonds);
    }

    public static bool Buy(int count)
    {
        if (Diamonds >= count)
        {
            Diamonds -= count;
            PlayerPrefs.SetInt(Diamond, Diamonds);
            return true;
        }
        else
            return false;
    } 

    public static void MakeRecord(int count = 1)
    {
        if (count > Record)
        {
            Record = count;
            PlayerPrefs.SetInt(Records, Record);
        }
    }

    public static void AddPoint(int count = 1)
    {
        Points += count;
        PlayerPrefs.SetInt(Point, Points);
    }

    public static void ResetPoints()
    {
        Points = 0;
        PlayerPrefs.SetInt(Point, Points);
    }

    public static void SavePr()
    {
        if (Record < Points)
        {
            Record = Points;
            PlayerPrefs.SetInt(Records, Record);
            YandexGame.NewLeaderboardScores("MainLeaderBoard", Record);
        }
        else Points = 0;

        YandexGame.NewLeaderboardScores("DiamondsLeaderBoard", Diamonds);

        MetricaSend();
    }

    static void MetricaSend()
    {
        var eventParams = new Dictionary<string, string>
        {
            { "Game points", Points.ToString()},
            { "Game records", Records.ToString()},
            { "Devise type", YandexGame.EnvironmentData.deviceType},
        };

        YandexMetrica.Send(AllSkins.Instanse.AllSkinsInfo[AllSkins.currentSkin].Name, eventParams);

        eventParams = new Dictionary<string, string>
        {
            { "Skin name", AllSkins.Instanse.AllSkinsInfo[AllSkins.currentSkin].Name},
            { "Diamonds", Saves.Diamonds.ToString()},
            { "Game points", Points.ToString()},
        };

        YandexMetrica.Send("Best skin", eventParams);
    }
}
