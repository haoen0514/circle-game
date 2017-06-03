using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {
	public ParticleSystem enemyKillEffect;
	private Object ps;
	private AudioSource audio;
	public int index;
	void Start () {
		audio = this.gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(index == 1)
			transform.localScale -= new Vector3 (0.0049f, 0.0049f, 0); //for 16enemy
		else
			transform.localScale -= new Vector3 (0.004f, 0.004f, 0); //for 8enemy
	}
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log (other.gameObject.name);
		if(index == 1)
			if (other.name == "16bullet(Clone)" || other.gameObject.name == "Turret") {
				ps = Instantiate (enemyKillEffect,
					                    this.gameObject.transform.position,
					                    this.gameObject.transform.rotation);
	//			audio.Play ();
				Destroy(this.gameObject);


			}	
		if(index == 2)
			if (other.name == "8bullet(Clone)" || other.gameObject.name == "Turret") {
				ps = Instantiate (enemyKillEffect,
					this.gameObject.transform.position,
					this.gameObject.transform.rotation);
				//			audio.Play ();
				Destroy(this.gameObject);


			}	
	}
}
