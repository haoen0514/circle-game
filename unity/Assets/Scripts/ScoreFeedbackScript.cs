using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreFeedbackScript : MonoBehaviour {

	public int value;
	private float finalX = Screen.width / 2;
	private float finalY = Screen.height / 2 + 30.0f;
	// Use this for initialization
	void Start () {
		if (value > 0) {
			this.GetComponent<Text>().text = "+" + value.ToString ();
		} else {
			this.GetComponent<Text>().text = value.ToString ();
		}
		this.transform.DOMove (new Vector3 (finalX, Screen.height / 2), 0f);
		this.transform.DOMove (new Vector3 (finalX, finalY), 2f);
		this.GetComponent<Text> ().CrossFadeAlpha (0.0f, 0.8f, true);
		Invoke ("Suicide", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Suicide() {
		Destroy (this.gameObject);
	}
}
