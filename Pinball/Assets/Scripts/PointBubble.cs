using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBubble : MonoBehaviour {

	[SerializeField]
	int points;

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

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "Ball") {
			controller.score = controller.score + points;
		}
	}
}
