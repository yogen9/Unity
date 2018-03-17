using UnityEngine;
using System.Collections;

public class CrossHair : MonoBehaviour {
	bool aim;
	UserInput U;
	public Rect crossRect;
	public Texture crossText;
	// Use this for initialization
	void Start () {
		float crossHairSize = Screen.width * 0.007f;
		//crossText=Resources.Load("Xpo/red") as Texture;
		crossRect = new Rect (Screen.width/2-crossHairSize/2,Screen.height/2-crossHairSize/2,crossHairSize,crossHairSize);
		U = GameObject.FindWithTag ("Player").GetComponent<UserInput>();
		aim = U.aim;
	
	}

	void Update(){
		aim = U.aim;
	}
	
	// Update is called once per frame
	void OnGUI(){
		if(aim)
		GUI.DrawTexture (crossRect,crossText);

	}
}
