using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class PointerMovementScript : MonoBehaviour {

	public GameObject pointer;
	public GameObject centerP;
	public Rigidbody ball;
	public GameTempoScript GameTempoScript;
	public GameObject innerPointer;
	public GameObject outerPointer;
	float timer1 = 0f;
	float timer2 = 0f;
	private int innerPointerCounter = 1;
	private int outerPointerCounter = 2;

	void Start () {
	
	}

	void Update () {	
		timer1 += Time.deltaTime;
		timer2 += Time.deltaTime;
		if (GameTempoScript.start) {
			if (timer1 > GameTempoScript.secPerRound / 8) {
				innerPointer.transform.GetChild ((innerPointerCounter - 1) % 8).gameObject.SetActive (false);
				innerPointer.transform.GetChild (innerPointerCounter % 8).gameObject.SetActive (true);
				innerPointerCounter += 1;
				timer1 = 0f;
			}
			if (timer2 > GameTempoScript.secPerRound / 16) {
				outerPointer.transform.GetChild ((outerPointerCounter - 1) % 16).gameObject.SetActive (false);
				outerPointer.transform.GetChild (outerPointerCounter % 16).gameObject.SetActive (true);
				outerPointerCounter += 1;
				timer2 = 0f;
			}
		}
	}

//	void OnTriggerEnter(Collider other){
//		Debug.Log (other.gameObject.name);
//		if (other.gameObject.name != "Sphere(Clone)") {
//			Rigidbody instantiatedProjectile = Instantiate (ball,
//				                                  other.gameObject.transform.position,
//												  other.gameObject.transform.rotation)
//			as Rigidbody;
//			instantiatedProjectile.velocity =  new Vector3 (other.gameObject.transform.position.x/4, other.gameObject.transform.position.y/4, 0);
//		}
//
//	}
}
