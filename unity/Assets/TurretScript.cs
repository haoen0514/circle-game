using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TurretScript : MonoBehaviour {
	public Rigidbody bullet;
	private bool shoot = true;
	Setup setUpScript;
	GameTempoScript gameTempoScript;
	public Text gameOverText;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Keypad6)) {
			if (this.gameObject.transform.GetChild (0).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (0).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (0).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (0).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (0).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad9)) {
			if (this.gameObject.transform.GetChild (1).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (1).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (1).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (1).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (1).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad8)) {
			if (this.gameObject.transform.GetChild (2).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (2).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (2).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (2).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (2).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad7)) {
			if (this.gameObject.transform.GetChild (3).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (3).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (3).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (3).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (3).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad4)) {
			if (this.gameObject.transform.GetChild (4).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (4).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (4).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (4).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (4).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad1)) {
			if (this.gameObject.transform.GetChild (5).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (5).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (5).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (5).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (5).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad2)) {
			if (this.gameObject.transform.GetChild (6).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (6).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (6).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (6).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (6).transform.GetChild (0).gameObject.SetActive (true);
			}
		}
		else if (Input.GetKeyDown (KeyCode.Keypad3)) {
			if (this.gameObject.transform.GetChild (7).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (7).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (7).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (7).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (7).transform.GetChild (0).gameObject.SetActive (true);
			}
		}
	}
//	void OnMouseDown(){
//		Debug.Log (this.gameObject.name);
//		if (shoot == true) {
//			shoot = false;
//			this.transform.GetChild (0).gameObject.SetActive (false);
//		} else {
//			this.transform.GetChild (0).gameObject.SetActive (true);
//			shoot = true;
//		}
//
//	}
	void OnTriggerEnter(Collider other){
		if (shoot == true) {
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
