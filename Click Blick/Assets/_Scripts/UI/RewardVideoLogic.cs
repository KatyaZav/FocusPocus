using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardVideoLogic : MonoBehaviour
{
    public static RewardVideoLogic Instance;
    private bool isFirstAd = true;

    [SerializeField] private GameObject Video;
    [SerializeField] private GameObject EndMenu;

    public static Action<bool> ChangeGamePauseSettingsToResume;

    private void OnEnable()
    {
        if (Instance == null)
            Instance = this;

        BallLogic.PlayerDead += OnGameEnd;
        YG.YandexGame.RewardVideoEvent += Continue;
        YG.YandexGame.ErrorVideoEvent += EndGame;
    }
    private void OnDisable()
    {
        BallLogic.PlayerDead -= OnGameEnd;
        YG.YandexGame.RewardVideoEvent -= Continue;
        YG.YandexGame.ErrorVideoEvent -= EndGame;
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
            Video.SetActive(true);
            isFirstAd = false;
        }
        else EndGame();
    }

    /// <summary>
    /// End game and open result menu
    /// </summary>
    public void EndGame()
    {
        Debug.Log("End game");
        ChangeGamePauseSettingsToResume?.Invoke(false);
        EndMenu.SetActive(true);
    }
}
