using UnityEngine;
using System.Collections;

public class backgroundmusic : MonoBehaviour {

	public static backgroundmusic instance;
	public GameObject bgmusic;

	// Use this for initialization
	void Awake () {
		MakeSingletone ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void MakeSingletone ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
}
