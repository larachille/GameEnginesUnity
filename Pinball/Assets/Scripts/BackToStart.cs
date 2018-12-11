﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToStart : MonoBehaviour {

	[SerializeField]
	GameObject controllerObj;

	Controller controller;

	// Use this for initialization
	void Start () {
		controller = controllerObj.GetComponent<Controller> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){

		Ball ball = other.GetComponent<Ball> ();

		if (!ball.movesUp) {
			if (other.gameObject.layer == LayerMask.NameToLayer ("Ball")) {
				controller.newStart = true;
				controller.stopSlider = false;
				controller.lifes = controller.lifes - 1;
			}
			if (other.gameObject.layer == LayerMask.NameToLayer ("ExtraBall")) {
				Destroy (other.gameObject);
			}
		}
	}
}
