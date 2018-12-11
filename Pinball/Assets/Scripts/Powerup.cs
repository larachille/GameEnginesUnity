using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {

	bool movesUp;

	[SerializeField]
	float maxUpDown;

	[SerializeField]
	float smooth;

	GameObject controllerObj;

	Controller controller;

	float currentUp;

	public Vector3 zeroPos;

	public int type;

	public GameObject ball;
	GameObject barriers;

	GameObject coins;

	public Material[] materials;

	Renderer rend;

	public GameObject barrier1;
	public GameObject barrier2;

	// Use this for initialization
	void Start () {
		movesUp = true;
		currentUp = 0;
		zeroPos = transform.position;
		controllerObj = GameObject.Find ("GameController");
		controller = controllerObj.GetComponent<Controller> ();
		barriers = GameObject.Find ("Barriers");
		coins = GameObject.Find ("Coins");
	}
	
	// Update is called once per frame
	void Update () {
		if (movesUp) {
			currentUp = currentUp + smooth;
		} else {
			currentUp = currentUp - smooth;
		}

		if (currentUp > maxUpDown) {
			currentUp = maxUpDown;
			movesUp = false;
		}
		if (currentUp < 0) {
			currentUp = 0;
			movesUp = true;
		}

		transform.position = new Vector3 (zeroPos.x, zeroPos.y + currentUp, zeroPos.z);

	}

	void OnTriggerEnter(Collider other){
		UsePowerUp ();
		controller.DestroyGift (this.gameObject);
	}

	void UsePowerUp(){
	
		switch (type) {
		case 1:
			SpawnBalls ();
			break;
		case 2:
			ScoreExplosion ();
			break;
		case 3:
			Barriers ();
			break;
		case 4:
			Coins ();
			break;
		}
	}

	public void SetMaterial(){
		rend = GetComponent<Renderer> ();
		if(rend != null){
			rend.material = materials [type - 1];
		}
	}

	void Coins(){
		foreach(Transform child in coins.transform){
			child.gameObject.SetActive (true);
		}
	}

	void Barriers(){
		//StartCoroutine (RemoveBarriers());
		controller.Barriers();
	}

	IEnumerator RemoveBarriers(){
		/**foreach (Transform child in barriers.transform) {
			child.gameObject.SetActive (true);
		}
		yield return new WaitForSeconds (2f);
		foreach (Transform child in barriers.transform) {
			child.gameObject.SetActive (false);
		}

		barrier1.SetActive (true);
		barrier2.SetActive (true);

		yield return new WaitForSeconds (5);

		barrier1.SetActive (false);
		barrier2.SetActive (false);**/
		yield return new WaitForSeconds (2f);
	}

	void ScoreExplosion(){
		controller.score += 25000;
	}

	void SpawnBalls (){
		Instantiate (ball, new Vector3 (-3.4f,0.14f,8.209204f), Quaternion.identity);
		Instantiate (ball, new Vector3 (-2.53f,0.14f,8.209204f), Quaternion.identity);
		Instantiate (ball, new Vector3 (-1.48f,0.14f,8.209204f), Quaternion.identity);
		Instantiate (ball, new Vector3 (-0.49f,0.14f,8.209204f), Quaternion.identity);
		Instantiate (ball, new Vector3 (0.43f,0.14f,8.209204f), Quaternion.identity);
		Instantiate (ball, new Vector3 (1.48f,0.14f,8.209204f), Quaternion.identity);
		Instantiate (ball, new Vector3 (2.53f,0.14f,8.209204f), Quaternion.identity);
		Instantiate (ball, new Vector3 (3.51f,0.14f,8.209204f), Quaternion.identity);
	}
}
