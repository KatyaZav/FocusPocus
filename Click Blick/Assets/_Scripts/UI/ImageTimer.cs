using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    [SerializeField] Image _img;

    private void OnEnable()
    {
        StartCoroutine(TimerLogic());
    }

    private IEnumerator TimerLogic()
    {
        var pice = _img.fillAmount / 100;
        while (_img.fillAmount > 0)
        {
            yield return new WaitForSeconds(0.05f);
            _img.fillAmount -= pice;
        }
    }
}