using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyer : MonoBehaviour
{
    public Initiate obj;
    movingInfornt BigWall;
    void Start()
    {

    }
    void OnTriggerEnter(Collider colliderObject)
    {
        Debug.Log("Hello");
        if (colliderObject.CompareTag("d2"))
        {
            BigWall =colliderObject.GetComponentInParent<movingInfornt>();
            Debug.Log(BigWall.name);
            Destroy(BigWall.gameObject);
            obj.initiate();
        }
    }
}
