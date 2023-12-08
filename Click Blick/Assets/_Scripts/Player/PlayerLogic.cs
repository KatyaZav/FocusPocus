using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLogic : MonoBehaviour
{
    Skin _skin;

    [SerializeField] SpriteRenderer _sprite;
    [SerializeField] Animator _anim;
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] GameObject _smashEffect;

    /// <summary>
    /// Update all settings of ball
    /// </summary>
    public void UpdateBallSkinInfo()
    {
        Debug.Log("Current skin " + AllSkins.currentSkin);
        _skin = AllSkins.Instanse.AllSkinsInfo[AllSkins.currentSkin];
        

        _sprite.sprite = _skin.SpriteImage;
        _rb.sharedMaterial = _skin.BallMaterial;


        if (!_skin.CheckStandartPhysics())
        {
            _rb.gravityScale = _skin.gravity;
            _rb.mass = _skin.mass;
        }

        _smashEffect = _skin.SmashMaskSprite;
    }

    /// <summary>
    /// Kick the ball
    /// </summary>
    public void Kick()
    {
        _rb.velocity = new Vector2(0, 0);

        var mousePosWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var sum = 0f;

        if (Mathf.Abs(transform.position.x - mousePosWorld.x) >= 0.1)
            sum = (transform.position.x - mousePosWorld.x);

        _rb.AddForce(new Vector2(
            sum * 2, 1 - Mathf.Abs(sum)) * 300);
    }

    /// <summary>
    /// Make random ball effect
    /// </summary>
    public void MakeEffect()
    {
        var _ef = _skin.ReturnEffect();

        if (_ef == null) 
            return;
        
        Instantiate(_ef, transform.position, Quaternion.identity);
    }

    public void MakeSound()
    {
        Debug.LogWarning("Have no sounds");
    }

    /// <summary>
    /// Set trigger animation with name
    /// </summary>
    public void SetTrigger(string name)
    {
        _anim.SetTrigger(name);
    }

    /// <summary>
    /// Make sprite mask effect on walls ond borders
    /// </summary>
    public void SmashBall(Transform tr)
    {
        if (_smashEffect)
        {
            var obj = Instantiate(_smashEffect, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
            obj.transform.SetParent(tr, true);

            StartCoroutine(Destroy(obj));

            IEnumerator Destroy(GameObject obj)
            {
                var img = obj.GetComponentInChildren<SpriteRenderer>();
                yield return new WaitForSeconds(2);

                while(img!= null && img.color.a > 0)
                {
                    img.color = new Color(img.color.b, img.color.g, img.color.b, img.color.a-0.1f);
                    yield return new WaitForSeconds(1);
                }

                Destroy(obj);
            }
        }
    }
}
