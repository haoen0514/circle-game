using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScoreFeedbackScript : MonoBehaviour {

	private int value;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void ChangeValue(int v) {
		
		value = v;
		Debug.Log ("value:" + value);
		if (value > 0) {
			this.GetComponent<Text>().text = "+" + value.ToString ();
		} else {
			this.GetComponent<Text>().text = value.ToString ();
		}

		float posX = Screen.width / 2 + Random.Range (-60, 60);
		float posY = Screen.height / 2 + Random.Range (-50, 50);

		this.transform.DOMove (new Vector3 (posX, posY), 0f);
		this.transform.DOMove (new Vector3 (posX, posY + 30.0f), 2f);
		this.GetComponent<Text> ().CrossFadeAlpha (0.0f, 0.8f, true);
		Invoke ("Suicide", 2f);
	}

	void Suicide() {
		Destroy (this.gameObject);
	}
}
