using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameTempoScript : MonoBehaviour {

//	public List<bool> gameTempo = new List<bool> ();
	public List<GameObject> eightPieces = new List<GameObject>();
	public bool[,] innerGameTempo = new bool[30, 30];
	public bool[,] outerGameTempo = new bool[30, 30];
	public int tempo = 1;
	public int bpm;
	public bool start = false;
	private float timer = 0f;
	private int currentCount = 0;
	private float roundPerMin;
	public float secPerRound;
	public Setup setup;
	private AudioSource audio;
	public GameObject sixteenEnemy;
	public GameObject eightEnemy;

	// Use this for initializations
	void Start () {
//		for (int i = 0; i < 30; i++) {
//			for (int j = 0; j < 8; j++)
//				if (Random.value > -1)
//					innerGameTempo [i, j] = true;
//		}
		innerGameTempo [0, 3] = true;
		innerGameTempo [0, 4] = true;
		innerGameTempo [1, 5] = true;

		outerGameTempo [0, 3] = true;
		outerGameTempo [0, 4] = true;
		outerGameTempo [1, 5] = true;
		outerGameTempo [1, 8] = true;
		outerGameTempo [1, 9] = true;
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
		for(int i = 0; i < 8; i++){
			if (innerGameTempo [currentCount, i] == true) {
				eightEnemy.transform.GetChild (i).GetComponent<EnemySpawnPointScript> ().SpawnEnemy ();
			}
		}
		for(int i = 0; i < 16; i++){
			if (innerGameTempo [currentCount, i] == true) {
				sixteenEnemy.transform.GetChild (i).GetComponent<EnemySpawnPointScript> ().SpawnEnemy ();
			}
		}
		currentCount += 1;
	}
}
