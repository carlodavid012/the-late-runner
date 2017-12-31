using UnityEngine;
using System.Collections;

public class Resume : MonoBehaviour {

	public GameObject panel;
	public GameObject pause;


	public void resumeGame(){
		Time.timeScale = 1f;

		panel.SetActive(false);

		pause.SetActive(true);

		AudioListener.pause = false;
	}
}
