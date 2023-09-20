using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Skin 
{
    public string Name;
    public bool isBought = false;

    public int Cost;
    public Sprite SpriteImage;
    public GameObject SmashMaskSprite;
    
    [SerializeField] GameObject[] Effect;
    [SerializeField] AudioSource[] Sound;
    //[SerializeField] GameObject BloopMaskEffect;

    public float mass = 1, gravity = 0.2f;

    public PhysicsMaterial2D BallMaterial;

    /// <summary>
    /// Return true if standart physics settings
    /// </summary>
    public bool CheckStandartPhysics()
    {
        if (mass != 1 || gravity != 0.2)
            return false;
        return true;
    }

    /// <summary>
    /// Return sound effect
    /// </summary>
    public AudioSource ReturnSound(){
        if (Sound.Length == 0)
            return null;

        return Sound[Random.Range(0, Effect.Length)];
    }

    /// <summary>
    /// Return particle effect
    /// </summary>
    public GameObject ReturnEffect()
    {
        if (Effect.Length == 0)
            return null;
        
        return Effect[Random.Range(0, Effect.Length)];  
    }
}
