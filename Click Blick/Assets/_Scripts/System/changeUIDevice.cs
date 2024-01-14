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
        Debug.Log(SystemInfo.deviceType);

        if (YandexGame.EnvironmentData.isDesktop)
        {
            ChangeToPc(true);
            return;
        }

       if (YandexGame.EnvironmentData.isMobile)
        {
            ChangeToPc(false);
            return;
        }

        ChangeToPc(true);
        Debug.LogWarning("unknown device type");
    }

    void ChangeToPc(bool isPK)
    {
        mobile.SetActive(!isPK);
        pc.SetActive(isPK);
    }
}
