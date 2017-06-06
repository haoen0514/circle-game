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

	void Start () {
		audio = this.gameObject.GetComponent<AudioSource> ();
		if (index == 1)
			initial_scale_8 = transform.localScale;
		else
			initial_scale_16 = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		if(index == 1){
			transform.localScale = initial_scale_8 * (Mathf.Sqrt ((transform.position.x * transform.position.x + transform.position.y * transform.position.y)) / 5.7f);
		}
		else{
			transform.localScale = initial_scale_16 * Mathf.Sqrt((transform.position.x * transform.position.x  + transform.position.y * transform.position.y )) / 5.7f;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
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
