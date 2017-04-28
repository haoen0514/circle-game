using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemySpawnPointScript : MonoBehaviour {

	public Rigidbody enemy;
	public List<bool> game = new List<bool>();

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnEnemy", 0f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy(){
		Rigidbody instantiatedProjectile = Instantiate (enemy,
			this.gameObject.transform.position,
			this.gameObject.transform.rotation)
			as Rigidbody;
		instantiatedProjectile.velocity =  new Vector3 (-this.gameObject.transform.position.x/4, -this.gameObject.transform.position.y/4, 0);
	}
}
