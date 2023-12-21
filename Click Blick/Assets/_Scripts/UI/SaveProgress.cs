using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveProgress : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void OnEnable()
    {
        Debug.Log("Save game result");
        text.text = PlayerPrefs.GetInt(Saves.Point).ToString();
        Saves.SavePr();
        //LoadAndSaveProgress.SaveProgress();
    }
}
