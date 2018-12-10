using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour {

	[SerializeField]
	GameObject hole1;

	[SerializeField]
	GameObject hole2;

	[SerializeField]
	GameObject hole3;

	[SerializeField]
	GameObject hole4;

	GameObject[] holes;

	bool comesFromTransport;

	// Use this for initialization
	void Start () {
		holes = new GameObject[4];
		holes[0] = hole1;
		holes[1] = hole2;
		holes[2] = hole3;
		holes[3] = hole4;
		comesFromTransport = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Transport(GameObject ball, GameObject hole){
		if (!comesFromTransport) {

			int i = 0;
			foreach (GameObject h in holes) {
				if (h == hole) {
					break;
				}
				i += 1;
			}

			int index = i; 

			while (index == i) {
				index = UnityEngine.Random.Range (0, 4);
			}
				
			GameObject selectedHole = holes [index];

			Vector3 position = selectedHole.transform.position;

			ball.transform.position = position;

			comesFromTransport = true;

			StartCoroutine ("AwaitTransport");
		}
	}

	IEnumerator AwaitTransport(){
		yield return new WaitForSeconds (2);
		comesFromTransport = false;
	}
}
