#pragma strict
var muzzle : Transform;
var shell : Transform;
var muzzleE : GameObject;
var shellE :GameObject;
var source : AudioSource;
 
var Decal : GameObject;
var Debris :GameObject;
var Sparks : GameObject;
var Dust : GameObject;
var blood : GameObject;
var impactSound : AudioClip[];
var ray: Ray;
 
 
private var anim : Animator; 
private var i : int;

function Start(){
    anim = GetComponent(Animator);
    source = muzzle.GetComponent(AudioSource);
}

function Update(){
    ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));
    //Debug.DrawRay(GetComponent.<Camera>().main.transform.position,GetComponent.<Camera>().main.transform.forward,Color.red);
}

function shooteffects(){
    i=i+1;
    if(muzzleE!=null)

        Instantiate(muzzleE,muzzle.position,muzzle.rotation);
    if(shellE!=null)
        Instantiate(shellE,shell.position,shell.rotation);
    attack();
    source.Play();
}



function attack(){
    var obj : GameObject;
    var hit:RaycastHit;
    var rot : Quaternion;
    var source :AudioSource;

    //Debug.DrawRay(cam.position,fwd,Color.red);
    //if(Physics.Raycast(cam.position,fwd,hit)){
    if(Physics.Raycast(ray,hit)){

        if(hit.transform.tag!="Player"){
            rot=Quaternion.LookRotation(hit.normal);

            if(hit.transform.tag=="Remote"){
        
                Instantiate(blood,hit.point,rot);
                hit.transform.SendMessage("TakeDamage",1);
            }


            else{
                obj=Instantiate(Decal,hit.point,rot);
                obj.transform.parent=hit.transform;
                Instantiate(Debris,hit.point,rot);
                Instantiate(Sparks,hit.point,rot);
                Instantiate(Dust,hit.point,rot);
                source=obj.GetComponent(AudioSource);
                source.pitch=Random.Range(1f,2f);
                source.clip= impactSound[Random.Range(0,impactSound.Length)];
                source.Stop();
                source.Play();
            }
        }

    }
    
}