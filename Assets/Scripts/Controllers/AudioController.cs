using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class AudioController : MonoBehaviour {

	public static AudioController acInstance;
	public AudioSource myAudioSource;
	public AudioClip dead;
	public AudioClip menu;
	public GameObject settingsPanel;

	public GameObject musicOn,musicOff;

	public AudioListener audio;

	public GameplayController gameplay = new GameplayController();

	void Awake () {

		if(acInstance==null){
			acInstance = this;
		}
		if(false){
			myAudioSource.mute = true;
		}


	}



	public void PlayDeadSound(){
		myAudioSource.PlayOneShot (dead);
	}

	public void Back(){
		settingsPanel.SetActive(false);
		Time.timeScale = 1f;
	}

	public void MusicOn(){
		
		AudioListener.pause = false;
		musicOn.SetActive(false);
		musicOff.SetActive(true);

	}

	public void MusicOff(){
		

		AudioListener.pause = true;
		musicOff.SetActive(false);
		musicOn.SetActive(true);

	}
}
