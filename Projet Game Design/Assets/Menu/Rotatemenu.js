var _cible : GameObject;
private var _interrupteur: boolean;

function Start () {
    _interrupteur= false;
}

function Update () {
    if(!_interrupteur) return;
   _cible.transform.Rotate(Vector3.left*(-100.0*Time.deltaTime));
}

function OnMouseEnter() {
    if(_interrupteur) _interrupteur = false;
    else _interrupteur = true;
}