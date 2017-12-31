using UnityEngine;
using System.Collections;



public class PlayerDeath : MonoBehaviour {

	public static PlayerDeath instance;
	public delegate void EndGame();
	public static event EndGame endGame;
	public GameObject shield;
	public static bool hasNoShield,hasNoIce;

	public bool isShieldOn;

	public bool isIceOn;

	void Awake(){
		hasNoShield = true;
		hasNoIce = true;
		isShieldOn = false;
		isIceOn = false;
	

	}

	void PlayerDied(){
		if(endGame != null){
			endGame ();
		}

		this.gameObject.SetActive(false);
		//Destroy (gameObject);
	}



	void OnTriggerEnter2D (Collider2D other)
	{
		

		if (other.tag == "Shield") {
			
			other.gameObject.SetActive(false);
			shieldOn();

		

		} else if(other.tag == "Ice"){
			


			other.gameObject.SetActive(false);
		
			iceOn();

		} else if (other.tag == "Zombie") {
			if (hasNoShield && hasNoIce) {
				PlayerDied ();
			}
		} else if(other.tag == "x2 Score"){
			GameplayController.instance.scoreMultiplier = 4;
			GameplayController.instance.scorePowerUpsText.SetActive(true);
		
			StartCoroutine(x2Score());
			//Destroy(other.gameObject);

			other.gameObject.SetActive(false);

		} 


	}



	IEnumerator shieldDuration(){
		yield return new WaitForSeconds(PlayerPrefs.GetFloat("shieldTime"));
		hasNoShield = true;
		shield.SetActive(false);

	
	}

	IEnumerator x2Score(){
		yield return new WaitForSeconds(PlayerPrefs.GetFloat("iceTime"));
		GameplayController.instance.scoreMultiplier = 1;
		GameplayController.instance.scorePowerUpsText.SetActive(false);

	}

	IEnumerator IceDuration ()
	{
		yield return new WaitForSeconds (PlayerPrefs.GetFloat("scoreTime"));

		hasNoIce = true;
		Obstacle.hasFrozen = false;


	}

	public void shieldOn(){
		shield.SetActive (true);
		hasNoShield = false;

		StartCoroutine(shieldDuration());

	}

	public void iceOn(){
		hasNoIce = false;

			Obstacle.hasFrozen = true;


			StartCoroutine(IceDuration());
	}


	void CreateInstance(){
		if(instance == null){
			instance = this;
		}
	}

}
