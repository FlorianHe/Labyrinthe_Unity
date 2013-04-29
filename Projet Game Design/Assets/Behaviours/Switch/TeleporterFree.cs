using UnityEngine;
using System.Collections;

public class TeleporterFree : MonoBehaviour
{
	public GameObject destination;
	public GameObject action;
	public float activateTime = 0.2F;
	public GameObject trap;
	
	void OnTriggerEnter(Collider other)
	{
		StartCoroutine(OnTeleport(other));
	}
	
	IEnumerator OnTeleport(Collider other)
	{
		GameObject.Instantiate(action, transform.position, transform.rotation);
		
		yield return new WaitForSeconds(activateTime);
		
		other.gameObject.transform.position = destination.transform.position+new Vector3(0, 5.5F, 0);
		other.gameObject.transform.rotation = destination.transform.rotation;
	}
}
