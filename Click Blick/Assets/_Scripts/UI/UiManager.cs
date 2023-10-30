using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    void Awake()
    {
        AllSkins.ChangedSkin += UpdateSkin;
    }

    private void OnDestroy()
    {
        AllSkins.ChangedSkin -= UpdateSkin;
    }

    [SerializeField] Image _playerImage;
    [SerializeField] TMP_Text _cost;

    [SerializeField] Button _buttonStart;
    [SerializeField] Button _buttonBuy;

    /// <summary>
    /// Update skin ui
    /// </summary>
    private void UpdateSkin()
    {
        var _skin = AllSkins.Instanse.AllSkinsInfo[AllSkins.currentSkin];

        _playerImage.sprite = _skin.SpriteImage;

        if (_skin.Cost == 0 || _skin.isBought)
        {
            _cost.text = "";

            _buttonBuy.gameObject.SetActive(false);
            _buttonStart.gameObject.SetActive(true);                
        }
        else
        {
            _cost.text = _skin.Cost.ToString();

            _buttonBuy.gameObject.SetActive(true);
            _buttonStart.gameObject.SetActive(false);
        } 



    }

    /// <summary>
    /// Change unity scene
    /// </summary>
    public void ChangeScene(string name)
    {
        YG.YandexGame.SaveProgress();
        SceneManager.LoadScene(name);
    }
    
    public void StartGame(string name)
    {
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
    }
}
