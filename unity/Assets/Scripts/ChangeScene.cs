using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("hi");
	}
	void OnMouseDown (){
		Debug.Log ("hi");
		Application.LoadLevel("Scenes/V2");
	}
}
