using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tochable : MonoBehaviour
{
    [SerializeField] GameObject obj;
    bool isTouch;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isTouch = true;
            obj.SetActive(true);
        }

        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;
            obj.SetActive(false);
        }

        if (isTouch)
        {
            var ax = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ax.z = 0;

            obj.transform.position = ax;
        }
    }
}
