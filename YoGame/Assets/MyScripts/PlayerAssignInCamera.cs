using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerAssignInCamera : NetworkBehaviour {
    public FreeCameraLook freeCameraLook;
	// Use this for initialization
	void Start () {
		if(!isLocalPlayer)
        {
            Destroy(this);
            return;            
        }
        freeCameraLook = FindObjectOfType<FreeCameraLook>();
        freeCameraLook.target = transform;
	}
	
	
}
