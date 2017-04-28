using UnityEngine;
using System.Collections;

public class ShpereScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other){
		print (other.name);
		if (other.gameObject.name == "Sphere(Clone)") {
			Debug.Log ("fuck"+gameObject.name);
			Destroy (this.gameObject);
		}
	}
	void OnCollisionEnter(Collision other){
//		print (other.gameObject.name);
//		if (other.gameObject.name == "Sphere(Clone)") {
//			Debug.Log ("fuck");
//			Destroy (this.gameObject);
//		}
	
	}
}
