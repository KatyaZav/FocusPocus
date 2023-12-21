using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using YG;

public class UpdateValue : MonoBehaviour
{
    [SerializeField] Value _valueUI;
    [SerializeField] Text _text;

    private void OnValidate()
    {
        _text ??= GetComponentInChildren<Text>();
    }

    private void OnDisable()
    {
        UiManager.Bought -= UpdateValueUI;
        //YandexGame.GetDataEvent -= UpdateValueUI;
    }

    private void OnEnable()
    {        
        UiManager.Bought += UpdateValueUI;
        //YandexGame.GetDataEvent += UpdateValueUI;

        //if (YandexGame.SDKEnabled)
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
