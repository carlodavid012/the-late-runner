using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public static Obstacle instance;
	public static float speed = -5f;

	private Rigidbody2D myBody;

	public static bool hasFrozen = false;

	void Awake ()
	{
		myBody = GetComponent<Rigidbody2D> ();
		CreateInstance ();



	}

	void Update ()
	{
		myBody.velocity = new Vector2 (speed, 0);

		if (hasFrozen) {
			foreach (Transform child in transform) {
				if (child.name == "ice") {
					child.gameObject.SetActive (true);
				}
          
                 
			}

		}

		if (!hasFrozen) {
			foreach (Transform child in transform) {
				if (child.name == "ice") {
					child.gameObject.SetActive (false);
				}
          
                 
			}

		}
	}



	void CreateInstance(){
		if(instance==null){
			instance = this;
		}
	}




}
