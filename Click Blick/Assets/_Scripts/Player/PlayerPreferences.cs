using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPreferences : MonoBehaviour
{
    Skin _skin;

    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] Animator _anim;
    [SerializeField] Rigidbody2D _rb;

    public void UpdateBallSkinInfo()
    {
        _skin = AllSkins.Instanse.AllSkinsInfo[AllSkins.currentSkin];

        _sprite.sprite = _skin.SpriteImage;

        if (!_skin.CheckStandartPhysics())
        {
            _rb.gravityScale = _skin.gravity;
            _rb.mass = _skin.mass;
        }
    }
}
