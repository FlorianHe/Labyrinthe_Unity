using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour
{
	// La touche du clavier utilise� pour faire monter le vaisseau
	public string monter = "w";
	
	// La touche du clavier utilise� pour faire descendre le vaisseau
	public string descendre = "s";
	
	// La touche du clavier utilise� pour faire aller le vaisseau � droite
	public string droite = "d";
	
	// La touche du clavier utilise� pour faire aller le vaisseau � gauche
	public string gauche = "a";
	
	// La vitesse de d�placement du vaisseau
	public float speed = 30;
	
	// Variables utilis�es pour que le vaisseau ne d�passe pas de l'�cran
	// d�calement du haut
	public float decalUp= 20;
	
	// d�calement du bas
	public float decalDown = 20;
	
	// d�calement de gauche
	public float decalLeft= 50;
	
	// d�calement de droite
	public float decalRight = 50;
	
	// Cam�ra de la sc�ne
	private Camera c;
	
	private bool moving = false;
	
	private Hashtable ht;
	
	void Awake()
	{
		c = Camera.main;
		ht = new Hashtable();
		ht.Add("speed", 20);
	}
	
	// Appel� a l'initialisation
	void Start ()
	{
		
	}
	
	// Appel� a chaque frame
	void Update ()
	{
		Vector3 deplacement = Vector3.zero;
		// Si appui sur la touche de d�placement bas
		if (Input.GetKey(descendre))
			deplacement.y -= Time.deltaTime * speed;
		// Si appui sur la touche de d�placement haut
		if (Input.GetKey(monter))
			deplacement.y += Time.deltaTime * speed;
		// Si appui sur la touche de d�placement gauche
		if (Input.GetKey(gauche))
			deplacement.x -= Time.deltaTime * speed;
		// Si appui sur la touche de d�placement droite
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
			// On stop la rotation faite lors de la mont�e
			iTween.StopByName("monter");
			iTween.StopByName("stop");
			// Nettoyage des clefs du tableau utilis� par iTween
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
		// Si le vaisseau n'est pas � la position maximum par rapport � l'�cran
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
