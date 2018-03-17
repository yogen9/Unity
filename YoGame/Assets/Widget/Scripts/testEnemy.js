#pragma strict

function Start () {

}

function Update () {
  transform.position = new Vector3(Mathf.PingPong(Time.time*2, 6), transform.position.y, transform.position.z);
//  Debug.Log(Time.time);
}