#pragma strict
var health : int=50;
function Start () {

}

function Update () {
if(health<=0)
Destroy(gameObject);
}
function TakeDamage(damage : int){
health-=damage;
} 