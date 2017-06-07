using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
		Debug.Log (bigCircle.GetComponent<Renderer> ().bounds.size);
		Debug.Log (smallCircle.GetComponent<Renderer> ().bounds.size);
		smallCircleRadius = smallCircle.GetComponent<Renderer> ().bounds.size.x / 2;
		bigCircleRadius = bigCircle.GetComponent<Renderer> ().bounds.size.x / 2;
//		smallCircle.transform.localScale = new Vector3 (2*smallCircleRadius / smallCircle.GetComponent<Renderer> ().bounds.size.x, 2*smallCircleRadius / smallCircle.GetComponent<Renderer> ().bounds.size.y, 0);
//		bigCircle.transform.localScale = new Vector3 (2*bigCircleRadius / bigCircle.GetComponent<Renderer> ().bounds.size.x, 2*bigCircleRadius / bigCircle.GetComponent<Renderer> ().bounds.size.y, 0);
//		pointer.transform.localScale = new Vector3 (3f, 2*smallCircleRadius / pointer.GetComponent<Renderer> ().bounds.size.y, 0);
//		for (int i = 0; i < turretEightPointList.Count; i++) {
//			turretEightPointList [i].transform.position = new Vector3 (smallCircleRadius * Mathf.Cos (i * (2 * Mathf.PI / turretEightPointList.Count)), smallCircleRadius * Mathf.Sin (i * (2 * Mathf.PI / turretEightPointList.Count)), -1);
//			turretEightPointList [i].transform.Rotate (new Vector3 (0, 0, 90 + 45 * i ));
//		} 
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
	void Update(){
	}
	public void ChangeBigCircleR(float radius){
		bigCircleRadius = radius;
	}
}
