using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Setup : MonoBehaviour {
	public float smallCircleRadius;
	public float bigCircleRadius;
	public GameObject smallCircle;
	public GameObject bigCircle;
	public GameObject pointer;
	public List<GameObject> turretEightPointList = new List<GameObject>();
	public List<GameObject> enemyEightPointList = new List<GameObject>();
	void Start(){
		smallCircle.transform.localScale = new Vector3 (2*smallCircleRadius / smallCircle.GetComponent<Renderer> ().bounds.size.x, 2*smallCircleRadius / smallCircle.GetComponent<Renderer> ().bounds.size.y, 0);
		bigCircle.transform.localScale = new Vector3 (2*bigCircleRadius / bigCircle.GetComponent<Renderer> ().bounds.size.x, 2*bigCircleRadius / bigCircle.GetComponent<Renderer> ().bounds.size.y, 0);
		pointer.transform.localScale = new Vector3 (0.5f, smallCircleRadius / pointer.GetComponent<Renderer> ().bounds.size.y, 0);
		for (int i = 0; i < turretEightPointList.Count; i++) {
			turretEightPointList [i].transform.position = new Vector3 (smallCircleRadius * Mathf.Cos (i * (2 * Mathf.PI / turretEightPointList.Count)), smallCircleRadius * Mathf.Sin (i * (2 * Mathf.PI / turretEightPointList.Count)), -1);
			turretEightPointList [i].transform.Rotate (new Vector3 (0, 0, 90 + 45 * i ));
		} for (int i = 0; i < enemyEightPointList.Count; i++) {
			enemyEightPointList [i].transform.position = new Vector3 (bigCircleRadius * Mathf.Cos (i * (2 * Mathf.PI / enemyEightPointList.Count)), bigCircleRadius * Mathf.Sin (i * (2 * Mathf.PI / enemyEightPointList.Count)), -1);
		}
	}
	void Update(){
		
	}
}
