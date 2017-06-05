using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {
	private Object ps;
	private AudioSource audio;
	public int index;
	public float scaleFor16Bullet = 0.01f;
	public float scaleFor8Bullet = 0.01f;
	void Start () {
		audio = this.gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if(index == 1)
			transform.localScale += new Vector3 (scaleFor16Bullet, scaleFor16Bullet, 0); //for 16bullet
		else
			transform.localScale += new Vector3 (scaleFor8Bullet,scaleFor8Bullet, 0); //for 8bullet
	}
	void OnTriggerEnter2D(Collider2D other){
		
	}
}
