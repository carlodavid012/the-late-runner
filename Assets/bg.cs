using UnityEngine;
using System.Collections;

public class bg : MonoBehaviour {

	public static bg instance;
	public AudioSource audio;

	// Use this for initialization

	void Awake(){
		if(instance == null){
			instance = this;
		}if(true){
			audio.mute = true;
		}
	}

}
