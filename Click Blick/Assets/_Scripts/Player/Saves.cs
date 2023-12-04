using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            YG.YandexGame.NewLeaderboardScores("MainLeaderBoard", Record);
        }
        else Points = 0;
    }
}
