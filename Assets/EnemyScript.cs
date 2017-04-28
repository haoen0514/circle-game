using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public ParticleSystem enemyKillEffect;
	// Use this for initialization
	public ParticleSystem ps;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.name == "Sphere(Clone)") {
			
			Destroy (this.gameObject);
		}	
	}
}
