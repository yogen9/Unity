using UnityEngine;
using System.Collections;

public class movePlayer : MonoBehaviour
{
    Vector3 targetpos = new Vector3();
    float t = 0;
    public float speed;
    int input;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKey("1"))
            StartCoroutine(moveTo(1));
        if (Input.GetKey("2"))
            StartCoroutine(moveTo(2));
        if (Input.GetKey("3"))
            StartCoroutine(moveTo(3));
    }
    IEnumerator moveTo(int input)
    {
        do
        {
            targetpos.z = transform.position.z;
            targetpos.y = transform.position.y;

            if (input == 1)
            {
                targetpos.x = -6;
                transform.position = Vector3.Lerp(transform.position, targetpos, t);
            }
            if (input == 2)
            {
                targetpos.x = 1;
                transform.position = Vector3.Lerp(transform.position, targetpos, t);
            }
            if (input == 3)
            {
                targetpos.x = 6;
                transform.position = Vector3.Lerp(transform.position, targetpos, t);
            }
            t += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        } while (t <= 1);
        

    }
}
