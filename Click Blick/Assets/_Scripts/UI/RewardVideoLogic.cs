using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardVideoLogic : MonoBehaviour
{
    public static RewardVideoLogic Instance;
    private bool isFirstAd = true;

    [SerializeField] private GameObject Video;
    [SerializeField] private GameObject EndMenuPc;
    [SerializeField] private GameObject EndMenuMobile;

    public static Action<bool> ChangeGamePauseSettingsToResume;

    private void OnEnable()
    {
        if (Instance == null)
            Instance = this;

        BallLogic.PlayerDead += OnGameEnd;
        //YG.YandexGame.RewardVideoEvent += Continue;
        //YG.YandexGame.ErrorVideoEvent += EndGame;
    }
    private void OnDisable()
    {
        BallLogic.PlayerDead -= OnGameEnd;
        //YG.YandexGame.RewardVideoEvent -= Continue;
        //YG.YandexGame.ErrorVideoEvent -= EndGame;
    }

    void Continue(int a)
    {
        Debug.Log("Continue " + a.ToString());

        if (a==10)
            ChangeGamePauseSettingsToResume?.Invoke(true);
    }

    /// <summary>
    /// Try to offer reward video
    /// </summary>
    void OnGameEnd()
    {
        if (isFirstAd)
        {
            ChangeGamePauseSettingsToResume?.Invoke(false);
            Invoke("OpenVideo", 0.7f);
            isFirstAd = false;
        }
        else Invoke("EndGame", 0.7f);
    }

    void OpenVideo()
    {
        Video.SetActive(true);
    }

    /// <summary>
    /// End game and open result menu
    /// </summary>
    public void EndGame()
    {
        EndMenuPc.SetActive(true);
        EndMenuMobile.SetActive(true);

        Debug.Log("End game" + gameObject.name);

        ChangeGamePauseSettingsToResume?.Invoke(false);
    }
}
