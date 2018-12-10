using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

	[SerializeField]
	GameObject controllerObj;

	HoleController controller;

	// Use this for initialization
	void Start () {
		controller = controllerObj.GetComponent<HoleController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		controller.Transport (other.gameObject, this.gameObject);
	}
}
