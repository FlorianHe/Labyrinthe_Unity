using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
	// La touche du clavier utiliseé pour faire monter le vaisseau
	public string monter = "w";
	
	// La touche du clavier utiliseé pour faire descendre le vaisseau
	public string descendre = "s";
	
	// La touche du clavier utiliseé pour faire aller le vaisseau à droite
	public string droite = "d";
	
	// La touche du clavier utiliseé pour faire aller le vaisseau à gauche
	public string gauche = "a";
	
	// La vitesse de déplacement du vaisseau
	public float speed = 30;
	
	// Variables utilisées pour que le vaisseau ne dépasse pas de l'écran
	// décalement du haut
	public float decalUp= 20;
	
	// décalement du bas
	public float decalDown = 20;
	
	// décalement de gauche
	public float decalLeft= 50;
	
	// décalement de droite
	public float decalRight = 50;
	
	// Caméra de la scène
	private Camera c;
	
	private bool moving = false;
	
	private Hashtable ht;
	
	void Awake()
	{
		c = Camera.main;
		ht = new Hashtable();
		ht.Add("speed", 20);
	}
	
	// Appelé a l'initialisation
	void Start ()
	{
		
	}
	
	// Appelé a chaque frame
	void Update ()
	{
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
	
	// Effectue un mouvement de rotation sur la vaisseau si il monte ou descend
	void doITweenMovement()
	{
		// Si on fait descendre le vaisseau
		if (Input.GetKeyDown(descendre))
		{
			// On stop la rotation faite lors de la montée
			iTween.StopByName("monter");
			iTween.StopByName("stop");
			// Nettoyage des clefs du tableau utilisé par iTween
			resetITweenArgs();
			// On ajoute un angle de -10 sur l'axe z du vaisseau
			ht.Add("x", -20);
			// On applique le nom de la rotation
			ht.Add("name", "descendre");
			// On effectue la rotation
			iTween.RotateTo(gameObject, ht);
			// On indique que l'on est en train de bouger
			moving = true;
		}
		else if (Input.GetKeyDown(monter))
		{
			iTween.StopByName("decendre");
			iTween.StopByName("stop");
			resetITweenArgs();
			ht.Add("x", 20);
			ht.Add("name", "monter");
			iTween.RotateTo(gameObject, ht);
			moving = true;
		}
		else if ((!Input.GetKey(monter)) && (!Input.GetKey(descendre)) && moving == true)
		{
			moving = false;
			iTween.StopByName("monter");
			iTween.StopByName("descendre");
			resetITweenArgs();
			ht.Add("x", 0);
			ht.Add("name", "stop");
			iTween.RotateTo(gameObject, ht);
		}
	}
	
	void resetITweenArgs()
	{
		if (ht.ContainsKey("x"))
			ht.Remove("x");
		if (ht.ContainsKey("name"))
			ht.Remove("name");
	}
	
	void move(Vector3 deplacement)
	{
		Vector3 nextScreenPos = c.WorldToScreenPoint(gameObject.transform.position + deplacement);
		// Si le vaisseau n'est pas à la position maximum par rapport à l'écran
		if ((nextScreenPos.x > decalLeft) && (nextScreenPos.x < (c.pixelWidth - decalRight)) &&
		    (nextScreenPos.y < (c.pixelHeight - decalUp)) && (nextScreenPos.y > decalDown))
		{
			gameObject.transform.Translate(deplacement, Space.World);
		}
	}
	
	void OnDestroy() {
		iTween.StopByName("monter");
		iTween.StopByName("descendre");
		iTween.StopByName("stop");
	}
	
}
