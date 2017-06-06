using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class BulletScript : MonoBehaviour {
	private Object ps;
	private AudioSource audio;
	public int index;
	public float scaleFor16Bullet = 0.03f;
	public float scaleFor8Bullet = 0.03f;
	void Start () {
		audio = this.gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		if(index == 1)
			transform.localScale += new Vector3 (0.012f, 0.012f, 0); //for 16bullet
		else
			transform.localScale += new Vector3 (0.014f,0.014f, 0); //for 8bullet
	}
	void OnTriggerEnter2D(Collider2D other){
		if(index == 1)
		if (other.name == "16enemy(Clone)" ) {
			Destroy(this.gameObject);
		}	
		else
		if (other.name == "8enemy(Clone)" ) {
			Destroy(this.gameObject);
		}	
	}
}
