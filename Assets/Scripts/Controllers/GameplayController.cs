 using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameplayController : MonoBehaviour {



	public static GameplayController instance;
	public AudioClip sounds;
	public AudioSource bgSound,playerOut;

	public GameObject birdSpawner,obstacleSpawner;

	public GameObject player;

	public GameObject gameoverText;

	public static float newY;
	public Text infoText2;

	public GameObject character,kid,pirate,tiger,croco;

	public GameObject[] players;

	GameObject clone;

	[SerializeField]
	private GameObject pausePanel,blackPanel;


	public GameObject music;

	public GameObject chk1,chk2,chk3;

	public GameObject pauseButton;
	[SerializeField]
	private Button restartButton;

	public Texture bg;

	public GameObject x2score;

	public Text scoreText, pauseText,highScoreText,coinText;

	public int score,coins;

	public static int highscore;

	public GameObject continuePanel;

	public int scoreMultiplier;

	public GameObject scorePowerUpsText;

	public float shieldTime = 5f;
	public float iceTime = 5f;
	public float scoreTime = 5f;

	int numberOftry = 0;



	public float firstAchievement = 1f; 
	public float secondAchievement = 1f; 
	public float thirdAchievement = 1f; 
	public float fourthAchievement = 1f; 




	void MakeSingletone ()
	{
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

	void Awake(){
		
		bgSound = GetComponent<AudioSource>();
		Time.timeScale = 0;
		CreateInstance();
		InitializePlayer();

		bg = (Texture)Resources.Load("123.png");
		scoreMultiplier = 1;

		shieldTime = PlayerPrefs.GetFloat("shieldTime",shieldTime);
		iceTime = PlayerPrefs.GetFloat("iceTime",iceTime);
		scoreTime = PlayerPrefs.GetFloat("scoreTime",scoreTime);

		AudioListener.pause = true;
		//achievments
		firstAchievement = PlayerPrefs.GetFloat ("firstAchievement", firstAchievement);
		secondAchievement = PlayerPrefs.GetFloat ("secondAchievement", secondAchievement);
		thirdAchievement = PlayerPrefs.GetFloat ("thirdAchievement", thirdAchievement);
		fourthAchievement = PlayerPrefs.GetFloat ("fourthAchievement", fourthAchievement);
	}

	void InitializePlayer(){

		clone = Instantiate(players[GameController.instance.selectedPlayer],new Vector3(-3.22f,-1.97f,-9f), Quaternion.identity) as GameObject;

	}



	public void CreateInstance(){
		if(instance==null)
			instance = this;
	}

	void Start(){
		
		scoreText.text = "" + "Score: " + score ;
		StartCoroutine (CountScore ());
		StartCoroutine(Difficulty());
		StartCoroutine(Difficulty1());
		StartCoroutine(Difficulty2());
		StartCoroutine(Difficulty3());
		StartCoroutine(Difficulty4());
		StartCoroutine(Difficulty5());




		character = GameObject.Find("Player(Clone)");
		kid = GameObject.Find("Kid(Clone)");
		tiger = GameObject.Find("Tiger(Clone)");
		croco = GameObject.Find("Crocodile(Clone)");
		pirate = GameObject.Find("Pirate(Clone)");


	
	

	}


	void Update(){

	}


	IEnumerator CountScore ()
	{
		yield return new WaitForSeconds (0.6f);
		score= score + scoreMultiplier;

		if (score >= 100) {
			score = score + 2;
		}

		if (score >= 300) {
			score = score + 3;
		}
		scoreText.text = "" + "Score: " + score ;
		StartCoroutine (CountScore ());
	}


	void OnEnable(){
		PlayerDeath.endGame += PlayerDied;
	}

	void OnDisable(){
		PlayerDeath.endGame -= PlayerDied;
	}

	public void PlayerDied ()
	{
		
		if (CoinsManager.Coins >= 30 && numberOftry==0) {
			continuePanel.SetActive (true);
		} else 
			continuePanelNo();



		bgSound.Stop ();
		Time.timeScale = 0f;
		playerOut.Play();
		x2score.SetActive(false);



		//if(PlayerDeath){
	
	}





	public void continuePanelNo()
	{
		pausePanel.SetActive (true);
		continuePanel.SetActive(false);
		if (!PlayerPrefs.HasKey ("Score")) {
			PlayerPrefs.SetInt ("Score", score);
		} else {
			highscore = PlayerPrefs.GetInt ("Score");

			if (highscore < score) {
				

				PlayerPrefs.SetInt ("Score", score);
				highScoreText.text = "" + score;


			} else {
				highScoreText.text = "" + highscore;
				
			}


			bgSound.Stop ();
			numberOftry = 0;
		}

		//plusCoins();

		if (score <= 50) {
			pauseText.text = "Are you drunk?";
		} else if (score <= 100) {
			pauseText.text = "You always die";
		} else if (score <= 200) {
			pauseText.text = "Are you blind?";
		} else if (score <= 250) {
			pauseText.text = "You're really bad at this game";
		} else if (score <= 360) {
			pauseText.text = "Your hands are too slow";
		
		} else if (score > highscore) {
			pauseText.text = "You are awesome!!";
			AdsController.instance.ShowAd();
		} else { 
			pauseText.text = "Better Luck Next Time";
		}


		restartButton.onClick.RemoveAllListeners();
		restartButton.onClick.AddListener (() => RestartGame());
		Time.timeScale = 0f;
		pauseButton.SetActive(false);
		BGLooper.speed = 0.2f;
		Obstacle.speed = -5f;
		Jump.jumpSpeed = 5f;
		ObstacleSpawner.spawnMin = 0.9f;
		ObstacleSpawner.spawnMax = 1.2f;
		AudioController.acInstance.PlayDeadSound ();
		gameoverText.SetActive(true);
	}









	

	public void continuePanelYes ()
	{

		





		if (numberOftry == 0) {
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - 30);
			CoinsManager.Coins -= 30                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 ;
			float pos = 0;



			if(character != null){
				if (character.transform.position.y <= 0.111f && character.transform.position.y >= -2.09f) {
				pos = -4.07f;
				}
				if(character.transform.position.y <= -2.09f && character.transform.position.y >= -4.23f){
					pos = 0.111f;
				}
			}

			if(kid != null){

				if (kid.transform.position.y <= 0.111f && kid.transform.position.y >= -2.09f) {
				pos = -4.07f;

				} 
				if(kid.transform.position.y <= -2.09f && kid.transform.position.y >= -4.23f) {
					pos = 0.111f;
				}

				 
			}

			if(pirate != null){

				if (pirate.transform.position.y <= 0.111f && pirate.transform.position.y >= -2.09f) {
				pos = -4.07f;

				} 
				if(pirate.transform.position.y <= -2.09f && pirate.transform.position.y >= -4.23f) {
					pos = 0.111f;
				}

				 
			}

			if(tiger != null){

				if (tiger.transform.position.y <= 0.111f && tiger.transform.position.y >= -2.09f) {
				pos = -4.07f;

				} 
				if(tiger.transform.position.y <= -2.09f && tiger.transform.position.y >= -4.23f) {
					pos = 0.111f;
				}

			}

			if(croco != null){

				if (croco.transform.position.y <= 0.111f && croco.transform.position.y >= -2.09f) {
				pos = -4.07f;

				} 
				if(croco.transform.position.y <= -2.09f && croco.transform.position.y >= -4.23f) {
					pos = 0.111f;
				}

				 
			}





			Instantiate (players [GameController.instance.selectedPlayer], new Vector3 (-3.22f, pos, -9f), Quaternion.identity);
			numberOftry += 1;
			continuePanel.SetActive (false);
			Time.timeScale = 1f;
			bgSound.Play ();
			numberOftry += 1;



		}
			
		

	}



	public void PauseGame(){
		Time.timeScale = 0f;
		pausePanel.SetActive (true);
		restartButton.onClick.RemoveAllListeners();
		restartButton.onClick.AddListener (() => ResumeGame());
		highscore = PlayerPrefs.GetInt ("Score");
		highScoreText.text = ""+ highscore;
		AudioListener.pause = true;
	}

	public void ResumeGame(){
		Time.timeScale = 1f;
		pausePanel.SetActive (false);
		pauseButton.SetActive(true);
		AudioListener.pause = false;
	

	}

	public void RestartGame(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Gameplay");
		bgSound.Play();
		pauseButton.SetActive(true);
		gameoverText.SetActive(false);
		obstacleSpawner.SetActive(true);
		birdSpawner.SetActive(false);
		blackPanel.SetActive(false);
		ChangeTexture.instance.rend.material.mainTexture = ChangeTexture.instance.texture2;
		Obstacle.hasFrozen = false;
		PowerUpsSpawner.cspawnMax = 10f;
		PowerUpsSpawner.cspawnMin = 8f;


	}

	public void GoToMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("MainMenu");

		BGLooper.speed = 0.2f;
		Obstacle.speed = -5f;
		Jump.jumpSpeed = 5f;
		ObstacleSpawner.spawnMin = 0.9f;
		ObstacleSpawner.spawnMax = 1.2f;

		AudioListener.pause = false;
		PowerUpsSpawner.cspawnMax = 10f;
		PowerUpsSpawner.cspawnMin = 8f;

		backgroundmusic.instance.gameObject.SetActive(true);
	}


	IEnumerator Difficulty(){
		yield return new WaitForSeconds(15f);
		BGLooper.speed = 0.4f;
		Obstacle.speed = -7.2f;
		Jump.jumpSpeed = 5.8f;
		infoText2.text = "Hurry Up!";
		StartCoroutine (clearText());

	}

	IEnumerator Difficulty1(){
		yield return new WaitForSeconds(30f);
		BGLooper.speed = 0.6f;
		Obstacle.speed = -8.3f;
		Jump.jumpSpeed = 6.3f;
		ObstacleSpawner.spawnMin = 0.7f;
		ObstacleSpawner.spawnMax = 1.0f;

		infoText2.text = "Huuurrry Up!!!";
		StartCoroutine (clearText());


	}



	IEnumerator Difficulty2(){
		yield return new WaitForSeconds(45f);
		BGLooper.speed = 0.7f;
		Obstacle.speed = -11.2f;
		Jump.jumpSpeed = 7f;
		ObstacleSpawner.spawnMin = 0.5f;
		ObstacleSpawner.spawnMax = 0.8f;

		infoText2.text = "Run Faasteeerr!!";
		StartCoroutine (clearText());
	}

	IEnumerator Difficulty3(){
		yield return new WaitForSeconds(60f);
		BGLooper.speed = 0.9f;
		Obstacle.speed = -13.2f;
		Jump.jumpSpeed = 8f;
		ObstacleSpawner.spawnMin = 0.4f;
		ObstacleSpawner.spawnMax = 0.7f;
		obstacleSpawner.SetActive(false);
		birdSpawner.SetActive(true);
		blackPanel.SetActive(true);
		infoText2.text = "Run Fasteeeerrr!!!";
		PowerUpsSpawner.cspawnMax -= 1f;
		PowerUpsSpawner.cspawnMin -= 1f;
		StartCoroutine (clearText());

	}

	IEnumerator Difficulty4(){
		yield return new WaitForSeconds(75f);
		BGLooper.speed = 1.1f;
		Obstacle.speed = -14.2f;
		Jump.jumpSpeed = 8.5f;
		ObstacleSpawner.spawnMin = 0.4f;
		ObstacleSpawner.spawnMax = 0.7f;
		PowerUpsSpawner.cspawnMax -= 1f;
		PowerUpsSpawner.cspawnMin -= 1f;
		infoText2.text = "Run Fasteeeerrrr!!!!";
		StartCoroutine (clearText());

	}

	IEnumerator Difficulty5(){
		yield return new WaitForSeconds(110f);
		BGLooper.speed = 1.3f;
		Obstacle.speed = -16.2f;
		Jump.jumpSpeed = 9f;
		ObstacleSpawner.spawnMin = 0.3f;
		ObstacleSpawner.spawnMax = 0.6f;
		infoText2.text = "Run Fasteeeerrrrrr!!!!!";
		StartCoroutine (clearText());
		blackPanel.SetActive(false);
		PowerUpsSpawner.cspawnMax -= 1f;
		PowerUpsSpawner.cspawnMin -= 1f;
	}

	IEnumerator clearText(){
		yield return new WaitForSeconds(4f);
		infoText2.text="";
	}




}
