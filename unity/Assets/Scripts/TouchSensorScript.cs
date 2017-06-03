using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSensorScript : MonoBehaviour {

	// Use this for initialization
	public float senseRadius;
	public GameObject[] innerTurrets;
	public GameObject[] outerTurrets;

	private const int innerDivision = 8;
	private float innerDeltaAngle;

	private const int outerDivision = 16;
	private float outerDeltaAngle;

	private float height;
	private float width;

	void Start () {
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
			innerTurrets [index].SetActive (
				innerTurrets [index].activeSelf ? false : true
			);
		} else {
//			Debug.Log ("out");
			int index = Mathf.FloorToInt(angle / outerDeltaAngle);
			Debug.Log (index);
			outerTurrets [index].SetActive (
				outerTurrets [index].activeSelf ? false : true
			);
		}
	}
}
