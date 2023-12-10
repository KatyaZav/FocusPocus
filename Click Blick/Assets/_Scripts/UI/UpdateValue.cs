using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateValue : MonoBehaviour
{
    [SerializeField] Value _valueUI;
    Text _text;

    private void OnDisable()
    {
        UiManager.Bought -= UpdateValueUI;
    }

    private void OnEnable()
    {
        _text = GetComponentInChildren<Text>();
        UiManager.Bought += UpdateValueUI;

        UpdateValueUI();
    }

    public void UpdateValueUI()
    {
        if (_valueUI == Value.diamond)
        {
            _text.text = PlayerPrefs.GetInt(Saves.Diamond, 0).ToString();//Saves.Diamonds.ToString();
        }


        if (_valueUI == Value.point)
        {
            _text.text = PlayerPrefs.GetInt(Saves.Point, 0).ToString();//Saves.Points.ToString();
        }

        if (_valueUI == Value.record)
            _text.text = PlayerPrefs.GetInt(Saves.Records, 0).ToString();//Saves.Record.ToString();
    }
}

[System.Serializable]
public enum Value
{
    diamond,
    point,
    record
};
