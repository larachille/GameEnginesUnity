using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndgameTrigger : MonoBehaviour {
	
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
		if (other.gameObject.name == "Ball") {
			controller.newStart = true;
			controller.stopSlider = false;
			controller.lifes = controller.lifes - 1;
		}
	}
}
