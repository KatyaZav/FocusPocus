using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Language : MonoBehaviour
{
    public GameObject rus;
    public GameObject eng;

    private void Awake()
    {
        var y = YG.YandexGame.EnvironmentData.language == "ru";

        rus.SetActive(!y);
        eng.SetActive(y);
    }
}
