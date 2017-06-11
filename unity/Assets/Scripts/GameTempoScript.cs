using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameTempoScript : MonoBehaviour {

//	public List<bool> gameTempo = new List<bool> ();
	public List<GameObject> eightPieces = new List<GameObject>();
	public int[,] innerGameTempo = new int[15, 8] {
		{ 0, 0, 0, 0, 1, 0, 0, 0 },
		{ 0, 0, 0, 0, 1, 0, 0, 0 },
		{ 0, 0, 0, 0, 1, 0, 0, 0 },
		{ 0, 0, 0, 0, 1, 0, 0, 0 },
		{ 0, 0, 0, 0, 1, 0, 0, 0 },	
		{ 0, 0, 0, 0, 1, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0 },	
		{ 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0 },	
		{ 0, 0, 0, 0, 0, 0, 0, 0 },
	};
	public int[,] outerGameTempo = new int[15, 16]{
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
	};
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
	public PointerMovementScript pointerMovement;

	// Use this for initializations
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return))
			start = !start;
		roundPerMin = bpm / 4f;
		secPerRound = 60 / roundPerMin;
		if (start == true) {
			if (pointerMovement.spawn) {
				Spawn ();
				pointerMovement.spawn = false;
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
			if (innerGameTempo [currentCount, i] == 1) {
				eightEnemy.transform.GetChild (i).GetComponent<EnemySpawnPointScript> ().SpawnEnemy ();
			}
		}
		for(int i = 0; i < 16; i++){
			if (outerGameTempo [currentCount, i] == 1) {
				sixteenEnemy.transform.GetChild (i).GetComponent<EnemySpawnPointScript> ().SpawnEnemy ();
			}
		}
		currentCount += 1;
	}
}
