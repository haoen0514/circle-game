using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using DG.Tweening;

public class PointerMovementScript : MonoBehaviour {

//	public GameObject pointer;
//	public GameObject centerP;
//	public Rigidbody ball;
	public GameTempoScript GameTempoScript;
	public GameObject innerPointer;
	public GameObject outerPointer;
	public GameObject outerTurret;
	public GameObject innerTurret;
	public GameObject eightFirePoint;
	public GameObject sixteenFirePoint;
	public bool spawn = false;
	float timer = 0f;
	private int innerPointerCounter = 1;
	private int outerPointerCounter = 1;
	private int counter = 0;
	void Start () {
//		innerTurret.transform.GetChild (6).gameObject.SetActive (true);
//		innerTurret.transform.GetChild (6).gameObject.GetComponent<SpriteRenderer> ().DOFade (0, GameTempoScript.secPerRound).SetEase (Ease.OutElastic);
//		FadeIn (innerTurret.transform.GetChild (6).gameObject.GetComponent<SpriteRenderer> (), 1);
	}

	void FixedUpdate () {	
		timer += Time.deltaTime;
		if (timer >= GameTempoScript.secPerRound / 16) {
			if (GameTempoScript.start) {
				counter++;
				if (counter == 2) {
					if (innerTurret.transform.GetChild (innerPointerCounter % 8).gameObject.activeSelf) {
						eightFirePoint.transform.GetChild (innerPointerCounter % 8).gameObject.GetComponent<TurretScript> ().Shoot (innerPointerCounter % 8, 0);
					}
					FadeOut (innerPointer.transform.GetChild ((innerPointerCounter - 1) % 8).gameObject.GetComponent<SpriteRenderer> (), 2);
					innerPointer.transform.GetChild ((innerPointerCounter - 1) % 8).gameObject.SetActive (false);
					innerPointer.transform.GetChild (innerPointerCounter % 8).gameObject.SetActive (true);
					FadeIn (innerPointer.transform.GetChild (innerPointerCounter % 8).gameObject.GetComponent<SpriteRenderer> (), 2);
					innerPointerCounter += 1;
					counter = 0;
				}
				if (outerTurret.transform.GetChild (outerPointerCounter % 16).gameObject.activeSelf) {
					sixteenFirePoint.transform.GetChild (outerPointerCounter % 16).gameObject.GetComponent<TurretScript> ().Shoot (outerPointerCounter % 16, 1);
				}
				FadeOut (outerPointer.transform.GetChild ((outerPointerCounter - 1) % 16).gameObject.GetComponent<SpriteRenderer> (), 16);
				outerPointer.transform.GetChild ((outerPointerCounter - 1) % 16).gameObject.SetActive (false);
				outerPointer.transform.GetChild (outerPointerCounter % 16).gameObject.SetActive (true);
				FadeIn (outerPointer.transform.GetChild (outerPointerCounter % 16).gameObject.GetComponent<SpriteRenderer> (), 16);
				outerPointerCounter += 1;
				timer = 0f;
				if (outerPointerCounter % 16 == 1) {
					spawn = true;
				}
			}
//			if (outerPointerCounter % 16 == 2) {
//				for (int i = 0; i < 8; i++) {
//					innerTurret.transform.GetChild (i).gameObject.SetActive (false);
//				}
//				for (int i = 0; i < 16; i++) {
//					outerTurret.transform.GetChild (i).gameObject.SetActive (false);
//				}
//				timer1 = 0f;
//			}
		}
	}
	void FadeIn(SpriteRenderer item, int num){
		item.DOFade (1, GameTempoScript.secPerRound / num).SetEase (Ease.OutElastic);
	}
	void FadeOut(SpriteRenderer item, int num){
		item.DOFade (0, GameTempoScript.secPerRound / num).SetEase (Ease.OutElastic);
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
