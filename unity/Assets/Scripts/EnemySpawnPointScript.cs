using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class EnemySpawnPointScript : MonoBehaviour {

	public int index;
	public Rigidbody2D enemy;
	public Text gameOverText;
	public int index1;
	public Setup setup;
	public GameTempoScript gameTempoScript;

	// Use this for initialization
	void Start () {
//		InvokeRepeating ("SpawnEnemy", 0f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SpawnEnemy(){
		Rigidbody2D instantiatedProjectile = Instantiate (enemy, transform.position, transform.rotation)
			as Rigidbody2D;
		if(index1 == 1)
			instantiatedProjectile.transform.Rotate (0, 0, 45f + 45f * index);
		else
			instantiatedProjectile.transform.Rotate (0, 0, 45f + 22.5f * index);
		instantiatedProjectile.velocity =  new Vector3 (-this.gameObject.transform.position.x, -this.gameObject.transform.position.y).normalized;
		instantiatedProjectile.velocity = instantiatedProjectile.velocity * (setup.bigCircleRadius - setup.smallCircleRadius / gameTempoScript.secPerRound);
	}
	void OnTriggerEnter(Collider other){

		if (other.gameObject.name == "Sphere(Clone)") {
			gameOverText.gameObject.SetActive (true);
		}
	}
}
