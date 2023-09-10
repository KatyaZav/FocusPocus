using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        if (rb == null)       
            rb = GetComponent<Rigidbody2D>();        
    }
    
    private void OnMouseDown()
    {
        //удар со стороны

        Debug.Log("Tap"); 
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(Vector2.up * 300);
    }
}
