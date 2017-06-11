using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
		circle.transform.DOScaleX (0.6f, 1.5f).SetEase(Ease.OutElastic);
		circle.transform.DOScaleY (0.6f, 1.5f).SetEase(Ease.OutElastic);
		Invoke ("PointerStart",0f);
	}
	void PointerStart(){
		pointer.transform.DORotate (new Vector3 (0, 0, 360), 2f, RotateMode.FastBeyond360).SetEase(Ease.OutQuart);
		pointer.transform.DOScaleX (1f, 2f);
		pointer.transform.DOScaleY (1f, 2f);
		Invoke ("CircleMoveOut", 2f);
	}
	void CircleMoveOut(){
//		circle.transform.DOMove (new Vector3 (0, 4, 0), 2f, false).SetEase(Ease.InQuart);
		circle.transform.DOMove (new Vector3 (0, 4, 0), 2f, false).SetEase(Ease.OutElastic);

		logo.transform.DOScaleX (0.7f, 3f).SetEase(Ease.OutElastic);
		logo.transform.DOScaleY (0.7f, 3f).SetEase(Ease.OutElastic);
//		logo.transform.DOMove (new Vector3 (0.0f, -0.52f, 0), 2f, false).SetEase(Ease.InQuart);

		playLogo.transform.DOScaleX (1f, 3f).SetEase(Ease.OutElastic);
		playLogo.transform.DOScaleY (1f, 3f).SetEase(Ease.OutElastic);

		startButton.transform.DOScaleX (0.8f, 3f).SetEase(Ease.OutElastic);
		startButton.transform.DOScaleY (0.8f, 3f).SetEase(Ease.OutElastic);


		Invoke ("ButtonFadeIn", 2f);
	}
	void ButtonFadeIn(){
//		playLogo.GetComponent<SpriteRenderer> ().DOFade (1f, 1.5f).SetEase(Ease.OutQuart);
//		startButton.GetComponent<SpriteRenderer> ().DOFade (1f, 1.5f).SetEase(Ease.OutElastic);
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
