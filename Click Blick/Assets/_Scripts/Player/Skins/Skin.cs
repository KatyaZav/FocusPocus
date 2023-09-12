using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skin
{
    public string Name;

    public int Cost;
    public Sprite SpriteImage;
    public GameObject Effect;
    public AudioSource Sound;

    public float mass = 1;
    public float gravity = 0.2f;

    /// <summary>
    /// Return true if standart physics settings
    /// </summary>
    public bool CheckStandartPhysics()
    {
        if (mass != 1 || gravity != 0.2)
            return false;
        return true;
    }
}
