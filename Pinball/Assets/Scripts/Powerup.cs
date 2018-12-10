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

	Vector3 zeroPos;

	public int type;

	public GameObject ball;

	// Use this for initialization
	void Start () {
		movesUp = true;
		currentUp = 0;
		zeroPos = transform.position;
		controllerObj = GameObject.Find ("GameController");
		controller = controllerObj.GetComponent<Controller> ();
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
			break;
		case 3:
			break;
		case 4:
			break;
		}
	
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
