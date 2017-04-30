using UnityEngine;
using System.Collections;

public class killEffect : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("killself",3f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void killself(){
		Destroy (this.gameObject);
	}
}
