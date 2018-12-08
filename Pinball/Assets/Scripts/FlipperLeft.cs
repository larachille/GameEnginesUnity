using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperLeft : MonoBehaviour {

	Quaternion origRotation; 
	Quaternion flipRotation;

	// Use this for initialization
	void Start () {
		origRotation = transform.rotation;
		flipRotation = Quaternion.Euler (0f, -36.5f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("a")){
			transform.rotation = flipRotation;
		}
		if (Input.GetKeyUp("a")) {
			transform.rotation = origRotation;
		}
	}
}
