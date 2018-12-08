using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperRight : MonoBehaviour {

	Quaternion origRotation; 
	Quaternion flipRotation;

	// Use this for initialization
	void Start () {
		origRotation = transform.rotation;
		flipRotation = Quaternion.Euler (0f, 36.5f, 0f);
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("d")){
			transform.rotation = flipRotation;
		}
		if (Input.GetKeyUp("d")) {
			transform.rotation = origRotation;
		}
	}
}
