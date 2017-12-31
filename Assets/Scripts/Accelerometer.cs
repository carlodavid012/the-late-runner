using UnityEngine;
using System.Collections;

public class Accelerometer : MonoBehaviour {

	public static Accelerometer instance;
	public  Vector3 cposition;
	public Vector3 up,down;
	
	
	// Use this for initialization
	void Start () {

		

	}

	// Update is called once per frame
	void Update () {

	 	cposition = transform.position;

	 	cposition.y = Mathf.Clamp(cposition.y,-4.07f,0.011f);
	 	transform.position = cposition;

		
		//float temp = Input.acceleration.x;
		//Debug.Log(temp);
		//transform.Translate(0,temp,0);

	}

	void CreateInstance(){
		if(instance == null){
			instance = this;
		}
	}
	//-4.07f , 0.011f
	//-2.04f

}
