using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	GameObject controllerObj;
	Controller controller;

	// Use this for initialization
	void Start () {
		controllerObj = GameObject.Find ("GameController");
		controller = controllerObj.GetComponent<Controller> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up);
	}

	void OnTriggerEnter(Collider other){
		controller.score += 100;
		gameObject.SetActive (false);
	}
}
