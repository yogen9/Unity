using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class NewShotEffect : NetworkBehaviour
{
    public Text DebugText;
    public Slider slider;
    public int DamageValue = 5;
    public Ray ray;
    int i;
    public Quaternion rot;
    public Animator anim;
    public AudioSource source;
    public Transform muzzle;
    public Transform shell;
    public GameObject muzzleE;
    public GameObject shellE;
    public GameObject Decal;
    public GameObject Debris;
    public GameObject Sparks;
    public GameObject Dust;
    public GameObject blood;
    public GameObject Muzzle;
    public AudioClip[] impactSound;

    void Start()
    {
            anim = GetComponent<Animator>();
            source = muzzle.GetComponent<AudioSource>();
            Muzzle = GameObject.FindGameObjectWithTag("Muzzle"); 
    }

    void Update()
    {            
            ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            ray.origin = Muzzle.transform.position;
            Debug.DrawRay(ray.origin, ray.direction, Color.green);    
    }

    void shooteffects()
    {
        i = i + 1;
        if (muzzleE != null)
            Instantiate(muzzleE, muzzle.position, muzzle.rotation);
        if (shellE != null)
            Instantiate(shellE, shell.position, shell.rotation);
        RPCattack();
        source.Play();
    }

    public void RPCattack()
    {
        GameObject obj;
        AudioSource source;
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawLine(ray.origin, ray.direction, Color.green);
            DebugText.text = hit.transform.tag + "Hit";
            if (hit.transform.tag == "Enemy")
            {
                Debug.Log("NewShortEffect : Attack : Hit_tag :" + hit.transform.tag);
                hit.collider.GetComponent<PlayerHealth>().TackDamage(DamageValue);
                slider = hit.collider.GetComponentInChildren<Slider>();
                slider.value -= DamageValue;            
                Debug.Log("Enemy Slide : " + slider.value);
                rot = Quaternion.LookRotation(hit.normal);
                Instantiate(blood, hit.point, rot);
            }
            else
            {
                Debug.Log("No Enemy");
                obj = Instantiate(Decal, hit.point, rot);
                obj.transform.parent = hit.transform;
                Instantiate(Debris, hit.point, rot);
                Instantiate(Sparks, hit.point, rot);
                Instantiate(Dust, hit.point, rot);
                source = obj.GetComponent<AudioSource>();
                source.pitch = Random.Range(1f, 2f);
                source.clip = impactSound[Random.Range(0, impactSound.Length)];
                source.Stop();
                source.Play();
            }
        }
    }
}
