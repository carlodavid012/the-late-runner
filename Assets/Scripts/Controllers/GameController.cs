using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameController : MonoBehaviour {

	public static GameController instance;

	private GameData data;
	//[HideInInspector]
	public static bool isGameStartedFirstTime;
	//[HideInInspector]
	public GameObject audio;
	//[HideInInspector]
	public int selectedPlayer;


	//[HideInInspector]
	//public bool[]players;



	void Awake(){
		MakeSingleTon();
		InitializeGameVariables();
		//Save ();


	}

	void Start () {



		
		
	}

	void MakeSingleTon ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void InitializeGameVariables ()
	{

		Load ();

		if (data != null) {
			isGameStartedFirstTime = data.getIsGameStartedFirstTime ();
		} else {
			isGameStartedFirstTime = true;
		}

		if (isGameStartedFirstTime) {

			selectedPlayer = 0; 
			isGameStartedFirstTime = false;

			//players = new bool[5];

			//players [0] = true;
			//for (int i = 1; i < players.Length; i++) {
			//	players [i] = false;
			//} 

			data = new GameData ();

			data.setSelectedPlayer (selectedPlayer);  
			data.setIsGameStartedFirstTime (isGameStartedFirstTime);
			//data.setPlayers (players);

			Save ();
			Load ();

		} else {

			selectedPlayer = data.getSelectedPlayer();
			isGameStartedFirstTime = data.getIsGameStartedFirstTime();
			//players = data.getPlayers();


		}

	}//initialize variables


	public void Save ()
	{

		FileStream file = null;

		try {

			BinaryFormatter bf = new BinaryFormatter ();

			file = File.Create (Application.persistentDataPath + "/GameData.dat");

			if (data != null) {
				data.setIsGameStartedFirstTime (isGameStartedFirstTime);
				//data.setPlayers (players);

				data.setSelectedPlayer (selectedPlayer);

				bf.Serialize (file, data);
			}

		} catch (Exception e) {

		} finally {
			if (file != null) {
				file.Close();
			}
		}
	}

	public void Load ()
	{
		FileStream file = null;

		try {

			BinaryFormatter bf = new BinaryFormatter ();
			file = File.Open (Application.persistentDataPath + "/GameData.dat", FileMode.Open);

			data = (GameData)bf.Deserialize (file);

		} catch (Exception e) {
			
		} finally {
			if (file != null) {
				file.Close();
			}
		}
	}
	
	// Update is called once per frame

}//game controller

[Serializable]
public class GameData{

	private bool isGameStartedFirstTime;



	private int selectedPlayer;


	//private bool[]players;


	public void setIsGameStartedFirstTime(bool isGameStartedFirstTime){
		this.isGameStartedFirstTime = isGameStartedFirstTime;
	}

	public bool getIsGameStartedFirstTime(){
		return this.isGameStartedFirstTime;
	}

	public void setSelectedPlayer(int selectedPlayer){
		this.selectedPlayer = selectedPlayer;
	}

	public int getSelectedPlayer(){
		return this.selectedPlayer;
	}

	//public void setPlayers(bool[] players){
	//	this.players = players;
//	}

	//public bool[]getPlayers(){
	//	return this.players;
	//}
}

