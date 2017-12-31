using UnityEngine;
using System.Collections;

public class Achievements : MonoBehaviour {



	public GameObject check1,check2,check3,check4;


	float firstAchievement = 1f;
	float secondAchievement = 1f;
	float thirdAchievement = 1f;
	float fourthAchievement = 1f;




	void Awake ()
	{
		/*
		PlayerPrefs.SetInt("Coins",0);

		PlayerPrefs.SetInt("Score",0);
		PlayerPrefs.SetFloat("firstAchievement",1f);
		PlayerPrefs.SetFloat("secondAchievement",1f);
		PlayerPrefs.SetFloat("thirdAchievement",1f);
		PlayerPrefs.SetFloat("fourthAchievement",1f);

		Debug.Log(PlayerPrefs.GetFloat("firstAchievement"));
		Debug.Log(PlayerPrefs.GetFloat("secondAchievement"));
		Debug.Log(PlayerPrefs.GetFloat("thirdAchievement"));
		Debug.Log(PlayerPrefs.GetFloat("fourthAchievement"));



	*/


	/*
	PlayerPrefs.SetFloat("firstAchievement",1f);
		PlayerPrefs.SetFloat("secondAchievement",1f);
		PlayerPrefs.SetFloat("thirdAchievement",1f);
		PlayerPrefs.SetFloat("fourthAchievement",1f);

		PlayerPrefs.SetInt("Coins",0);
		PlayerPrefs.SetInt("Score",0);

		*/

		firstAchievement=PlayerPrefs.GetFloat("firstAchievement",firstAchievement);
		secondAchievement=PlayerPrefs.GetFloat("secondAchievement",secondAchievement);
		thirdAchievement=PlayerPrefs.GetFloat("thirdAchievement",thirdAchievement);
		fourthAchievement=PlayerPrefs.GetFloat("fourthAchievement",fourthAchievement);
	

		Debug.Log (PlayerPrefs.GetInt ("Score"));
		Debug.Log(PlayerPrefs.GetFloat("firstAchievement"));
		Debug.Log(PlayerPrefs.GetFloat("secondAchievement"));
		Debug.Log(PlayerPrefs.GetFloat("thirdAchievement"));
		Debug.Log(PlayerPrefs.GetFloat("fourthAchievement"));




	

	

		//end if


	}

	// Use this for initialization
	void Start ()

	{
		
		if (firstAchievement == 1f) {
			
			if (PlayerPrefs.GetInt ("Score") >= 150) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 150);
				check1.SetActive (true);
				PlayerPrefs.SetFloat ("firstAchievement", 0);
				AdsController.instance.ShowAd();
			}

		} else {
			if(PlayerPrefs.GetInt ("Score") >= 150){
				check1.SetActive (true);
			}
		}


		if (secondAchievement==1f) {
			
			if (PlayerPrefs.GetInt ("Score") >= 250) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 250);
				PlayerPrefs.SetFloat ("secondAchievement", 0);
				AdsController.instance.ShowAd();
			}

		} else {
			if(PlayerPrefs.GetInt ("Score") >= 250){
				check2.SetActive (true);
			}
		}

		if (thirdAchievement==1f) {
			
			if (PlayerPrefs.GetInt ("Score") >= 450) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 450);
				PlayerPrefs.SetFloat ("thirdAchievement", 0);
				AdsController.instance.ShowAd();
			}

		} else {
			if(PlayerPrefs.GetInt ("Score") >= 450){
				check3.SetActive (true);
			}
		}

		if (fourthAchievement==1f) {
			
			if (PlayerPrefs.GetInt ("Score") >= 650) {
				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + 650);
				PlayerPrefs.SetFloat ("fourthAchievement", 0);
				AdsController.instance.ShowAd();
			}

		} else {
			if(PlayerPrefs.GetInt ("Score") >= 650){
				check4.SetActive (true);
			}
		}

	}

	void Update(){
		

	}

}
