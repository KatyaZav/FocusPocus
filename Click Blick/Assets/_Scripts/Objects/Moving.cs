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
    
    public void StopMoveChaous(Vector2 B)
    {
        StopAllCoroutines();
        StartCoroutine(Move(B, speed*3, true));
    }

    IEnumerator moveChous()
    {
        while (true)
        {
            float x = Random.Range(left.transform.position.x, right.transform.position.x);
            float y = Random.Range(left.transform.position.y, right.transform.position.y);
            Vector2 B = new Vector2(x, y);

            yield return StartCoroutine(Move(B, speed));            
        }
    }

    IEnumerator Move(Vector2 B, float speed, bool DestroyAfer = false)
    {
        while (distance(transform, B) > 1)
        {
            transform.position = Vector2
                .Lerp(transform.position, B, speed / (distance(transform, B) * 300));
            yield return new WaitForFixedUpdate();
        }

        if (DestroyAfer)
            Destroy(gameObject);
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
