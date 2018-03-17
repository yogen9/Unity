using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerHealth : NetworkBehaviour
{
    public int starthealth = 100;
    public int currenthealth;
    public Text Health;
    bool isDead;

    void Start()
    {
        currenthealth = starthealth;
    }

    public void TackDamage(int amount)
    {
        currenthealth -= amount;
        Health.text = currenthealth.ToString();
        if (currenthealth <= 0 && !isDead)
        {
            makeDead();
        }
    }

    void makeDead()
    {
        isDead = true;
        Debug.Log("Dead");
    }
}
