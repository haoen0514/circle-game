using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TurretScript : MonoBehaviour {
	public Rigidbody2D bullet;
	private bool shoot = true;
	public Setup setup;
	private Quaternion rotation;
	public GameTempoScript gameTempoScript;
	public Text gameOverText;
	public int index;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Keypad6) || Input.GetKeyDown (KeyCode.K)) {
			if (this.gameObject.transform.GetChild (0).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (0).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (0).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (0).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (0).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad9) || Input.GetKeyDown (KeyCode.I)) {
			if (this.gameObject.transform.GetChild (1).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (1).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (1).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (1).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (1).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad8) || Input.GetKeyDown (KeyCode.U)) {
			if (this.gameObject.transform.GetChild (2).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (2).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (2).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (2).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (2).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad7) || Input.GetKeyDown (KeyCode.Y)) {
			if (this.gameObject.transform.GetChild (3).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (3).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (3).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (3).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (3).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad4) || Input.GetKeyDown (KeyCode.G)) {
			if (this.gameObject.transform.GetChild (4).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (4).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (4).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (4).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (4).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad1) || Input.GetKeyDown (KeyCode.B)) {
			if (this.gameObject.transform.GetChild (5).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (5).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (5).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (5).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (5).transform.GetChild (0).gameObject.SetActive (true);
			}
		} else if (Input.GetKeyDown (KeyCode.Keypad2) || Input.GetKeyDown (KeyCode.N)) {
			if (this.gameObject.transform.GetChild (6).gameObject.GetComponent<BoxCollider> ().enabled) {
				this.gameObject.transform.GetChild (6).gameObject.GetComponent<BoxCollider> ().enabled = false;
				this.gameObject.transform.GetChild (6).transform.GetChild (0).gameObject.SetActive (false);
			} else {
				this.gameObject.transform.GetChild (6).gameObject.GetComponent<BoxCollider> ().enabled = true;
				this.gameObject.transform.GetChild (6).transform.GetChild (0).gameObject.SetActive (true);
			}
		}
		else if (Input.GetKeyDown (KeyCode.Keypad3) || Input.GetKeyDown (KeyCode.M)) {
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
				rotation = Quaternion.Euler(this.gameObject.transform.rotation.eulerAngles + new Vector3(0,0,230));
				//Debug.Log (rotation.eulerAngles);

				Rigidbody2D instantiatedProjectile = Instantiate (bullet,
					this.gameObject.transform.position,
					rotation)as Rigidbody2D;

				instantiatedProjectile.velocity = new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y).normalized;
			}
		}

	}
	public void Shoot(int index1){
		Rigidbody2D instantiatedProjectile = Instantiate (bullet, transform.position, transform.rotation)
			as Rigidbody2D;
		if (index == 1)
			instantiatedProjectile.transform.Rotate (0, 0, 225 + 45f * index1);
		else {
			Debug.Log (instantiatedProjectile);
			instantiatedProjectile.transform.Rotate (0, 0, 202.5f);
		}
		instantiatedProjectile.velocity = new Vector2 (transform.position.x, transform.position.y).normalized;
		instantiatedProjectile.velocity = instantiatedProjectile.velocity * ((setup.bigCircleRadius - setup.smallCircleRadius) / gameTempoScript.secPerRound);
	}
}
