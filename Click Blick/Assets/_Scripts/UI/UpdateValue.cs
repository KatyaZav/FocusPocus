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
    }

    private void OnEnable()
    {
        UpdateValueUI();
    }

    public void UpdateValueUI()
    {
        if (_valueUI == Value.diamond)
            _text.text = Saves.Diamonds.ToString();

        if (_valueUI == Value.point)
            _text.text = Saves.Points.ToString();

        if (_valueUI == Value.record)
            _text.text = Saves.Record.ToString();
    }
}

[System.Serializable]
public enum Value
{
    diamond,
    point,
    record
};
