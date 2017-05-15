using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemySpawnPointScript : MonoBehaviour {

	public Rigidbody enemy;
	public Text gameOverText;

	// Use this for initialization
	void Start () {
//		InvokeRepeating ("SpawnEnemy", 0f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnEnemy(){
		Rigidbody instantiatedProjectile = Instantiate (enemy,
			this.gameObject.transform.position,
			this.gameObject.transform.rotation)
			as Rigidbody;
		instantiatedProjectile.velocity =  new Vector3 (-this.gameObject.transform.position.x, -this.gameObject.transform.position.y, 0).normalized;
		instantiatedProjectile.velocity = instantiatedProjectile.velocity * 0.8f;
	}
	void OnTriggerEnter(Collider other){

		if (other.gameObject.name == "Sphere(Clone)") {
			gameOverText.gameObject.SetActive (true);
		}
	}
}
