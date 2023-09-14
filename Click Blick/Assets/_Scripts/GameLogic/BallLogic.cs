using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Animator _anim;

    [SerializeField] GameObject effect;
    [SerializeField] Sprite  _img;

    [SerializeField] PlayerPreferences _playerPref;
    Camera _cam;

    private void Start()
    {
        Debug.Log("Загрузка скина и эффектов");
       _playerPref.UpdateBallSkinInfo();

        _cam = Camera.main;

        if (rb == null)       
            rb = GetComponent<Rigidbody2D>();
        if (_anim == null)
            _anim = GetComponent<Animator>();
    }
    
    private void OnMouseDown()
    {
        OnTouched();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _anim.SetTrigger("borders");
    }

    /// <summary>
    /// Action happend on mouse click on ball
    /// </summary>
    void OnTouched()
    {
        Debug.Log("Tap");

        if (effect != null)
            Instantiate(effect, transform.position, Quaternion.identity);
        _anim.SetTrigger("touched");
        Upped();
    }

    /// <summary>
    /// Ball fly up
    /// </summary>
    void Upped()
    {
        rb.velocity = new Vector2(0, 0);
        
        var mousePosWorld = _cam.ScreenToWorldPoint(Input.mousePosition);
        var sum = 0f;

        if (Mathf.Abs(transform.position.x - mousePosWorld.x) >= 0.1)
            sum = (transform.position.x - mousePosWorld.x);

        rb.AddForce(new Vector2(
            sum * 2, 1-Mathf.Abs(sum)) * 300);
    }
}
