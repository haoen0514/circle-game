using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {
	public Rigidbody bullet;
	private bool shoot = false;
	Setup setUpScript;
	GameTempoScript gameTempoScript;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown(){
		Debug.Log (this.gameObject.name);
		if (shoot == true) {
			shoot = false;
			this.transform.GetChild (0).gameObject.SetActive (false);
		} else {
			this.transform.GetChild (0).gameObject.SetActive (true);
			shoot = true;
		}

	}
	void OnTriggerEnter(Collider other){
		if (shoot == true) {
			Debug.Log (other.gameObject.name);
			if (other.gameObject.name == "Pointer") {
				Rigidbody instantiatedProjectile = Instantiate (bullet,
					                                  this.gameObject.transform.position,
					                                  this.gameObject.transform.rotation)
				as Rigidbody;
				instantiatedProjectile.velocity = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0).normalized;
			}
		}

	}
}
