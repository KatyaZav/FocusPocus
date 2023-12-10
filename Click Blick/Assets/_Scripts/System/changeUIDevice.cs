using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class changeUIDevice : MonoBehaviour
{
    [SerializeField] GameObject mobile;
    [SerializeField] GameObject pc;

    private void OnEnable() => YandexGame.GetDataEvent += Starter;
    private void OnDisable() => YandexGame.GetDataEvent -= Starter;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
            Starter();
    }

    private void Starter()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            ChangeToPc(false);
        }
        else
       // if (YandexGame.EnvironmentData.isDesktop)
        {
            ChangeToPc(true);
        }

    }

    void ChangeToPc(bool isPK)
    {
        mobile.SetActive(!isPK);
        pc.SetActive(isPK);
    }
}
