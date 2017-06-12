using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hintscript : MonoBehaviour {
	
	public float senseRadius;
	public GameObject[] HintInnerTurrets;
	public GameObject[] HintOuterTurrets;
	public GameTempoScript game;
	public PointerMovementScript pointerMovement;
	private const int innerDivision = 8;
	private float innerDeltaAngle;
	private int[,] enemy_8_array;
	private int[,] enemy_16_array;
	private const int outerDivision = 16;
	private float outerDeltaAngle;
	private float roundPerMin;
	private float height;
	private float width;
	private float bpm;
	private float secPerRound;
	bool start = true;
	private int currentCount = 2;
	private int round_count = 0;
	void Start () {
		enemy_8_array = game.innerGameTempo; 
		enemy_16_array = game.outerGameTempo;
		height = Screen.height;
		width = Screen.width;
		innerDeltaAngle = 360.0f / innerDivision;
		outerDeltaAngle = 360.0f / outerDivision;
	}

	// Update is called once per frame
	void Update () {
		for (int i = 0; i < Input.touches.Length; i++) {
			//			Debug.Log ("Point "+Input.touches[i].fingerId +":" + Input.touches[i].position);
			if (Input.touches [i].phase == TouchPhase.Began) {
				TouchEvent (Input.touches [i].position);
			}
		}
	}
	private void TouchEvent (Vector3 screenPos) {
		screenPos.x -= width / 2;
		screenPos.y -= height / 2;
		//			Debug.Log ("Point "+Input.touches[i].fingerId +":" + screenPos);
		float angle = (Mathf.Atan2(screenPos.y, screenPos.x) * Mathf.Rad2Deg);
		if (angle < 0) {
			angle += 360.0f;
		}

		Debug.Log ("Angle : " + angle);
		if (screenPos.magnitude < senseRadius) {
			//			Debug.Log ("in");
			int index = Mathf.FloorToInt(angle / innerDeltaAngle);
			Debug.Log (index);
			HintInnerTurrets [index].SetActive (
				 false
			);
		} else {
			//			Debug.Log ("out");
			int index = Mathf.FloorToInt(angle / outerDeltaAngle);
			Debug.Log (index);
			HintOuterTurrets [index].SetActive (
				false 
			);
		}
	}

	public void Hint(){
		Debug.Log ("inside hint");
		for(int i = 0; i < 8; i++){
			if (enemy_8_array [round_count+1, i] != 0) {
				Debug.Log ("round = " + round_count.ToString());
				//HintInnerTurrets [i].SetActive (true);
				//print(Time.time);
				//FadeIn (HintInnerTurrets[i].GetComponent<SpriteRenderer> (), 0.1f);
				Debug.Log(",,,"+ i.ToString());
				StartCoroutine(innerCoroutine(i));
				//print(Time.time);
				//FadeOut (HintInnerTurrets[i].GetComponent<SpriteRenderer> (), 0.1f);


			}
		}
		for(int i = 0; i < 16; i++){
			if (enemy_16_array [round_count + 1, i] != 0) {
				Debug.Log("16bit"+ i.ToString());
				StartCoroutine (outerCoroutine (i));
			}
		}
		round_count += 1;

	}
	void FadeIn(SpriteRenderer item, float num){
		item.DOFade (1, game.secPerRound / num).SetEase (Ease.OutElastic);
	}
	void FadeOut(SpriteRenderer item, float num){
		item.DOFade (0.5f, game.secPerRound / num).SetEase (Ease.OutElastic);
	}
	void Fadetozero(SpriteRenderer item, float num){
		item.DOFade (0f, game.secPerRound / num).SetEase (Ease.OutElastic);
	}
	IEnumerator innerCoroutine(int i)
	{
		//Debug.Log (Time.time);
		HintInnerTurrets [i].SetActive (true);
		FadeIn (HintInnerTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		//Debug.Log (Time.time);
		yield return new WaitForSeconds(0.1f);
		FadeOut (HintInnerTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		FadeIn (HintInnerTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		FadeOut (HintInnerTurrets[i].GetComponent<SpriteRenderer> (), 1f); 
		yield return new WaitForSeconds(0.1f);
		FadeIn (HintInnerTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		FadeOut (HintInnerTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		FadeIn (HintInnerTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		Fadetozero (HintInnerTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		//Debug.Log (Time.time);
		HintInnerTurrets [i].SetActive (false);


	}
	IEnumerator outerCoroutine(int i)
	{
		HintOuterTurrets [i].SetActive (true);
		FadeIn (HintOuterTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		FadeOut (HintOuterTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		FadeIn (HintOuterTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		FadeOut (HintOuterTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		FadeIn (HintOuterTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		FadeOut (HintOuterTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		FadeIn (HintOuterTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		yield return new WaitForSeconds(0.1f);
		Fadetozero (HintOuterTurrets[i].GetComponent<SpriteRenderer> (), 1f);
		HintOuterTurrets [i].SetActive (false);
	}
}
