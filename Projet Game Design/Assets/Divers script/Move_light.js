#pragma strict

var VitMouv = 4.0;
var VitRot = 3.0;

function Start () {

}

function Update () {
	var controller : CharacterController = GetComponent(CharacterController);
	//transform.Rotate(0, Input.GetAxis("Horizontal") * VitRot, 0);
	
	var enAvant = transform.TransformDirection(Vector3.forward);
	var VitDep = VitMouv * Input.GetAxis("Vertical");
	var cote = transform.TransformDirection(Vector3.right);
	var VitDep2 = VitMouv * Input.GetAxis("Horizontal");
	controller.SimpleMove(enAvant * VitDep);
	controller.SimpleMove(cote * VitDep2);
	//this.transform.position = Vector3(x, 5, z);
}

@script RequireComponent(CharacterController);