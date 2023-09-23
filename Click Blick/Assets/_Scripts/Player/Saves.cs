using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Saves
{
    public static int Diamonds { get; private set; }
    public static int Points { get; private set; }
    public static int Record { get; private set; }

    public static void AddDiamonds(int count = 1)
    {
        Diamonds += count;
    }

    public static bool Buy(int count)
    {
        if (Diamonds >= count)
        {
            Diamonds -= count;
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
        }
    }

    public static void AddPoint(int count = 1)
    {
        Points += count;
    }
}
