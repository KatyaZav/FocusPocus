using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutor : MonoBehaviour
{
    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
