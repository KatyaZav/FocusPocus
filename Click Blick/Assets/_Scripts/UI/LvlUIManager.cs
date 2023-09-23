using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvlUIManager : MonoBehaviour
{
    public GameObject diamond;
    public GameObject point;
    public GameObject record;

    [Header("______")]
    public GameObject effect;

    private void Awake()
    {
        Object.CollectedObj += UpdateUI;
    }

    private void OnDestroy()
    {
        Object.CollectedObj -= UpdateUI;
    }

    void UpdateUI(Value val)
    {
        if (val == Value.diamond)
        {
            Saves.AddDiamonds();
            Activate(diamond);
        }

        if (val == Value.point)
        {
            Saves.AddPoint();
            Activate(point);
        }

        if (val == Value.record)
        {
            Activate(record);
        }
    }

    void Activate(GameObject obj)
    {
        obj.SetActive(true);
        Instantiate(effect, obj.transform);

        StartCoroutine(Disactivate(obj));
    }


    IEnumerator Disactivate(GameObject obj)    
    {
        yield return new WaitForSeconds(2f);
        obj.SetActive(false);
    }
}
