using UnityEngine;
using System.Collections;

public class ChangeTexture : MonoBehaviour {

	public static ChangeTexture instance;
	public  Texture2D texture1;
	public  Texture2D texture2;
	public  Texture2D texture3;
	public Renderer rend;

	// Use this for initialization
	void Start () {
		StartCoroutine (textureSwap());
		StartCoroutine (textureSwap2());
		rend = GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	IEnumerator textureSwap(){
			yield return new WaitForSeconds(60f);
			rend.material.mainTexture = texture1;
	}

	IEnumerator textureSwap2(){
			yield return new WaitForSeconds(110f);
			rend.material.mainTexture = texture3;
	}


	void CreateInstance(){
		if(instance==null){
			instance = this;
		}
	}


	
}
