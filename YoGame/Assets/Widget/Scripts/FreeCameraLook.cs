using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class FreeCameraLook : NetworkBehaviour {
	public Transform cam,pivot;

    public float moveSpeed =5f;
    public float turnSpeed =1.5f;
    public float turnSmoothing =.1f;
    public Transform target;

    public float lookAngle;
    public float tiltAngle;

    public float smoothX=0;
    public float smoothY = 0;
    public float smoothXvelocity = 0;
    public float smoothYvelocity =0;
	// Use this for initialization
	void Start () {
        if (!isLocalPlayer)
        {
            Destroy(this);
            return;
        }

        target = GameObject.FindWithTag ("Player").transform;
		cam = GetComponentInChildren<Camera> ().transform;
		pivot = cam.parent;
		//Screen.lockCursor = true;
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked ;
	}
	
	// Update is called once per frame
	void Update () {
		HandleRotationMovement ();
		Follow (999);
		cam.localPosition = Vector3.Scale (cam.localPosition,Vector3.forward);
	}

	void Follow (float deltaTime){
		transform.position = Vector3.Lerp (transform.position, target.position, deltaTime * moveSpeed);
	}

	void HandleRotationMovement(){
		 float x = CrossPlatformInputManager.GetAxis("Mouse X");
		 float y = CrossPlatformInputManager.GetAxis("Mouse Y");

		if (turnSmoothing > 0) {
			smoothX = Mathf.SmoothDamp (smoothX, x, ref smoothXvelocity, turnSmoothing);
			smoothY = Mathf.SmoothDamp (smoothY, y, ref smoothYvelocity, turnSmoothing);
		} else
			smoothX = x;
		    smoothY = y;

		lookAngle += smoothX * turnSpeed;
		transform.rotation = Quaternion.Euler (0,lookAngle,0);


		tiltAngle -= smoothY * turnSpeed;

		tiltAngle = Mathf.Clamp (tiltAngle, -25f,25f);
		pivot.localRotation = Quaternion.Euler (tiltAngle,0,0);
	}
}
