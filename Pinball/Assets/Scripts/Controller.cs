using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour {

	[SerializeField]
	Slider slider;

	[SerializeField]
	GameObject ball;

	[SerializeField]
	GameObject ballPrefab;

	[SerializeField]
	GameObject giftBox;

	[SerializeField]
	Text scoreObj;

	[SerializeField]
	Text lifeObj;

	[SerializeField]
	Material giftBalls;

	[SerializeField]
	Material giftPoints;

	[SerializeField]
	Material giftBarrier;

	[SerializeField]
	Material giftCoins;

	[SerializeField]
	Text gameOver;

	[SerializeField]
	GameObject barrier1;

	[SerializeField]
	GameObject barrier2;

	Ball ballscript;

	public bool newStart;
	bool goDown;
	public bool stopSlider;
	float sliderMin;
	float sliderMax;
	float speed;

	public int score;
	public int lifes;

	Vector3 startPos;

	Vector3[] giftPositions;

	GameObject gift1Obj;
	GameObject gift2Obj;

	Powerup gift1;
	Powerup gift2;

	Material[] materials;

	// Use this for initialization
	void Start () {
		newStart = true;
		goDown = false;
		stopSlider = false;
		sliderMax = slider.maxValue;
		sliderMin = slider.minValue;
		speed = sliderMin;
		ballscript = ball.GetComponent<Ball> ();
		score = 0;
		lifes = 5;
		startPos = new Vector3 (5.4f, 0, -4.29f);
		giftPositions = new Vector3[5];
		MaterialSetup ();
		GiftSetup ();
	}

	void MaterialSetup(){
		materials = new Material[4];
		materials [0] = giftBalls;
		materials [1] = giftPoints;
		materials [2] = giftBarrier;
		materials [3] = giftCoins;
	}

	void GiftSetup(){
		Vector3 pos1 = new Vector3 (-3.873999f, 0.54f, 1.58f);
		Vector3 pos2 = new Vector3 (0.15f, 0.54f, 2.67f);
		Vector3 pos3 = new Vector3 (0.03f, 0.54f, -5.75f);
		Vector3 pos4 = new Vector3 (-2.01f, 0.54f, -4.75f);
		Vector3 pos5 = new Vector3 (1.89f, 0.54f, -4.75f);
		giftPositions [0] = pos1;
		giftPositions [1] = pos2;
		giftPositions [2] = pos3;
		giftPositions [3] = pos4;
		giftPositions [4] = pos5;

		int index1 = UnityEngine.Random.Range (0, 5);
		int index2 = UnityEngine.Random.Range (0, 5);

		while (index1 == index2) {
			index2 = UnityEngine.Random.Range (0, 5);
		}

		gift1Obj = Instantiate (giftBox, giftPositions [index1], Quaternion.identity);
		gift2Obj = Instantiate (giftBox, giftPositions [index2], Quaternion.identity);

		int type1 = UnityEngine.Random.Range (1, 5);
		int type2 = UnityEngine.Random.Range (1, 5);

		gift1 = gift1Obj.GetComponent<Powerup> ();
		gift2 = gift2Obj.GetComponent<Powerup> ();

		gift1.type = type1;
		gift2.type = type2;

		gift1.materials = materials;
		gift2.materials = materials;

		gift1.SetMaterial ();
		gift2.SetMaterial ();

		gift1.barrier1 = barrier1;
		gift1.barrier2 = barrier2;
		gift2.barrier1 = barrier1;
		gift2.barrier2 = barrier2;
	}
	
	// Update is called once per frame
	void Update () {
		if (newStart && lifes >= 0) {

			lifeObj.text = "Lifes: " + lifes;

			if (ball.transform.position != startPos) {
				ball.transform.position = startPos;
			}

			if (Input.GetKeyDown ("space")) {
				stopSlider = true;
				ballscript.movesUp = true;
				ballscript.Launch (speed);
				newStart = false;
			} else {
				if (!stopSlider) {
					if (goDown) {
						speed = speed - 1f;
					} else {
						speed = speed + 1f;
					}

					if (speed > sliderMax) {
						speed = sliderMax;
						goDown = true;
					}
					if (speed < sliderMin) {
						speed = sliderMin;
						goDown = false;
					}

					slider.value = speed;
				}
			}
		}
		if (lifes == 0) {
			gameOver.gameObject.SetActive (true);
			stopSlider = true;
			Destroy (gift1Obj);
			Destroy (gift2Obj);
			if (Input.GetKeyDown ("n")) {
				newStart = true;
				goDown = false;
				stopSlider = false;
				score = 0;
				lifes = 5;
				GiftSetup ();
				gameOver.gameObject.SetActive (false);
			}
		}
		scoreObj.text = "Score: " + score;
	}

	public void DestroyGift(GameObject requestObj){

		int giftNmbr = 0;

		if (requestObj == gift1Obj) {
			giftNmbr = 1;
		} else {
			giftNmbr = 2;
		}

		requestObj.SetActive(false);

		StartCoroutine (WaitForGifts(giftNmbr,requestObj));
	}

	IEnumerator WaitForGifts(int giftNmbr,GameObject toDestroy){
		yield return new WaitForSeconds (5);
		MakeNewGift (giftNmbr);
		Destroy (toDestroy);
	}

	void MakeNewGift(int giftNmbr){
		int index = UnityEngine.Random.Range (0, 5);

		while (giftPositions[index] == gift1.zeroPos || giftPositions[index] == gift2.zeroPos) {
			index = UnityEngine.Random.Range (0, 5);
		}

		if (giftNmbr == 1) {
			gift1Obj = Instantiate (giftBox, giftPositions[index], Quaternion.identity);
			int type1 = UnityEngine.Random.Range (1, 5);
			gift1 = gift1Obj.GetComponent<Powerup> ();
			gift1.type = type1;
			gift1.materials = materials;
			gift1.SetMaterial ();
			gift1.barrier1 = barrier1;
			gift1.barrier2 = barrier2;
		}
		if (giftNmbr == 2) {
			gift2Obj = Instantiate (giftBox, giftPositions[index], Quaternion.identity);
			int type2 = UnityEngine.Random.Range (1, 5);
			gift2 = gift2Obj.GetComponent<Powerup> ();
			gift2.type = type2;
			gift2.materials = materials;
			gift2.SetMaterial ();
			gift2.barrier1 = barrier1;
			gift2.barrier2 = barrier2;
		}

	}

	public void Barriers(){
		StartCoroutine (RemoveBarriers());
	}

	IEnumerator RemoveBarriers(){
		barrier1.SetActive (true);
		barrier2.SetActive (true);

		yield return new WaitForSeconds (5);

		barrier1.SetActive (false);
		barrier2.SetActive (false);
	}

}
