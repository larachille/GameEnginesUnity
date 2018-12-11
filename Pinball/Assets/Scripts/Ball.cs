using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	Rigidbody rb;

	public bool movesUp;

	float lastZ;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		lastZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		float currentZ = transform.position.z;

		if (currentZ <= lastZ) {
			movesUp = false;
		}
		if (currentZ > lastZ) {
			movesUp = true;
		}

		lastZ = currentZ;
	}

	public void Launch(float speed){
		rb.AddForce (0,0,speed, ForceMode.Impulse);
	} 
}
