using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class CoinsManager : MonoBehaviour {

	
	public static   int Coins;
	public int CoinsToAdd;

	public static Text text;

	void Awake(){

	}

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		Coins = PlayerPrefs.GetInt("Coins",Coins);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Coins < 0)
			Coins = 0;


		text.text = "" + "x " + Coins;


	}

	public static void AddCoins(int CoinsToAdd){
		Coins+=CoinsToAdd;
		PlayerPrefs.SetInt("Coins",Coins);
		if(Coins==null)
			Coins = 0;
	}



}
