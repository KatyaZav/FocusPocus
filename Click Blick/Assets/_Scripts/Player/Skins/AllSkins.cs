using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllSkins : MonoBehaviour
{
    public static AllSkins Instanse;

    public Skin[] AllSkinsInfo;
    public static int currentSkin = 0;

    public static Action ChangedSkin; 

    /// <summary>
    /// Change current skin index
    /// </summary>
    public void ChangeSkin(bool isLeftButton)
    {
        if (isLeftButton)
        {
            if (currentSkin == 0)
                currentSkin = AllSkinsInfo.Length - 1;
            else
                currentSkin -= 1;
        }
        else
        {
            if (currentSkin == AllSkinsInfo.Length-1)
                currentSkin = 0;
            else currentSkin += 1;
        }

        Debug.Log("Skin changed to " + Instanse.AllSkinsInfo[currentSkin].Name);
        ChangedSkin?.Invoke();
    }

    private void Awake()
    {
        if (Instanse == null)
            Instanse = this;

        if (AllSkinsInfo.Length == 0)
            Debug.LogError("There are no skins");
    }
}
