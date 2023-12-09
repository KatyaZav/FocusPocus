using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class changeUIDevice : MonoBehaviour
{
    [SerializeField] GameObject mobile;
    [SerializeField] GameObject pc;

    private void Awake()
    {
        if (YandexGame.EnvironmentData.isMobile)
        {
            ChangeToPc(false);
        }

        if (YandexGame.EnvironmentData.isDesktop || YandexGame.EnvironmentData.isTablet)
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
