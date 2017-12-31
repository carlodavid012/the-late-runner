using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMenuController : MonoBehaviour {

	public bool[]players;

	public Image[]priceTags;

	public int selectedPlayer;

	public GameObject buypanelkid,buypanelcroco,buypaneltiger,buypanelpirate,notEnoughPanel;

	public Button yesBtn;

	public Image[]selectIcon;

	public Text buyPlayerText;

	public Image kid;


	public int[]characters;

	public GameObject powerUpsPanel,characterPanel;

	public int myValue = 0;

	int char1,char2,char3,char4 = 0;


	void Awake(){
		
	}

	// Use this for initialization
	void Start () {

		char1 = PlayerPrefs.GetInt ("char1", char1);
		char2 = PlayerPrefs.GetInt("char2", char2);
		char3 = PlayerPrefs.GetInt("char3", char3);
		char4 = PlayerPrefs.GetInt("char4", char4);

	
		

		InitializePlayerMenuController();

	
	}

	void InitializePlayerMenuController(){
		
		//players = GameController.instance.players;
		selectedPlayer = GameController.instance.selectedPlayer;


		for(int i=0; i<selectIcon.Length; i++){
			selectIcon[i].gameObject.SetActive(false);
		}



			if(char1==1){
				priceTags[0].gameObject.SetActive(false);
			}

		if(char2==1){
				priceTags[1].gameObject.SetActive(false);
			}

		if(char3==1){
				priceTags[2].gameObject.SetActive(false);
			}

		if(char4==1){
				priceTags[3].gameObject.SetActive(false);
			}
		

		selectIcon[selectedPlayer].gameObject.SetActive(true);
	}

	public void Player1Button (){

		if (selectedPlayer != 0) {
			selectedPlayer = 0;

			selectIcon [selectedPlayer].gameObject.SetActive (true);

			for (int i = 0; i < selectIcon.Length; i++) {
				if (i == selectedPlayer)
					continue;

				selectIcon [i].gameObject.SetActive (false);
			}

			GameController.instance.selectedPlayer = selectedPlayer;
			GameController.instance.Save ();
		} 
	}

	public void KidButton ()
	{

		if (PlayerPrefs.GetInt ("char1") == 1) {
			if (selectedPlayer != 1) {

				selectedPlayer = 1;

				selectIcon [selectedPlayer].gameObject.SetActive (true);

				for (int i = 0; i < selectIcon.Length; i++) {
					if (i == selectedPlayer)
						continue;

					selectIcon [i].gameObject.SetActive (false);
				}

				GameController.instance.selectedPlayer = selectedPlayer;
				GameController.instance.Save ();
			} 
		} else {

			if (CoinsManager.Coins >= 200) {

				buypanelkid.SetActive(true);
				yesBtn.onClick.RemoveAllListeners();
				yesBtn.onClick.AddListener(() => BuyPlayerkid());
			} else {
				buypanelkid.SetActive(false);
				notEnoughPanel.SetActive(true);
				yesBtn.onClick.RemoveAllListeners();


			}
			
		}
		
	}	

	public void CrocoButton ()
	{

		if (PlayerPrefs.GetInt ("char2") == 1) {
			if (selectedPlayer != 2) {
				selectedPlayer = 2;

				selectIcon [selectedPlayer].gameObject.SetActive (true);

				for (int i = 0; i < selectIcon.Length; i++) {
					if (i == selectedPlayer)
						continue;

					selectIcon [i].gameObject.SetActive (false);
				}

				GameController.instance.selectedPlayer = selectedPlayer;
				GameController.instance.Save ();
			} 
		} else {

			if (CoinsManager.Coins >= 300) {

				buypanelcroco.SetActive(true);
				yesBtn.onClick.RemoveAllListeners();
				yesBtn.onClick.AddListener(() => BuyPlayercroco());
			} else {
				buypanelcroco.SetActive(false);
				notEnoughPanel.SetActive(true);
				yesBtn.onClick.RemoveAllListeners();

			}
			
		}
		
	}	

	public void TigerButton ()
	{

		if (PlayerPrefs.GetInt ("char3") == 1) {
			if (selectedPlayer != 3) {
				selectedPlayer = 3;

				selectIcon [selectedPlayer].gameObject.SetActive (true);

				for (int i = 0; i < selectIcon.Length; i++) {
					if (i == selectedPlayer)
						continue;

					selectIcon [i].gameObject.SetActive (false);
				}

				GameController.instance.selectedPlayer = selectedPlayer;
				GameController.instance.Save ();
			} 
		} else {

			if (CoinsManager.Coins >= 400) {

				buypaneltiger.SetActive(true);
				yesBtn.onClick.RemoveAllListeners();
				yesBtn.onClick.AddListener(() => BuyPlayertiger());
			} else {
				buypaneltiger.SetActive(false);
				notEnoughPanel.SetActive(true);
				yesBtn.onClick.RemoveAllListeners();

			}
			
		}
		
	}	

	public void RedButton ()
	{

		if (PlayerPrefs.GetInt ("char4") == 1) {
			if (selectedPlayer != 4) {
				selectedPlayer = 4;

				selectIcon [selectedPlayer].gameObject.SetActive (true);

				for (int i = 0; i < selectIcon.Length; i++) {
					if (i == selectedPlayer)
						continue;

					selectIcon [i].gameObject.SetActive (false);
				}

				GameController.instance.selectedPlayer = selectedPlayer;
				GameController.instance.Save ();
			} 
		} else {

			if (CoinsManager.Coins >= 500) {

				buypanelpirate.SetActive(true);
				yesBtn.onClick.RemoveAllListeners();
				yesBtn.onClick.AddListener(() => BuyPlayerpirate());
			} else {
				buypanelpirate.SetActive(false);
				notEnoughPanel.SetActive(true);
				yesBtn.onClick.RemoveAllListeners();

			}

		}
		
	}	
	public void BuyPlayerkid(){
		
		PlayerPrefs.SetInt ("char1",1);
		//GameController.instance.players [index] = true;
		PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-100);
		CoinsManager.Coins -= 100;
	
		PlayerPrefs.SetFloat ("shieldTime", PlayerPrefs.GetFloat ("shieldTime") + 1.5f);
		PlayerPrefs.SetFloat ("iceTime", PlayerPrefs.GetFloat ("iceTime") + 1.5f);

		priceTags[0].gameObject.SetActive(false);

		GameController.instance.Save(); 
		InitializePlayerMenuController();

		buypanelkid.SetActive(false);
	}
	public void BuyPlayercroco(){
		
		PlayerPrefs.SetInt ("char2",1);
		//GameController.instance.players [index] = true;
		PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-300);
		CoinsManager.Coins -= 300;
	
		PlayerPrefs.SetFloat ("shieldTime", PlayerPrefs.GetFloat ("shieldTime") + 5f);
		PlayerPrefs.SetFloat ("iceTime", PlayerPrefs.GetFloat ("iceTime") + 5f);

		priceTags[1].gameObject.SetActive(false);

		GameController.instance.Save(); 
		InitializePlayerMenuController();

		buypanelcroco.SetActive(false);
	}

	public void BuyPlayertiger(){

		PlayerPrefs.SetInt ("char3",1);
		//GameController.instance.players [index] = true;
		PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-400);
		CoinsManager.Coins -= 400;
	
		PlayerPrefs.SetFloat ("shieldTime", PlayerPrefs.GetFloat ("shieldTime") + 7f);
		PlayerPrefs.SetFloat ("iceTime", PlayerPrefs.GetFloat ("iceTime") + 7f);

		priceTags[2].gameObject.SetActive(false);

		GameController.instance.Save(); 
		InitializePlayerMenuController();

		buypaneltiger.SetActive(false);
	}

	public void BuyPlayerpirate(){
		
		PlayerPrefs.SetInt ("char4",1);

		PlayerPrefs.SetInt("Coins",PlayerPrefs.GetInt("Coins")-500);
		CoinsManager.Coins -= 500;
	
		PlayerPrefs.SetFloat ("shieldTime", PlayerPrefs.GetFloat ("shieldTime") + 9f);
		PlayerPrefs.SetFloat ("iceTime", PlayerPrefs.GetFloat ("iceTime") + 9f);

		priceTags[3].gameObject.SetActive(false);

		GameController.instance.Save(); 
		InitializePlayerMenuController();

		buypanelpirate.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {


	}







	public void DontBuyPlayer(){
		buypanelkid.SetActive(false);
		buypanelcroco.SetActive(false);
		buypaneltiger.SetActive(false);
		buypanelpirate.SetActive(false);
	}


	public void back(){
		notEnoughPanel.SetActive(false);
	}


	public void CharacterPanel(){
		powerUpsPanel.SetActive(false);
		characterPanel.SetActive(true);


	}

	public void PowerupsPanel(){
		characterPanel.SetActive(false);
		powerUpsPanel.SetActive(true);

	}

}
