using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;



public class StartSceneScript : MonoBehaviour {

	public GameObject pointer;
	public GameObject circle;
	public GameObject logo;
	public GameObject playLogo;
	public GameObject startButton;

	// Use this for initialization
	void Start () {
		Invoke ("CircleStart", 1f);
	}
	void CircleStart(){
		circle.transform.DOScaleX (1f, 1.5f).SetEase(Ease.OutElastic);
		circle.transform.DOScaleY (1f, 1.5f).SetEase(Ease.OutElastic);
		Invoke ("PointerStart",0f);
	}
	void PointerStart(){
		pointer.transform.DORotate (new Vector3 (0, 0, 360), 2f, RotateMode.FastBeyond360).SetEase(Ease.OutQuart);
		pointer.transform.DOScaleX (1f, 2f);
		pointer.transform.DOScaleY (1f, 2f);
		Invoke ("CircleMoveOut", 2f);
	}
	void CircleMoveOut(){
		circle.transform.DOMove (new Vector3 (5, 4, 0), 2f, false).SetEase(Ease.InQuart);
		logo.transform.DOMove (new Vector3 (-3.79f, 4.31f, 0), 2f, false).SetEase(Ease.InQuart);
		Invoke ("ButtonFadeIn", 2f);
	}
	void ButtonFadeIn(){
		playLogo.GetComponent<SpriteRenderer> ().DOFade (1f, 1.5f).SetEase(Ease.OutQuart);
		startButton.GetComponent<SpriteRenderer> ().DOFade (1f, 1.5f).SetEase(Ease.OutElastic);
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

	}
}
