using UnityEngine;
using System.Collections;

public class ScrPiege : MonoBehaviour {
	public GameObject	trap;
	public GameObject	target;
	public float activateTime = 0.2F;
	private int y;
	// Use this for initialization
	void Update ()
	{
		if (trap.transform.position.y <= 19.0)
			trap.rigidbody.isKinematic = true;
	}
		void OnTriggerEnter(Collider other)
		{
			StartCoroutine(activategrav(other));
		}
	
		IEnumerator activategrav(Collider other)
		{
			trap.rigidbody.useGravity = true;
						
		yield return new WaitForSeconds(activateTime);
		}
}