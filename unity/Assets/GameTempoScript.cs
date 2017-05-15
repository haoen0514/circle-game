using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameTempoScript : MonoBehaviour {

//	public List<bool> gameTempo = new List<bool> ();
	private bool[,] gameTempo = new bool[30, 30];
	public int tempo = 1;
	public int bpm;
	public bool start = false;
	private float timer = 0f;
	private int currentCount = 0;
	private float roundPerMin;
	public float secPerRound;
	public Setup setup;
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		gameTempo [0, 3] = true;
		gameTempo [0, 4] = true;
		gameTempo [1, 5] = true;
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return))
			start = !start;
		roundPerMin = bpm / 4f;
		secPerRound = 60 / roundPerMin;
		if (start == true) {
			if (timer > secPerRound) {
				Spawn ();
				timer = 0f;
			}
		}
		timer += Time.deltaTime;
		if(start == false){
			currentCount = 0;	
		}
	}
	void Spawn(){
//		for (int i = 0; i < tempo; i++) {
//			if (gameTempo [currentCount+i] == true) {
//				this.gameObject.transform.GetChild ((currentCount + i) % tempo).GetComponent<EnemySpawnPointScript> ().SpawnEnemy ();
//			}
//		}
//		currentCount += tempo;
		for(int i = 0; i < tempo; i++){
			if (gameTempo [currentCount, i] == true) {
				this.gameObject.transform.GetChild (i).GetComponent<EnemySpawnPointScript> ().SpawnEnemy ();
			}
		}
		currentCount += 1;
	}
}
