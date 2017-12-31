using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PowerUps1 : MonoBehaviour {

	public static PowerUps1 instance;
	public GameObject shieldPanel,icePanel,x2scorePanel;
	public Text shield,ice,x2score;
	public Text shieldNumber,iceNumber,scoreNumber;

	public GameObject notEnoughPanel;
	int shieldPrice = 60;
	int icePrice = 60;
	int scorePrice = 60;
	int random=1;


	public Text shieldPriceText,icePriceText,scorePriceText;

	 public bool addShieldPrice = false,addIceprice =false ,addScoreprice = false;

	 bool enoughCoinForShield = false;

	 bool addOnce;

	void Awake(){
	/*
		shieldNumber.text = PlayerPrefs.GetFloat("shieldTime") + 5f +" sec.";
		iceNumber.text = PlayerPrefs.GetFloat("iceTime") + 5f + " sec.";
		scoreNumber.text = PlayerPrefs.GetFloat("scoreTime") + 5f + " sec.";
		*/
		shieldPrice = PlayerPrefs.GetInt("shieldPrice",shieldPrice);
		icePrice = PlayerPrefs.GetInt("icePrice",icePrice);
		scorePrice = PlayerPrefs.GetInt("scorePrice",scorePrice) ;

		if(PlayerPrefs.GetFloat("shieldTime")==0){
			PlayerPrefs.SetFloat("shieldTime",5f);
		}

		if(PlayerPrefs.GetFloat("scoreTime")==0){
			PlayerPrefs.SetFloat("scoreTime",5f);
		}
		if(PlayerPrefs.GetFloat("iceTime")==0){
			PlayerPrefs.SetFloat("iceTime",5f);
		}

		if(PlayerPrefs.GetInt("shieldPrice")==0){
			PlayerPrefs.SetInt("shieldPrice",60);
		}
		if(PlayerPrefs.GetInt("icePrice")==0){
			PlayerPrefs.SetInt("icePrice",60);
		}
		if(PlayerPrefs.GetInt("scorePrice")==0){
			PlayerPrefs.SetInt("scorePrice",60);
		}


	}

	void Update(){

		shieldNumber.text = PlayerPrefs.GetFloat("shieldTime") + " sec.";
		iceNumber.text = PlayerPrefs.GetFloat("iceTime") + " sec.";
		scoreNumber.text = PlayerPrefs.GetFloat("scoreTime") + " sec.";



		shieldPrice =PlayerPrefs.GetInt("shieldPrice");
		icePrice =PlayerPrefs.GetInt("icePrice");
		scorePrice=PlayerPrefs.GetInt("scorePrice");

		shieldPriceText.text = shieldPrice.ToString();
		icePriceText.text = icePrice.ToString();
		scorePriceText.text = scorePrice.ToString();



	

		if(enoughCoinForShield){
			if (CoinsManager.Coins >= shieldPrice) {
				shieldPanel.SetActive (true);
				shield.text = "Do you want to upgrade shield for " + shieldPrice + " coins?" ;
			} else {
				notEnoughPanel.SetActive(true);
			}
			enoughCoinForShield = false;
		}//enough


	
		
		random = PlayerPrefs.GetInt("random",random);
		Debug.Log(PlayerPrefs.GetInt("random"));

	}

	public void shieldButton ()
	{

		//shieldPrice = 60;
		enoughCoinForShield = true;

	}

	public void IceButton ()
	{
		//icePrice = 60;
		if (CoinsManager.Coins >= icePrice) {
			icePanel.SetActive (true);
			ice.text = "Do you want to upgrade Freeze for " + icePrice + " coins?";
		} else {
			notEnoughPanel.SetActive(true);
		}

	}

	public void x2ScoreButton ()
	{
		//scorePrice = 60;
		if (CoinsManager.Coins >= scorePrice) {
			x2scorePanel.SetActive (true);
			x2score.text = "Do you want to upgrade x2 Score for " +scorePrice + " coins?";
		}else {
			notEnoughPanel.SetActive(true);
		}


	}		



	public void shieldYes ()
	{
		
		PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - shieldPrice);
			PlayerPrefs.SetFloat ("shieldTime", PlayerPrefs.GetFloat ("shieldTime") + 2f);
			shieldPanel.SetActive (false);
			shieldNumber.text = PlayerPrefs.GetFloat ("shieldTime") + 5f + " sec.";
			CoinsManager.Coins -= shieldPrice;
			//PlayerPrefs.SetInt("shieldPrice",PlayerPrefs.GetInt("shieldPrice")+20);

			PlayerPrefs.SetInt("shieldPrice",PlayerPrefs.GetInt("shieldPrice")+10);
			addShieldPrice =false;
			Debug.Log("added");
		
	}
	public void iceYes ()
	{
		
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - 60);
			PlayerPrefs.SetFloat ("iceTime", PlayerPrefs.GetFloat ("iceTime") + 2f);
			icePanel.SetActive (false);
			iceNumber.text = PlayerPrefs.GetFloat ("iceTime") + 5f + " sec.";
			CoinsManager.Coins -= icePrice;
			//PlayerPrefs.SetInt("icePrice",PlayerPrefs.GetInt("icePrice")+20);
		PlayerPrefs.SetInt("icePrice",PlayerPrefs.GetInt("icePrice")+10);
			addIceprice = false;
			Debug.Log("added");
	}

	public void scoreYes ()
	{
		
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - 60);
			PlayerPrefs.SetFloat ("scoreTime", PlayerPrefs.GetFloat ("scoreTime") + 2f);
			x2scorePanel.SetActive (false);
			scoreNumber.text = PlayerPrefs.GetFloat ("scoreTime") + 5f + " sec.";
			CoinsManager.Coins -= scorePrice;
		//PlayerPrefs.SetInt("scorePrice",PlayerPrefs.GetInt("scorePrice")+20);
		PlayerPrefs.SetInt("scorePrice",PlayerPrefs.GetInt("scorePrice")+10);
			addScoreprice = false;
			Debug.Log("added");
	}

	public void No(){
		shieldPanel.SetActive(false);
		icePanel.SetActive(false);
		x2scorePanel.SetActive(false);
	}

	void CreateInstance ()
	{
		if (instance == null) {
			instance = this;
		}
	}


	IEnumerator loadShop(){
		yield return new WaitForSeconds(0.1f);
		Application.LoadLevel("Shop");

	}
}
