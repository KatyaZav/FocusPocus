using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour, ICollecteble
{
    [SerializeField] Moving _move;
    [SerializeField] string _tagUI;
    [SerializeField] GameObject _effect;
    [SerializeField] Animator _anim;

    bool isCollected = false;

    public void Collect()
    {
        if (!isCollected)
        {
            isCollected = true;
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

        Instantiate(_effect, transform);
        _move.StopMoveChaous(UI.gameObject.transform.position);
    }
}
