using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiate : MonoBehaviour {
    public GameObject Newobj;
    public Transform spawnPoint;
    void Start ()
    {
        initiate();
	}

   public void initiate()
    {
        Instantiate(Newobj,spawnPoint.position, Quaternion.identity);
    }
}
