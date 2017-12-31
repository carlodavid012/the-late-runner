using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstacleSpawner : MonoBehaviour {

	public static ObstacleSpawner instance;

	public GameObject[] obstacles;

	public GameObject spawner;

	public GameObject obj;

	float x;
	float y;


	public static float spawnMin = 0.9f;
	public static float spawnMax = 1.2f;

	private List<GameObject> obstaclesForSpawning = new List<GameObject>();

	void Awake(){
		InitialiseObstacles ();
	}

	void Start(){
		StartCoroutine (SpawnRandomObstacle ());
	}

	void InitialiseObstacles(){
		int index = 0;
		for(int i = 0; i < obstacles.Length * 3; i++){
			obj = Instantiate (obstacles [index],transform.position, Quaternion.identity) as GameObject;
			obstaclesForSpawning.Add (obj);
			obstaclesForSpawning [i].SetActive (false);

			index++;
			if(index == obstacles.Length){
				index = 0;
			}
		}
	}

	void Shuffle(){
		for(int i = 0; i < obstaclesForSpawning.Count; i++){
			GameObject temp = obstaclesForSpawning [i];
			int random = Random.Range (i, obstaclesForSpawning.Count);
			obstaclesForSpawning [i] = obstaclesForSpawning [random];
			obstaclesForSpawning [random] = temp;
		}
	}

	IEnumerator SpawnRandomObstacle(){

		float x = 10.33f;
	float y = Random.Range(-4.08f,-0.43f);
		yield return new WaitForSeconds (Random.Range (spawnMin, spawnMax));

		Vector3 pos = new Vector3(x,y,-2);
		spawner.transform.position = pos;

		int index = Random.Range (0, obstaclesForSpawning.Count);
		while(true){
			if(!obstaclesForSpawning[index].activeInHierarchy){
				obstaclesForSpawning [index].SetActive (true);
				obstaclesForSpawning [index].transform.position = transform.position;
				break;
			} else {
				index = Random.Range (0, obstaclesForSpawning.Count);
			}
		}

		StartCoroutine (SpawnRandomObstacle ());
	}

	void CreateInstance(){
		if(instance==null){
			instance = this;
		}
	}
}
