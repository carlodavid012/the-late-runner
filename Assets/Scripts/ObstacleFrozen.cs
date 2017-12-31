using UnityEngine;
using System.Collections;

public class ObstacleFrozen : MonoBehaviour {
	public static ObstacleFrozen instance;
	public GameObject Ice;
	public GameObject freeze;

	void Awake(){
		CreateInstance();

	}

	void Start(){
		
	}






	void CreateInstance(){
		if(instance==null){
			instance = this;
		}
	}

}
