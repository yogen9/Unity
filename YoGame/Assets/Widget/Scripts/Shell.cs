using UnityEngine;
using System.Collections;

public class Shell : MonoBehaviour {
	public float thrust;
	public float t;
	public ForceMode mode;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward * thrust,mode);
		GetComponent<Rigidbody> ().AddRelativeTorque (Random.onUnitSphere*t,mode);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
