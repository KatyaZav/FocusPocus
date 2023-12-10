using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    [SerializeField] Image _img;
    public static bool pause = false;

    private void OnEnable()
    {
        pause = true;
        StartCoroutine(TimerLogic());
    }

    private IEnumerator TimerLogic()
    {
        pause = true;
        var pice = _img.fillAmount / 50;
        while (_img.fillAmount > 0)
        {
            yield return new WaitForSeconds(0.05f);
            _img.fillAmount -= pice;
        }

        yield return new WaitForSeconds(0.05f);
        RewardVideoLogic.Instance.EndGame();
        gameObject.SetActive(false);
        pause = false;
    }

    /// <summary>
    /// stop timer if player watch video
    /// </summary>
    public void StopTimer()
    {
        pause = false;
        StopCoroutine(TimerLogic());
    }
}
