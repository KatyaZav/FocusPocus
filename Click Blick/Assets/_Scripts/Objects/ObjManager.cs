using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjManager : MonoBehaviour
{
    [SerializeField] Transform left;
    [SerializeField] Transform right;

    [SerializeField] ProbabilityObj[] objs;
    bool pause = false;

    private void OnDisable()
    {
        RewardVideoLogic.ChangeGamePauseSettingsToResume -= ChangePause;
    }

    private void OnEnable()
    {
        RewardVideoLogic.ChangeGamePauseSettingsToResume += ChangePause;

        foreach (var obj in objs)
        {
            StartCoroutine(Generator(obj));
        }
    }

    void ChangePause(bool isPause)
    {
        pause = isPause;
    }


    IEnumerator Generator(ProbabilityObj obj)
    {
        while (true)
        {
            //Debug.Log(pause + " " + obj.GetGeneratedObject().name);

            if (!pause)
            {
                yield return new WaitForSeconds(obj.GetTimeBetween());

                Instantiate(obj.GetGeneratedObject(), RandomPosition(), Quaternion.identity);
                obj.UpdateTime();
            }
            else 
                yield return new WaitForFixedUpdate();
        }
    }

    Vector3 RandomPosition()
    {
        var x = Random.Range(left.position.x, right.position.x);
        var y = Random.Range(right.position.y, left.position.y);

        return new Vector3(x, y, 0);
    }
}

[System.Serializable]
public class ProbabilityObj
{
    [SerializeField] GameObject obj;
    [SerializeField] int maxTime;
    [SerializeField] int minTime;
    [SerializeField] int interval=2;


    public GameObject GetGeneratedObject()
    {
        return obj;
    }

    public void UpdateTime()
    {
        if (maxTime <= minTime)
            return;

        maxTime--;
    }

    public int GetTimeBetween()
    {
        return Random.Range(maxTime, maxTime + interval);
    }
}
