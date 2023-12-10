using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using YG;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject[] soundGM; 
    [SerializeField] GameObject[] musicGM; 

    void Start()
    {
        if (YandexGame.SDKEnabled)
            Starter();
    }

    private void OnEnable() => YandexGame.GetDataEvent += Starter;
    private void OnDisable() => YandexGame.GetDataEvent -= Starter;

    void Starter()
    {
        AllSkins.ChangedSkin += UpdateSkin;
        YG.YandexGame.RewardVideoEvent += Try;

        AllSkins.currentSkin = PlayerPrefs.GetInt("currentSkin", 0);
        UpdateSkin();

        if (soundGM.Length == 2)
        {
            MuteMusic(YG.YandexGame.savesData.isMusic);
            MuteSound(YG.YandexGame.savesData.isSound);

            Act(musicGM, !YG.YandexGame.savesData.isMusic);
            Act(soundGM, !YG.YandexGame.savesData.isSound);
        }
    }

    void Act(GameObject[] objs, bool isFirst)
    {
        objs[0].SetActive(isFirst);
        objs[1].SetActive(!isFirst);
    }

    private void OnDestroy()
    {
        AllSkins.ChangedSkin -= UpdateSkin;
        YG.YandexGame.RewardVideoEvent -= Try;
    }

    [SerializeField] Image _playerImage;
    [SerializeField] TMP_Text _cost;

    [SerializeField] Button _buttonStart;
    [SerializeField] Button _buttonBuy;
    [SerializeField] Button _buttonTry;
    

    /// <summary>
    /// Update skin ui
    /// </summary>
    private void UpdateSkin()
    {
        if (_playerImage == null) return;

        var _skin = AllSkins.Instanse.AllSkinsInfo[AllSkins.currentSkin];

        _skin.isBought = PlayerPrefs.GetInt("skin" + AllSkins.currentSkin.ToString()) == 1;

        _playerImage.sprite = _skin.SpriteImage;

        if (_skin.isBought)
        {
            _cost.text = "";

            _buttonStart.gameObject.SetActive(true);                
            _buttonBuy.gameObject.SetActive(false);
            _buttonTry.gameObject.SetActive(false);
        }
        else
        {
            _cost.text = _skin.Cost.ToString();

            _buttonStart.gameObject.SetActive(false);

            bool u = (_skin.Cost <= PlayerPrefs.GetInt(Saves.Diamond));

            _buttonBuy.gameObject.SetActive(u);
            _buttonTry.gameObject.SetActive(!u);
        } 
    }

    /// <summary>
    /// Change unity scene
    /// </summary>
    public void ChangeScene(string name)
    {
        //YG.YandexGame.SaveProgress();                   

        LoadAndSaveProgress.SaveProgress();
        SceneManager.LoadScene(name);
    }
    
    public void StartGame(string name)
    {
        PlayerPrefs.SetInt("currentSkin", AllSkins.currentSkin); 
        Saves.ResetPoints();

        YG.YandexGame.SaveProgress();
        SceneManager.LoadScene(name);
    }

    public void MuteSound(bool isMute)
    {
        PlayerSetting.UpdateSoundMute(isMute);      
    }

    public void MuteMusic(bool isMute)
    {
        PlayerSetting.UpdateMusicMute(isMute);

        if (isMute)
            MusicBox.Instance.music.Pause();
        else
            MusicBox.Instance.music.Play();
    }

    public static Action Bought;
    public void Buy()
    {
        if (!Saves.Buy(AllSkins.Instanse.AllSkinsInfo[AllSkins.currentSkin].Cost))
            Debug.LogWarning("didn't bought");

        Bought?.Invoke();
        PlayerPrefs.SetInt("skin" + AllSkins.currentSkin.ToString(), 1);

        _cost.text = "";

        _buttonStart.gameObject.SetActive(true);
        _buttonBuy.gameObject.SetActive(false);
        _buttonTry.gameObject.SetActive(false);

        LoadAndSaveProgress.SaveProgress();
    }

    public void Try(int u)
    {
        if (u == 1)
            StartGame("Lvl");
    }

    public void DeleteProgress()
    {
        PlayerPrefs.DeleteAll();
    }
}
