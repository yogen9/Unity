using UnityEngine;
using System.Collections;

public class RemotePlayer : MonoBehaviour {
	Animator anim;
	 Quaternion aimLookPos;
	bool aim;
	bool fire;
//	EnemyMove enemy;
	float forward=0;
	float turn=0 ;
	public float lerpRate = 15;
	public Transform spine;
	GameObject wassup;

	Vector3 pos; 
	Quaternion rot;

	// Use this for initialization
	void Awake () {

		//wassup = GameObject.FindWithTag ("Aim");
		anim = GetComponent <Animator>();
		foreach (var childAnimator in GetComponentsInChildren<Animator>())
		{
			if (childAnimator != anim)
			{
				anim.avatar = childAnimator.avatar;
				Destroy(childAnimator);
				break; 
			}
		}
		//enemy = GetComponent<EnemyMove> ();

	}
	
	// Update is called once per frame


	public void Set(Vector3 pos, Vector3 rot,Vector3 look,float f,float t, bool aim,bool fire){

		this.pos = pos;
		this.rot.eulerAngles = rot;
		//this.aimLookPos = look;
		this.aimLookPos.eulerAngles = look;
		this.forward = f;
		this.turn = t;
		this.aim = aim;
		this.fire = fire;



	}


	void Update(){
		transform.position = Vector3.Lerp (transform.position, pos, Time.deltaTime * lerpRate);
		transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.deltaTime * lerpRate);
		anim.SetFloat ("Forward",forward);
		anim.SetFloat ("Turn",turn);
		anim.SetBool ("Aim", aim);
		anim.SetBool ("Fire",fire);

		if (aim) {
//			Vector3 eulerAngleOffset = Vector3.zero;
//			float aimingX = wassup.transform.position.x;
//			float aimingY = wassup.transform.position.y;
//			float aimingZ = wassup.transform.position.z;
//			eulerAngleOffset = new Vector3 (aimingX, aimingY, aimingZ);
//			spine.LookAt (aimLookPos);
//			spine.Rotate (eulerAngleOffset, Space.Self);
			spine.localRotation=Quaternion.Slerp(spine.rotation, aimLookPos, Time.deltaTime * lerpRate);

			
			
		} else
			fire = false;

	}

//
//	void LateUpdate(){
//		if (aim) {
//			Vector3 eulerAngleOffset = Vector3.zero;
//			float aimingX = wassup.transform.position.x;
//			float aimingY = wassup.transform.position.y;
//			float aimingZ = wassup.transform.position.z;
//			eulerAngleOffset = new Vector3 (aimingX, aimingY, aimingZ);
//			spine.LookAt (aimLookPos);
//			spine.Rotate (eulerAngleOffset, Space.Self);
//
//
//		} else
//			fire = false;
//	}

	void OnAnimatorIK(){
//		if (aim) {
//
//			anim.SetLookAtWeight (1, 1, 1, 1);
//			anim.SetLookAtPosition (aimLookPos);
//		} else
//			anim.SetLookAtWeight (0, 1, 1, 1);
	}
	
}
