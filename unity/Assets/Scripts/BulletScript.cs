using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {
	private Object ps;
	private AudioSource audio;
	public int index;
	void Start () {
		audio = this.gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if(index == 1)
			transform.localScale += new Vector3 (0.006f, 0.006f, 0); //for 16enemy
		else
			transform.localScale += new Vector3 (0.0065f, 0.0065f, 0); //for 8enemy
	}
	void OnTriggerEnter2D(Collider2D other){
		
	}
}
