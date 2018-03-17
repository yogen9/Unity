using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

public class UserInput : NetworkBehaviour
{
    public CharMove character;
    private Transform cam;
    public Vector3 camForward;
    public Vector3 move;

    public Vector3 camNormalState = new Vector3(0, 0, -2.0f);
    public Vector3 camAimingState = new Vector3(0.3f, 0.2f, 0.35f);

    [HideInInspector]
    public bool fire;
    [HideInInspector]
    public Vector3 aimLookPos;
    public Vector3 aimOffset = Vector3.zero;
    public bool OverrideAIM = false;
    public float horizontal;
    public float vertical;

    [HideInInspector]
    public bool aim = false;
    public float aimWeight;

    public bool lookInCameraDirection;
    Vector3 lookPos;
    Animator anim;

    public Transform spine;
    public float aimingZ;
    public float aimingY;
    public float aimingX;
    public float point = 30;

    void Start()
    {
        if(!isLocalPlayer)
        {
            Destroy(this);
            return;
        }
        if (Camera.main != null)
        {
            cam = Camera.main.transform;
        }
        character = GetComponent<CharMove>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!aim)
            anim.SetBool("Fire", false);
    }

    void LateUpdate()
    {
        if (OverrideAIM)
            aim = true;
        else
            aim = Input.GetMouseButton(1);

        aimWeight = Mathf.MoveTowards(aimWeight, (aim) ? 1.0f : 0.0f, Time.deltaTime * 5);
        Vector3 pos = Vector3.Lerp(camNormalState, camAimingState, aimWeight);
        cam.transform.localPosition = pos;

        if (aim)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            Vector3 lookPosition = ray.GetPoint(point);
            aimLookPos = lookPosition;
            spine.LookAt(lookPosition);
            spine.Rotate(aimOffset, Space.Self);
            fire = Input.GetMouseButton(0);
            anim.SetBool("Fire", fire);
           

        }
    }

    void FixedUpdate()
    {
        horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        vertical = CrossPlatformInputManager.GetAxis("Vertical");

        if (!aim)
        {
            if (cam != null)
            {
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                move = vertical * camForward + horizontal * cam.right;
            }
            else
            {
                move = vertical * Vector3.forward + horizontal * Vector3.right;
            }
        }
        else
        {
            move = Vector3.zero;
            Vector3 dir = lookPos - transform.position;
            dir.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 20 * Time.deltaTime);
            anim.SetFloat("Forward", vertical);
            anim.SetFloat("Turn", horizontal);
        }

        if (move.magnitude > 1)
            move.Normalize();

        bool walkToggle = Input.GetKey(KeyCode.LeftShift);
        float walkMultiplier;

        if (walkToggle)
        {
            if (aim)
                walkMultiplier = 0.5f;
            else
                walkMultiplier = 1;
        }
        else
            walkMultiplier = 0.5f;

        lookPos = lookInCameraDirection && cam != null ? transform.position + cam.forward * 100 : transform.position + transform.forward * 100;
        move *= walkMultiplier;
        character.Move(move, aim, lookPos);
    }
}