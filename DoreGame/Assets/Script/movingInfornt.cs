using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingInfornt : MonoBehaviour
{

    Vector3 decrimentor = new Vector3(0, 0, -1);
    void Start()
    {

    }
    void FixedUpdate()
    {
        transform.position += decrimentor;
    }
}
