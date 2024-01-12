using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{
    [SerializeField] SoundsMassive[] _sounds;
    [SerializeField] PlayerLogic _playerLogic;
    
    [SerializeField] LayerMask _borderLayer, _enemyLayer, _itemsLayer, bamLayer;
    [SerializeField] GameObject dead;

    public static Action PlayerDead;

    private bool _isNotPause = true;

    void Start()
    {
       _playerLogic.UpdateBallSkinInfo();
    }
    
    void OnMouseDown()
    {
        //OnTouched();
    }

   void OnCollisionEnter2D(Collision2D collision)
    {       
        if (checkEqualMask(_borderLayer.value, collision) || checkEqualMask(_enemyLayer.value, collision))
        {
            _playerLogic.SetTrigger("borders");
            _playerLogic.SmashBall(collision.gameObject.transform);
            playSound(2);
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_isNotPause)
        {
            if (checkEqualMask(_itemsLayer.value, collision))
            {
                ICollecteble obj = collision.gameObject.GetComponent<ICollecteble>();
                obj.Collect();

                playSound(1);
            }

            if (checkEqualMask(_enemyLayer.value, collision))
            {
                dead.SetActive(true);
                //Instantiate(dead, gameObject.transform.position, Quaternion.identity);
                //_playerLogic.MakeEffect();
                PlayerDead?.Invoke();
            }

            if (checkEqualMask(bamLayer.value, collision))
                OnTouched();
        }
    }

    /// <summary>
    /// Checked if toched gameObject have same mask with layer
    /// </summary>
    bool checkEqualMask(LayerMask layer, Collision2D collision)
    {
        return LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) == layer.value;
    }

    bool checkEqualMask(LayerMask layer, Collider2D collision)
    {
        return LayerMask.GetMask(LayerMask.LayerToName(collision.gameObject.layer)) == layer.value;
    }

    /// <summary>
    /// play random sound of massive 
    /// </summary>
    void playSound(int index)
    {
        MusicBox.Instance.PlaySound(
                 _sounds[index].clips[UnityEngine.Random.Range(0, _sounds[index].clips.Length)]);
    }

    /// <summary>
    /// Action happend on mouse click on ball
    /// </summary>
    void OnTouched()
    {
        if (_isNotPause)
        {
            _playerLogic.SetTrigger("touched");
            _playerLogic.MakeEffect();
            _playerLogic.Kick();

            playSound(0);
        }
    }

    public static Action StartedAgain;

    private void ChangePause(bool pause)
    {
        _isNotPause = pause;

        if (pause == false)
            GetComponent<Rigidbody2D>().Sleep();
        else
        {
            StartedAgain?.Invoke();

            ImageTimer.pause = true;
            transform.position = new Vector2(0, 0);
            _playerLogic.MakeVelocity();
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

[System.Serializable]
public class SoundsMassive
{
    public string name;
    public AudioClip[] clips;
}
