using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {
	private Object ps;
	private AudioSource audio;
	public int index;
	private Vector3 initial_scale_8;
	private Vector3 initial_scale_16;
	private Setup setup;
	void Start () {
		if (index == 0)
			initial_scale_8 = transform.localScale;
		else
			initial_scale_16 = transform.localScale;

		setup = GameObject.Find ("Main Camera").GetComponent<Setup> ();


	}

	// Update is called once per frame
	void Update () {
		if(index == 0){
			transform.localScale = initial_scale_8 * Mathf.Sqrt ((transform.position.x * transform.position.x + transform.position.y * transform.position.y)) / 7.28f;
		}
		else{
			transform.localScale = initial_scale_16 * Mathf.Sqrt((transform.position.x * transform.position.x  + transform.position.y * transform.position.y )) / 7.28f;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log (other);
		if (index == 1) {
			if (other.name == "16enemy(Clone)"|| other.name == "16enemy (1)(Clone)"|| other.name == "16enemy (2)(Clone)"|| other.name == "16enemy (3)(Clone)"|| other.name == "16enemy (4)(Clone)"|| other.name == "16enemy (5)(Clone)"|| other.name == "16enemy (6)(Clone)"|| other.name == "16enemy (7)(Clone)") {
				Destroy (this.gameObject);
			}
		} else {
			if (other.name == "8enemy(Clone)" || other.name == "8enemy (1)(Clone)" || other.name == "8enemy (2)(Clone)" || other.name == "8enemy (3)(Clone)" || other.name == "8enemy (4)(Clone)" || other.name == "8enemy (5)(Clone)" || other.name == "8enemy (6)(Clone)" || other.name == "8enemy (7)(Clone)") {
				Destroy (this.gameObject);
			}
		}
	}
}
