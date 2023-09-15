using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    [SerializeField] PlayerLogic _playerLogic;
    
    [SerializeField] LayerMask _borderLayer, _enemyLayer;

    public static Action PlayerDead;

    private bool _isNotPause = true;

    void Start()
    {
       _playerLogic.UpdateBallSkinInfo();
    }
    
    void OnMouseDown()
    {
        OnTouched();
    }

   void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isNotPause)
        {
            if (LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) == _borderLayer.value)
                _playerLogic.SetTrigger("borders");

            if (LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) == _enemyLayer.value)
            {
                PlayerDead?.Invoke();
            }
        }
    }

    /// <summary>
    /// Action happend on mouse click on ball
    /// </summary>
    void OnTouched()
    {
        if (_isNotPause)
        {
            Debug.Log("Tap");

            _playerLogic.SetTrigger("touched");
            _playerLogic.MakeEffect();
            _playerLogic.Kick();
        }
    }

    private void ChangePause(bool pause)
    {
        _isNotPause = pause;

        if (pause == false)
            GetComponent<Rigidbody2D>().Sleep();
        else
        {
            transform.position = new Vector2(0, 0);
            GetComponent<Rigidbody2D>().WakeUp();
        }
    }

    private void Awake()
    {
        RewardVideoLogic.ChangeGamePauseSettingsToResume += ChangePause;
    }

    private void OnDestroy()
    {
        RewardVideoLogic.ChangeGamePauseSettingsToResume -= ChangePause;
    }
}
