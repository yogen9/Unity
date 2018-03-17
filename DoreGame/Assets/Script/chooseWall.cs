using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseWall : MonoBehaviour {
    public int chooseDoor;
	void Start () {
        chooseDoor = Random.Range(1,4);
	}
}
