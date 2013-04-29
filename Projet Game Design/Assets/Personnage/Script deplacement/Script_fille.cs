using UnityEngine;
using System.Collections;

public class Script_fille : MonoBehaviour {
	
	public AnimationClip	walk;
	enum GirlDo
	{
		WAIT = 0,
		WALK = 1
	};
	
	private GirlDo			_anim;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
/*	if(anim == GirlDo.WALK) {
		_animation[walk.name].speed = Mathf.Clamp(controller.velocity.magnitude, 0.0, walkMaxAnimationSpeed);
		_animation.CrossFade(walk.name);
		}*/
	}
}



