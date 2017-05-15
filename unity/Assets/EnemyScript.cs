using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {
	public ParticleSystem enemyKillEffect;
	private Object ps;
	private AudioSource audio;
	void Start () {
		audio = this.gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.name == "Sphere(Clone)" || other.gameObject.name == "EnemyCollider") {
			ps = Instantiate (enemyKillEffect,
				                    this.gameObject.transform.position,
				                    this.gameObject.transform.rotation);
//			audio.Play ();
			Debug.Log ("MingWei123");
			Destroy(this.gameObject);


		}	
	}
}
