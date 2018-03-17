using UnityEngine;
using UnityEngine.Networking;


public class testing : NetworkBehaviour {

    NetworkPlayer[] playerInGame;
    private void Update()
    {
        playerInGame= Network.connections;
        //playerInGame.
    }
}
