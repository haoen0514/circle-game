using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class TurretScript : MonoBehaviour {
	public Rigidbody2D eightBullet;
	public Rigidbody2D sixteenBullet;
	private bool shoot = true;
	public Setup setup;
	private Quaternion rotation;
	public GameTempoScript gameTempoScript;
	public Text gameOverText;
	public int index;
	private float speed = 100.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other){

	}
	public void Shoot(int index1, int num){
		Debug.Log (num);
		Rigidbody2D bullet;
		if (num == 0)
			bullet = eightBullet;
		else
			bullet = sixteenBullet;
 
		Rigidbody2D instantiatedProjectile = Instantiate (bullet, transform.position, transform.rotation)
			as Rigidbody2D;
		if (index == 1)
			instantiatedProjectile.transform.Rotate (0, 0, 0 + 45f * index1);
		else {
			instantiatedProjectile.transform.Rotate (0, 0, 0 + 22.5f * index1);
		}
		instantiatedProjectile.velocity = new Vector2 (transform.position.x, transform.position.y).normalized;
//		instantiatedProjectile.velocity = instantiatedProjectile.velocity * ((setup.bigCircleRadius - setup.smallCircleRadius) / gameTempoScript.secPerRound);
		instantiatedProjectile.velocity = instantiatedProjectile.velocity * speed;
	}
}
