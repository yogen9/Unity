using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform camera;
    public Vector3 offset;	
	void Update () {
        camera.position=transform.position + offset ;
    }
}
