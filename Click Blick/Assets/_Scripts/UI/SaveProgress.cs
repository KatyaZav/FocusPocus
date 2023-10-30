using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveProgress : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void OnEnable()
    {
        text.text = PlayerPrefs.GetInt(Saves.Point).ToString();
        Saves.SavePr();
    }
}
