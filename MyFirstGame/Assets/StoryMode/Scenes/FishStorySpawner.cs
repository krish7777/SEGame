using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishStorySpawner : MonoBehaviour
{
	public GameObject[] fallingBlockPrefabs;
	public Vector2 secondsBetweenSpawnsMinMax;
	float nextSpawnTime;

	public Vector2 spawnSizeMinMax;
	public float spawnAngleMax;

	Vector2 screenHalfSizeWorldUnits;

	public bool endBlockSpawned = false;
	public GameObject EndBlock;
	public float endTime = 15;



	// Use this for initialization
	void Start()
	{
		screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
		spawnSizeMinMax = new Vector2(1, 2);
		spawnAngleMax = 10;
		secondsBetweenSpawnsMinMax = new Vector2(1, 2);
		Time.timeScale = 1f;
	}

	// Update is called once per frame
	void Update()
	{

		if (Time.timeSinceLevelLoad > nextSpawnTime && Time.timeSinceLevelLoad < endTime)
		{
			GameObject fallingBlockPrefab = fallingBlockPrefabs[Random.Range(0, fallingBlockPrefabs.Length)];

			float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
			nextSpawnTime = Time.timeSinceLevelLoad + secondsBetweenSpawns;


			float spawnAngle = Random.Range(-spawnAngleMax, spawnAngleMax);
			float spawnSize = Random.Range(spawnSizeMinMax.x, spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnSize);
			GameObject newBlock = (GameObject)Instantiate(fallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * spawnAngle));

			newBlock.transform.localScale = (Vector2.one * spawnSize) * newBlock.transform.localScale;

		}

		if(Time.timeSinceLevelLoad > endTime + 2 && !endBlockSpawned)
        {
			Instantiate(EndBlock, new Vector2(0, screenHalfSizeWorldUnits.y + 5), Quaternion.identity);
			endBlockSpawned = true;

		}

	}
}
