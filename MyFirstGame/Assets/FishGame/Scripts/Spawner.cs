using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] fallingBlockPrefabs;
	public Vector2 secondsBetweenSpawnsMinMax;
	float nextSpawnTime;

	public Vector2 spawnSizeMinMax;
	public float spawnAngleMax;

	Vector2 screenHalfSizeWorldUnits;

	public int difficulty=0;



	// Use this for initialization
	void Start () {
		screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
		difficulty = DifficultyControl.difficulty;
		if (difficulty == 0)
        {
			spawnSizeMinMax = Vector2.one;
			spawnAngleMax = 0;
			secondsBetweenSpawnsMinMax = new Vector2(1, 2);
        }
		else if (difficulty == 1)
		{
			spawnSizeMinMax = Vector2.one * 2;
			spawnAngleMax = 0;
			secondsBetweenSpawnsMinMax = new Vector2(1, 2);
		}
		else if (difficulty == 2)
		{
			spawnSizeMinMax = Vector2.one *2;
			spawnAngleMax = 10;
			secondsBetweenSpawnsMinMax = new Vector2(1, 2);
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > nextSpawnTime) {
			GameObject fallingBlockPrefab = fallingBlockPrefabs[Random.Range(0,fallingBlockPrefabs.Length)];
			
			float secondsBetweenSpawns = Mathf.Lerp (secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
			nextSpawnTime = Time.time + secondsBetweenSpawns;
			

			float spawnAngle = Random.Range (-spawnAngleMax, spawnAngleMax);
			float spawnSize = Random.Range (spawnSizeMinMax.x, spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2 (Random.Range (-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
			GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));
				
			newBlock.transform.localScale = (Vector2.one * spawnSize) * newBlock.transform.localScale;

		}
	
	}

}
