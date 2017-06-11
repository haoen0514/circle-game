using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Text.RegularExpressions;


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
//		Regex
//		Debug.Log (other);
		if (index == 1) {
			if( Regex.IsMatch(other.name, "16enemy", RegexOptions.IgnoreCase) )
			{
				Destroy (this.gameObject);
			}
		} else {
			if( Regex.IsMatch(other.name, "8enemy", RegexOptions.IgnoreCase) )
			{
				Destroy (this.gameObject);
			}
		}
	}
}
