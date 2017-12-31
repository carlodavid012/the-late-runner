using UnityEngine;
using System.Collections;

public class ProfSpeed : MonoBehaviour {

	private float speed = 2.5f;

	private Rigidbody2D myBody;



	void Awake(){
		myBody = GetComponent<Rigidbody2D> ();
	}

	void Update () {
		myBody.velocity = new Vector2 (speed, 0);

	

	}
	void Start ()
	{

		StartCoroutine(stop());
	}



	IEnumerator stop (){
		yield return new WaitForSeconds(4f);
		speed = 0;
		StartCoroutine(back1());
	}



	IEnumerator back1(){
		yield return new WaitForSeconds(15f);
		speed = -3f;
		StartCoroutine(stop2());

	}

	IEnumerator stop2 ()
	{
		yield return new WaitForSeconds(2f);
		speed = 0;
		StartCoroutine(back2());
	}

	IEnumerator back2(){
		yield return new WaitForSeconds(5f);
		speed = 3f;
		StartCoroutine(stop3());

	}

	IEnumerator stop3()
	{
		yield return new WaitForSeconds(2f);
		speed = 0;
		StartCoroutine(back3());
	}

	IEnumerator back3(){
		yield return new WaitForSeconds(10f);
		speed = -3f;
		StartCoroutine(stop4());

	}

	IEnumerator stop4(){

		yield return new WaitForSeconds(2.5f);
		speed = 0;
		StartCoroutine(back4());
	}

	IEnumerator back4(){
		yield return new WaitForSeconds(7f);
		speed = 3f;
		StartCoroutine(stop5());

	}

	IEnumerator stop5(){

		yield return new WaitForSeconds(3f);
		speed = 0;
		StartCoroutine(back5());
	}

	IEnumerator back5(){
		yield return new WaitForSeconds(10f);
		speed = -3f;
		StartCoroutine(stop6());

	}
	IEnumerator stop6(){

		yield return new WaitForSeconds(2.5f);
		speed = 0;
		StartCoroutine(back6());

	}
	IEnumerator back6(){
		yield return new WaitForSeconds(10f);
		speed = 3f;
		StartCoroutine(stop7());

	}

	IEnumerator stop7(){

		yield return new WaitForSeconds(2f);
		speed = 0;
		StartCoroutine(back7());
	}

	IEnumerator back7(){
		yield return new WaitForSeconds(10f);
		speed = -3f;
		StartCoroutine(stop8());

	}

	IEnumerator stop8(){

		yield return new WaitForSeconds(2.5f);
		speed = 0;
		StartCoroutine(back8());
	}

	IEnumerator back8(){
		yield return new WaitForSeconds(10f);
		speed = 3f;
		StartCoroutine(stop9());

	}

	IEnumerator stop9(){

		yield return new WaitForSeconds(2.5f);
		speed = 0;
		StartCoroutine(back9());

	}

	IEnumerator back9(){
		yield return new WaitForSeconds(10f);
		speed = -3f;
		StartCoroutine(stop10());

	}
	IEnumerator stop10(){

		yield return new WaitForSeconds(2.5f);
		speed = 0;


	}

}
