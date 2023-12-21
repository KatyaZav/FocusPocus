using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    public GameObject rus;
    public GameObject eng;

    public static string Lang = "Language";

    private void Awake()
    {
        var y = PlayerPrefs.GetString(Lang, LanguageType.ru.ToString()) == LanguageType.ru.ToString();

        rus.SetActive(!y);
        eng.SetActive(y);
    }
}

public enum LanguageType 
{
    ru,
    eng
}
