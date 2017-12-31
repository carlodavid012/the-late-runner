 using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour {
	
	public static float jumpSpeed = 5f;
	private float forwardSpeed = 0f;
	
	private Rigidbody2D body2d;

	
	public AudioClip sounds;
	private AudioSource source;
	void Awake(){
		body2d = GetComponent<Rigidbody2D> ();

		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//use for testing for pc
		if (Input.GetKeyUp (KeyCode.S)) {

			body2d.velocity = new Vector2(transform.position.x < 0 ? forwardSpeed : 0, jumpSpeed);
		}
		//use for testing for pc
		if (Input.GetKeyUp (KeyCode.L)) {
			body2d.velocity = new Vector2(transform.position.x < 0 ? forwardSpeed : 0, -jumpSpeed);

		}

		var touch = Input.touches[0];

			if (Input.touchCount == 1 ) {
				if(touch.position.x < Screen.width/2){
					body2d.velocity = new Vector2(transform.position.x < 0 ? forwardSpeed : 0, jumpSpeed);

				}
			else if(touch.position.x > Screen.width/2){
					body2d.velocity = new Vector2(transform.position.x < 0 ? forwardSpeed : 0, -jumpSpeed);

				}
			}


		}

	
	
}
