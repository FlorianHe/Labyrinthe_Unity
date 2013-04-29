/*using UnityEngine;
using System.Collections;

public class Follow_girl : MonoBehaviour {
	
	private GameObject _light;
	// Use this for initialization
	void Start () {
		_light = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 deplacement = Vector3.zero;
			// Si appui sur la touche de déplacement bas
		if (Input.GetKey(descendre))
			deplacement.y -= Time.deltaTime * speed;
			// Si appui sur la touche de déplacement haut
		if (Input.GetKey(monter))
			deplacement.y += Time.deltaTime * speed;
		// Si appui sur la touche de déplacement gauche
		if (Input.GetKey(gauche))
			deplacement.x -= Time.deltaTime * speed;
		// Si appui sur la touche de déplacement droite
		if (Input.GetKey(droite))
			deplacement.x += Time.deltaTime * speed;
		deplacement.Normalize();
		deplacement *= speed * Time.deltaTime;
		move(deplacement);
		doITweenMovement();
	}
}
*/