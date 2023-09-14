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
        SceneManager.LoadScene(name);
    }
}
