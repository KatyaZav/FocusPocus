using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour, ICollecteble
{
    [SerializeField] Moving _move;
    [SerializeField] string _tagUI;
    [SerializeField] GameObject _effect;
    [SerializeField] Animator _anim;

    public bool isCollected = false;
    public Value value;
    public static Action<Value> CollectedObj;

    public void Collect()
    {
        if (!isCollected)
        {
            Debug.Log("Collected");
            Moving();
        }
    }
    private void Moving()
    {
        _anim.SetTrigger("collected");

        var UI = GameObject.FindGameObjectWithTag(_tagUI);

        if (UI == null)
            throw new System.Exception("Wrong tag added");

        isCollected = true;
        Instantiate(_effect, transform);
        _move.StopMoveChaous(UI.gameObject.transform.position);

        Invoke("Act", 1.5f);
    }

    void Act()
    {
        CollectedObj?.Invoke(value);
    }
}
