using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class PointerMovementScript : MonoBehaviour {

	public GameObject pointer;
	public GameObject centerP;
	public Rigidbody ball;
	public GameTempoScript GameTempoScript;

	void Start () {
	
	}

	void Update () {	
		if (GameTempoScript.start) {
			float degPerSec = 360f / GameTempoScript.secPerRound;
			pointer.transform.Rotate (Vector3.forward * degPerSec * Time.deltaTime);
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
