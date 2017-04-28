using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;


public class PointerMovementScript : MonoBehaviour {

	public float bpm = 30f;
	public GameObject pointer;
	public GameObject centerP;
	public Rigidbody ball;

	void Start () {
	
	}

	void Update () {
	    float toDegree = 360f / bpm;
		pointer.transform.Rotate (Vector3.forward * toDegree);
	}

	void OnTriggerEnter(Collider other){
//		Debug.Log (other.gameObject.name);
//		if (other.gameObject.name != "Sphere(Clone)") {
//			Rigidbody instantiatedProjectile = Instantiate (ball,
//				                                  other.gameObject.transform.position,
//												  other.gameObject.transform.rotation)
//			as Rigidbody;
//			instantiatedProjectile.velocity =  new Vector3 (other.gameObject.transform.position.x/4, other.gameObject.transform.position.y/4, 0);
//		}

	}
}
