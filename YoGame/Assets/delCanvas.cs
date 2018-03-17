using UnityEngine;
using UnityEngine.Networking;

public class delCanvas : NetworkBehaviour {

	// Use this for initialization
	void Start () {
		if(!isLocalPlayer)
        {
            Destroy(GetComponentInChildren<Canvas>());
        }
	}
	

}
