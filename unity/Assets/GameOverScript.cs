using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;



public class GameOverScript : MonoBehaviour {

	public GameObject logo;
	public GameObject playLogo;
	public GameObject startButton;

	// Use this for initialization
	void Start () {
		Invoke ("CircleMoveOut", 0);
	}

	void CircleMoveOut(){
		logo.transform.DOScaleX (2.7f, 3f).SetEase(Ease.OutElastic);
		logo.transform.DOScaleY (2.7f, 3f).SetEase(Ease.OutElastic);

		playLogo.transform.DOScaleX (1f, 3f).SetEase(Ease.OutElastic);
		playLogo.transform.DOScaleY (1f, 3f).SetEase(Ease.OutElastic);

		startButton.transform.DOScaleX (1f, 3f).SetEase(Ease.OutElastic);
		startButton.transform.DOScaleY (1f, 3f).SetEase(Ease.OutElastic);
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touches.Length; i++) {
			if (Input.touches [i].phase == TouchPhase.Began) {
				TouchEvent (Input.touches [i].position);
			}
		}
	}

	void TouchEvent (Vector3 pos){
		if (pos.y < Screen.height / 3) {
			Debug.Log ("touch");
			SceneManager.LoadScene ("V2");
		}
	}
}
