using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesMouse : MonoBehaviour
{
    [SerializeField] GameObject mouseEffect;

    GameObject _mouseEffect;

    void Start()
    {
       _mouseEffect = Instantiate(mouseEffect, _updatePos(), Quaternion.identity);
    }

    private void Update()
    {
        _mouseEffect.transform.position = _updatePos();
    }

    Vector3 _updatePos()
    {
        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); ;
        pos.z = 2;

        return pos;
    }
}
