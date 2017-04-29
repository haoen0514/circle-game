using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {

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
	}
}

