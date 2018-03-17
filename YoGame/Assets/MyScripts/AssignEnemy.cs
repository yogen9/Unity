using UnityEngine.Networking;
using UnityEngine;

public class AssignEnemy : NetworkBehaviour
{
    void Start()
    {
        if (!isLocalPlayer)
        {
            gameObject.tag = "Enemy";
        }
    }
}
