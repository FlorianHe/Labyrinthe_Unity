using UnityEngine;
using System.Collections;

[AddComponentMenu("Bun Bun/Timing/Self Destruct")]
public class SelfDestruct : MonoBehaviour
{
	public float duration;
	
	IEnumerator Start()
	{
		yield return new WaitForSeconds(duration);
		
		Destroy(gameObject);
	}
}
