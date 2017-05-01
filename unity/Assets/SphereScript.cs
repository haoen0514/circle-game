using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {

	public ParticleSystem enemyKillEffect;
	private Object ps;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other){
		print (other.name);
		if (other.gameObject.name == "Enemy(Clone)") {
			Debug.Log (gameObject.name);
			Destroy (this.gameObject);
		}
		if (other.name == "s0" || other.name == "s45" || other.name == "s90" || other.name == "s135" || other.name == "s180" || other.name == "s225" || other.name == "s270" || other.name == "s315") {
			ps = Instantiate (enemyKillEffect,
				this.gameObject.transform.position,
				this.gameObject.transform.rotation);
			//			scoreScript.AddScore ();
			Destroy(this.gameObject);
		
		}

	}
}

