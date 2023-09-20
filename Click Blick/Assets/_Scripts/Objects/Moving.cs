using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    private GameObject left;
    private GameObject right;
    public float speed;

    private void Awake()
    {
        left = GameObject.FindGameObjectWithTag("Left");
        right = GameObject.FindGameObjectWithTag("Right");
        
        StartCoroutine(moveChous());
    }
    

    public IEnumerator moveChous()
    {
        while (true)
        {
            float x = Random.Range(left.transform.position.x, right.transform.position.x);
            float y = Random.Range(left.transform.position.y, right.transform.position.y);
            Vector2 B = new Vector2(x, y);

            yield return StartCoroutine(Move(B));            
        }
    }

    public IEnumerator Move(Vector2 B)
    {
        while (distance(transform, B) > 1)
        {
            transform.position = Vector2
                .Lerp(transform.position, B, speed / (distance(transform, B) * 300));
            yield return new WaitForFixedUpdate();
        }
    }

    private float distance(Transform A, Vector2 B)
    {
        float a = Mathf.Abs(B.x - A.position.x);
        float b = Mathf.Abs(B.y - A.position.y);

        return Mathf.Sqrt(a * a + b * b);
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
