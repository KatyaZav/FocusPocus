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
    }

    private void OnEnable()
    {
        if (_valueUI == Value.diamond)
            _text.text = PlayerSetting.Diamonds.ToString();

        if (_valueUI == Value.currentRecord)
            _text.text = PlayerSetting.CurrentRecord.ToString();

        if (_valueUI == Value.record)
            _text.text = PlayerSetting.Record.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}

[System.Serializable]
public enum Value
{
    diamond,
    currentRecord,
    record
};
