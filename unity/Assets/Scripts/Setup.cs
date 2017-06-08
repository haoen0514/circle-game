using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class Setup : MonoBehaviour {
	public float smallCircleRadius;
	public float bigCircleRadius;
	public GameObject eightFirePoint;
	public GameObject sixteenFirePoint;
	public GameObject outerTurret;
	public GameObject innerTurret;
	public GameObject smallCircle;
	public GameObject bigCircle;
//	public GameObject pointer;
//	public List<GameObject> turretEightPointList = new List<GameObject>();
	public GameObject enemyEightPointList;
	public GameObject enemySixteenPointList;
	void Start(){
		bigCircle.transform.DOScaleX (1f, 3f).SetEase(Ease.InQuint);
		bigCircle.transform.DOScaleY (1f, 3f).SetEase(Ease.InQuint);
		Invoke ("innerCircleScale",3f);
	}
	void Update(){
	}
	void innerCircleScale(){
		smallCircle.transform.DOScaleX (0.7f, 3f).SetEase(Ease.InQuint);
		smallCircle.transform.DOScaleY (0.7f, 3f).SetEase(Ease.InQuint);
		Invoke ("SetUpAllElement", 3f);
	}
	void SetUpAllElement(){
		smallCircleRadius = smallCircle.GetComponent<Renderer> ().bounds.size.x / 2;
		bigCircleRadius = bigCircle.GetComponent<Renderer> ().bounds.size.x / 2;
		for (int i = 0; i < 8; i++) {
			eightFirePoint.transform.GetChild(i).transform.position = new Vector3 (smallCircleRadius * Mathf.Cos (i * (2 * Mathf.PI / 8) + Mathf.PI / 8), smallCircleRadius * Mathf.Sin (i * (2 * Mathf.PI / 8) + Mathf.PI / 8), -1);
		}
		for (int i = 0; i < 16; i++) {
			sixteenFirePoint.transform.GetChild (i).transform.position = new Vector3 (smallCircleRadius * Mathf.Cos (i * (2 * Mathf.PI / 16) + Mathf.PI / 16), smallCircleRadius * Mathf.Sin (i * (2 * Mathf.PI / 16) + Mathf.PI / 16), -1);
		}
		for (int i = 0; i < 8; i++) {
			enemyEightPointList.transform.GetChild(i).transform.position = new Vector3 (bigCircleRadius * Mathf.Cos (i * (2 * Mathf.PI / 8) + Mathf.PI / 8), bigCircleRadius * Mathf.Sin (i * (2 * Mathf.PI / 8) + Mathf.PI / 8), -1);
		}
		for (int i = 0; i < 16; i++) {
			enemySixteenPointList.transform.GetChild (i).transform.position = new Vector3 (bigCircleRadius * Mathf.Cos (i * (2 * Mathf.PI / 16) + Mathf.PI / 16), bigCircleRadius * Mathf.Sin (i * (2 * Mathf.PI / 16) + Mathf.PI / 16), -1);
		}
	}
	public void ChangeBigCircleR(float radius){
		bigCircleRadius = radius;
	}
}
