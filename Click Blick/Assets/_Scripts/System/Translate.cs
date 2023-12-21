using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Translate : MonoBehaviour
{
    public string Rus;
    public string Eng;

    Text text;
    TextMeshProUGUI textMesh;


    void Start()
    {
        if (PlayerPrefs.GetString(Language.Lang, LanguageType.ru.ToString()) == LanguageType.ru.ToString())
        {
            text.text ??= Rus;
            textMesh.text ??= Rus;
        }
        else
        {
            text.text ??= Eng;
            textMesh.text ??= Eng;
        }        
    }
}
