using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSounds : MonoBehaviour
{
    [SerializeField] AudioClip buttonSound;
    private void Awake()
    {
        var buttons = FindObjectsOfType<Button>();

        foreach (var button in buttons)
        {
            button.onClick.AddListener(onButtonClicked);
        }
    }

    void onButtonClicked()
    {
        MusicBox.Instance.PlaySound(buttonSound, 0.5f);
    }
}
