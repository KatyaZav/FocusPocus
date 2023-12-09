using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System;

public class UiManager : MonoBehaviour
{
    void Start()
    {
        AllSkins.ChangedSkin += UpdateSkin;
        YG.YandexGame.RewardVideoEvent += Try;

        AllSkins.currentSkin = PlayerPrefs.GetInt("currentSkin", 0);
        UpdateSkin();        
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

        _skin.isBought = PlayerPrefs.GetInt("skin" + AllSkins.currentSkin.ToString(), 0) == 1;
           
        _playerImage.sprite = _skin.SpriteImage;

        if (_skin.Cost == 0 || _skin.isBought)
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
