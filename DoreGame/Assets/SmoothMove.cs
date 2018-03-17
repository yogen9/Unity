using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothMove : MonoBehaviour
{
    Vector3 target = new Vector3(10f, 0f, 0f);
    public float speed;

    void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        float timer = 0f;
        Vector3 startPosition = transform.position;
        do
        {
            transform.position = Vector3.Lerp(startPosition, target, timer);
            timer += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        } while (timer <= 1f);
        transform.position = target;
    }
}
