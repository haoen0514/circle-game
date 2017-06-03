using UnityEngine;
using System.Collections;

public class KillSelfScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke("killself",10f);
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	void killself(){
		Destroy (this.gameObject);
	}

}
