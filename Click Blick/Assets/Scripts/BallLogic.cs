using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLogic : MonoBehaviour
{

    [SerializeField] Rigidbody2D rb;
    Camera _cam;

    private void Start()
    {
        _cam = Camera.main;

        if (rb == null)       
            rb = GetComponent<Rigidbody2D>();        
    }
    
    private void OnMouseDown()
    {
        OnTouched();
    }

    /// <summary>
    /// Action happend on mouse click on ball
    /// </summary>
    void OnTouched()
    {
        Debug.Log("Tap");

        Debug.LogWarning("Add effects and anim");

        Upped();
    }

    /// <summary>
    /// Ball fly up
    /// </summary>
    void Upped()
    {
        var mousePosWorld = _cam.ScreenToWorldPoint(Input.mousePosition);
        rb.velocity = new Vector2(0, 0);
        rb.AddForce(new Vector2(
            (transform.position.x - mousePosWorld.x) * 2, 1-Mathf.Abs(transform.position.x - mousePosWorld.x)) * 300);
    }
}
