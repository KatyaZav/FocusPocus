using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour, ICollecteble
{
    [SerializeField] Moving _move;
    [SerializeField] string _tagUI;
    [SerializeField] GameObject _effect;

    public void Collect()
    {
        _move.StartCoroutine("moveChous");
        StartCoroutine("Moving");
    }

    IEnumerable Moving()
    {
        var UI = GameObject.FindGameObjectWithTag(_tagUI);

        if (UI == null)
            throw new System.Exception("Wrong tag added");

        var i = 0;
        while (i < 10)
        {
            transform.position = Vector2
                   .Lerp(transform.position, Vector2.down, 4);
            i++;
            yield return new WaitForFixedUpdate();
        }

        Instantiate(_effect, transform);
        _move.StartCoroutine("Move");
    }
}
