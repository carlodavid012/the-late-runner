using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Coin : MonoBehaviour {

	public int CoinsToAdd;
	public AudioSource audiocoins,ice,powerup;




	void OnTriggerEnter2D (Collider2D other)
	{
		if (this.gameObject.tag == "Coin" && other.gameObject.tag != "Collector" && other.gameObject.tag != "Zombie") {

			CoinsManager.AddCoins((CoinsToAdd));	
			//Destroy(this.gameObject);
			this.gameObject.SetActive(false);
			audiocoins.Play();

		}

		if (this.gameObject.tag == "Ice" && other.gameObject.tag != "Collector" && other.gameObject.tag != "Zombie") {

			
			this.gameObject.SetActive(false);
			ice.Play();

		}

		if (this.gameObject.tag == "Shield" && other.gameObject.tag != "Collector" || this.gameObject.tag == "x2 Score" && other.gameObject.tag != "Collector" && other.gameObject.tag != "Zombie") {


			this.gameObject.SetActive(false);
			powerup.Play();

		}

	}




}
