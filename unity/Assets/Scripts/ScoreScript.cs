using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public Text scoreText;
	private int score = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AddScore(){
		Debug.Log ("add");
		score = score + 1;
		scoreText.text = "Score: " + score.ToString();
	}
}
