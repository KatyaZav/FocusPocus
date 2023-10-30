using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiEn : MonoBehaviour
{
    public Animator an;

    private void OnEnable()
    {
        an.SetTrigger("en");    
    }
}
