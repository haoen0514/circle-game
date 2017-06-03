using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyColliderScript : MonoBehaviour {

	public Text gameOverText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		if (other.gameObject.name == "Enemy(Clone)") {
			gameOverText.gameObject.SetActive (true);
		}
	}
}
