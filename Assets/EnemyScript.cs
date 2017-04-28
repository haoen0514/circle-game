using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyScript : MonoBehaviour {

	Setup setup;
	public Rigidbody enemy;
	public List<bool> game = new List<bool>();

	void Start () {
		InvokeRepeating ("Shoot", 0f, 1f);
	}

	void Update () {
//		Rigidbody instantiatedProjectile = Instantiate (enemy,
//			this.gameObject.transform.position,
//			this.gameObject.transform.rotation)
//			as Rigidbody;
//		instantiatedProjectile.velocity = this.gameObject.transform.position;
	}
	void Shoot (){
//		Rigidbody instantiatedProjectile = Instantiate (enemy,
//			this.gameObject.transform.position,
//			this.gameObject.transform.rotation)
//			as Rigidbody;
//		Debug.Log (this.gameObject.transform.position);
//		instantiatedProjectile.velocity = new Vector3 (-this.gameObject.transform.position.x/4, -this.gameObject.transform.position.y/4, 0);
	}
}
