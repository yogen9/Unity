using UnityEngine.Networking;
using UnityEngine;

public class LocalIdentify : NetworkBehaviour {

	void Start () {
		if(!isLocalPlayer)
        {
            FindObjectOfType<Canvas>().enabled = false;
        }
	}
}
