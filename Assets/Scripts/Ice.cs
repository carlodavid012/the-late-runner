using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {

	
	public AudioSource audioIce;




	void OnTriggerEnter2D (Collider2D other)
	{
		

		if(other.tag == "Player"){
			audioIce.Play();
		}	
		

		
	}
}
