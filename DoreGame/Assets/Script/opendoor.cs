using UnityEngine;

public class opendoor : MonoBehaviour
{
    chooseWall door;
    public Score Update;
    void Start()
    {
            
    }
    void Up()
    {
        Update.score += 1;
        Update.ScoreUpdateText.text = Update.score.ToString();
    }
    void OnTriggerEnter(Collider doorCollide)
    {
        this.door= doorCollide.gameObject.GetComponentInParent<chooseWall>();
        int number = this.door.chooseDoor;
        if (doorCollide.gameObject.tag=="d1" && number==1)
        {
            doorCollide.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            Up();
        }
        else if (doorCollide.gameObject.tag == "d2" && number == 2)
        {
            doorCollide.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            Up();

        }
        else if (doorCollide.gameObject.tag == "d3" && number == 3)
        {
            doorCollide.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
            Up();

        }
        else
        {
            doorCollide.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            Update.score -= 1;
            Update.ScoreUpdateText.text = Update.score.ToString();
        }

    }
}
