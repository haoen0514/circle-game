using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class OpeningScript : MonoBehaviour {

	public GameObject backgroundCircle;
	public GameObject innerCircle;


	// Use this for initialization
	void Start () {
		backgroundCircle.transform.DOScaleX (1f, 3f);
		backgroundCircle.transform.DOScaleY (1f, 3f);
		Invoke ("innerCircleScale",3f);
	}


	void innerCircleScale(){
		Debug.Log ("wat");
		innerCircle.transform.DOScaleX (0.7f, 3f);
		innerCircle.transform.DOScaleY (0.7f, 3f);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
