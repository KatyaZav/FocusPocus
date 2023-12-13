using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopUIManager : MonoBehaviour
{
    public GameObject diamond;
    public GameObject point;
    public GameObject record;

    [Header("______")]
    public GameObject effect;
    public bool NeedActive = false;

    private void OnEnable()
    {
        Object.CollectedObj += UpdateUI;
        Saves.ResetPoints();
    }

    private void OnDisable()
    {
        Object.CollectedObj -= UpdateUI;
    }

    void UpdateUI(Value val)
    {

        if (val == Value.diamond)
        {
            Saves.AddDiamonds();
            Activate(diamond, NeedActive);
        }

        if (val == Value.point)
        {
            Saves.AddPoint();
            Activate(point, NeedActive);
        }

        if (val == Value.record)
        {
            Activate(record, NeedActive);
        }
    }

    void Activate(GameObject obj, bool needActive)
    {
        Debug.Log(obj);

        obj.SetActive(true);

        if (effect != null)
            Instantiate(effect, obj.transform);

        StopAllCoroutines();
        StartCoroutine(Disactivate(obj));

        if (needActive)
            obj.SetActive(true);
    }


    IEnumerator Disactivate(GameObject obj)    
    {
        yield return new WaitForSeconds(5f);
        obj.SetActive(false);
    }
}
