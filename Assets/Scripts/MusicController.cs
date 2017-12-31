using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class MusicController : MonoBehaviour {

	public static MusicController instance;



	  void Awake ()
	{
		
			MakeSingleton ();
		

	}  


	void MakeSingleton ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad (gameObject);
		}

	}

	void music(){
		
	}

}
