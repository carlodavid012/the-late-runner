using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashFade : MonoBehaviour {

	public Image splashImage;
	public string loadLevel;

	void Awake(){
		
	}

	IEnumerator Start ()
	{
		splashImage.canvasRenderer.SetAlpha(0.0f);

		FadeIn();
		yield return new WaitForSeconds(3.5f);
		FadeOut();
		yield return new WaitForSeconds(1.4f);
		SceneManager.LoadScene(loadLevel);



	}

	void FadeIn (){
		splashImage.CrossFadeAlpha(1.0f, 1.5f, false);
	}

	void FadeOut (){
		splashImage.CrossFadeAlpha(0f, 1.5f, false);
	}

	
}//end class
