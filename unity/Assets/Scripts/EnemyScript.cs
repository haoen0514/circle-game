using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {
	public ParticleSystem enemyKillEffect;
	private Object ps;
	private AudioSource audio;
	public int index;
	public float scaleFor16Enenmy = 0.1f;
	public float scaleFor8Enemy = 0.004f;
	private Vector3 initial_scale_8;
	private Vector3 initial_scale_16;
	private float scale = 28.6f;
	public Setup setup;

	void Start () {
		audio = this.gameObject.GetComponent<AudioSource> ();
		if (index == 1)
			initial_scale_8 = transform.localScale;
		else
			initial_scale_16 = transform.localScale;


		setup = GameObject.Find ("Main Camera").GetComponent<Setup> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(index == 1){
			transform.localScale = initial_scale_8 * Mathf.Sqrt ((transform.position.x * transform.position.x + transform.position.y * transform.position.y)) / scale;
		}
		else{
			transform.localScale = initial_scale_16 * Mathf.Sqrt((transform.position.x * transform.position.x  + transform.position.y * transform.position.y )) / scale;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log (other.name + " "+ index);
		if (index == 1) {
			if (other.name == "16bullet(Clone)" || other.name == "Turret") {
				ps = Instantiate (enemyKillEffect,
					this.gameObject.transform.position,
					this.gameObject.transform.rotation);
				if (other.name == "Turret") {
					setup.bloodNum -= 1;
					setup.AddScore (-50);
				} else {
					setup.AddScore (5);
				}
				Destroy (this.gameObject);
			}
		} else if (index == 0) {
			if (other.name == "8bullet(Clone)" || other.name == "Turret") {
				ps = Instantiate (enemyKillEffect,
					this.gameObject.transform.position,
					this.gameObject.transform.rotation);
				if (other.name == "Turret") {
					setup.bloodNum -= 1;
					setup.AddScore (-100);
				} else {
					setup.AddScore (10);
				}
				Destroy (this.gameObject);
			}
		}
	}
}
