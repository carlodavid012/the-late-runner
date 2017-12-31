using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class MainMenuController : MonoBehaviour {

	public static MainMenuController instance;
	public GameObject optionsPanel;
	public GameObject music,quitbutton,quitpanel,quitNo,quitYes;
	public AudioSource audioSource;




	int oldDate;

	void Awake(){
		
		CreateInstance();
	}

	void Start(){
		
	}

	void Update(){




	


	}


	public void PlayGame(){
		SceneManager.LoadScene ("Gameplay");

		backgroundmusic.instance.gameObject.SetActive(false);
	}

	public void Shop ()
	{
		SceneManager.LoadScene ("Shop");
	}

	public void Quit(){
		//Savee the current system time as a string in the player prefs class
         PlayerPrefs.SetString("sysString", System.DateTime.Now.ToBinary().ToString());
 
         print("Saving this date to prefs: " + System.DateTime.Now);
		Application.Quit ();

	}
	public void Info(){
		
	}

	public void BackToMenu(){
		SceneManager.LoadScene ("MainMenu");
	}

	public void Settings(){
		optionsPanel.SetActive(true);
		Time.timeScale = 0;
	
	}

	void CreateInstance(){
		if(instance==null){
			instance=this;
		}
	}


	public void showQuitPanel(){
		quitpanel.SetActive(true);
		Time.timeScale = 0;
		AudioListener.pause = true;
	}

	public void quitPanelYes(){
		Application.Quit();
	}

	public void quitPanelNo(){
		quitpanel.SetActive(false);
		Time.timeScale = 1f;
		AudioListener.pause = false;;
	}


	public void About(){
		SceneManager.LoadScene("About");

	}

	public void Achievements(){
		SceneManager.LoadScene("Achievements");

	}
}
