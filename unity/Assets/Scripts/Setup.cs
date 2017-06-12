using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
	public GameObject CountDownText;
	public GameTempoScript gameTempo;
	public GameObject Blood;
	public int bloodNum = 5;

	static public int score;
	public Text scoreNumber;
	public Canvas canvas;
	public ScoreFeedbackScript ScoreFeedback;

	int counter = 0;
	void Start(){
		score = 0;
		bigCircle.transform.DOScaleX (1.5f, 4f).SetEase(Ease.OutQuint);
		bigCircle.transform.DOScaleY (1.5f, 4f).SetEase(Ease.OutQuint);
		Invoke ("innerCircleScale",1f);
	}
	void Update(){

		CheckBloodNum ();

	}
	void CheckBloodNum(){
		for (int i = 0; i < 5 - bloodNum; i++) {
			if (Blood.transform.GetChild (i).gameObject.activeSelf) {
				Blood.transform.GetChild (i).gameObject.SetActive (false);
			}
		}
	
	}
	void innerCircleScale(){
		smallCircle.transform.DOScaleX (0.7f, 1f).SetEase(Ease.OutElastic);
		smallCircle.transform.DOScaleY (0.7f, 1f).SetEase(Ease.OutElastic);
		Invoke ("SetUpAllElement", 1f);
		Invoke ("CountDown", 1f);
	}
	void CountDown(){
		switch (counter) {
			case 0:
				Invoke("CountDown", 1f);
				CountDownText.transform.DOScaleX (1f, 1f).SetEase (1 - Ease.OutExpo);
				CountDownText.transform.DOScaleY (1f, 1f).SetEase (1 - Ease.OutExpo);
				CountDownText.GetComponent<SpriteRenderer> ().DOFade (1f, 0.5f).SetEase (1 - Ease.OutExpo);
				Invoke ("FadeOut", 0.5f);
				break;

			case 1:
				Invoke("CountDown", 1f);
				CountDownText.transform.GetChild(0).transform.DOScaleX (1f, 1f).SetEase (1 - Ease.OutExpo);
				CountDownText.transform.GetChild(0).transform.DOScaleY (1f, 1f).SetEase (1 - Ease.OutExpo);
				CountDownText.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().DOFade (1f, 0.5f).SetEase (1-Ease.OutExpo);
				Invoke ("FadeOut", 0.5f);
				break;

			case 2:
				Invoke ("CountDown", 2f);
				CountDownText.transform.GetChild (1).transform.DOScaleX (1f, 1f).SetEase (1 - Ease.OutExpo);
				CountDownText.transform.GetChild (1).transform.DOScaleY (1f, 1f).SetEase (1 - Ease.OutExpo);
				CountDownText.transform.GetChild (1).gameObject.GetComponent<SpriteRenderer> ().DOFade (1f, 0.5f).SetEase (1 - Ease.OutExpo);
				Invoke ("FadeOut", 0.5f);
				break;
					
			case 3:
				CountDownText.SetActive (false);
				gameTempo.start = true;
				Blood.SetActive (true);
				counter = 0;
				break;
		}
	}
	void FadeOut(){
		switch (counter) {
			case 0:
				CountDownText.GetComponent<SpriteRenderer> ().DOFade (0f, 0.5f).SetEase (1 - Ease.OutExpo);
				counter++;
				break;

			case 1:
				CountDownText.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer> ().DOFade (0f, 0.5f).SetEase (1-Ease.OutExpo);
				counter++;
				break;

			case 2:
				CountDownText.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer> ().DOFade (0f, 0.5f).SetEase (1-Ease.OutExpo);
				counter++;
				break;

			case 3:
				break;
		}
		
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


	public void AddScore(int value) {
		score += value;
		scoreNumber.text = score.ToString ();

		ScoreFeedbackScript sf = Instantiate (ScoreFeedback, canvas.transform);
		sf.value = value;
	}
}
