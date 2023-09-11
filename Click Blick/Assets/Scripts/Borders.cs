using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borders : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        #if UNITY_EDITOR
            collision.gameObject.transform.position = new Vector2(0, 0);
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            return;
        #endif

        Debug.Log("Loose");
    }
}
