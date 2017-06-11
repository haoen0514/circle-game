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
			transform.localScale = initial_scale_8 * Mathf.Sqrt ((transform.position.x * transform.position.x + transform.position.y * transform.position.y)) / 28.6f;
		}
		else{
			transform.localScale = initial_scale_16 * Mathf.Sqrt((transform.position.x * transform.position.x  + transform.position.y * transform.position.y )) / 28.6f;
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if(index == 1)
			if (other.name == "16bullet(Clone)" || other.gameObject.name == "Turret") {
				Debug.Log (other);
				ps = Instantiate (enemyKillEffect,
					                    this.gameObject.transform.position,
					                    this.gameObject.transform.rotation);
				if (other.name == "Turret") {
					setup.bloodNum -= 1;
				}
				Destroy(this.gameObject);

				
			}	
		if(index == 2)
			if (other.name == "8bullet(Clone)" || other.gameObject.name == "Turret") {
				Debug.Log (other);
				ps = Instantiate (enemyKillEffect,
					this.gameObject.transform.position,
					this.gameObject.transform.rotation);
				if (other.name == "Turret") {
					setup.bloodNum -= 1;
				}
				Destroy(this.gameObject);
			}	
	}
}
