using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateValue : MonoBehaviour
{
    [SerializeField] Value _valueUI;
    Text _text;

    private void Awake()
    {
        _text = GetComponentInChildren<Text>();
        Debug.Log(_valueUI.ToString());
    }

    private void OnEnable()
    {
        if (_valueUI == Value.diamond)
            _text.text = PlayerSetting.Diamonds.ToString();

        if (_valueUI == Value.points)
            _text.text = PlayerSetting.CurrentRecord.ToString();

        if (_valueUI == Value.record)
            _text.text = PlayerSetting.Record.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _valueUI.ToString())
        {
            Destroy(collision.gameObject);
        }
    }
}

[System.Serializable]
public enum Value
{
    diamond,
    points,
    record
};
