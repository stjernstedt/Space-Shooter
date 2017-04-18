using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
	Vector2 origin;

	public float spawnTime;
	public float randomOffset;
	public float startingDifficulty;
	public float maxDifficulty;
	public float timeToMaxDifficulty;

	float nextSpawn;
	float timePassed;
	float totalTime;

	float cameraWidth;
	float cameraHeight;

	ObjectPool objectPool;

	// Use this for initialization
	void Start()
	{
		spawnTime = startingDifficulty;
		objectPool = FindObjectOfType<ObjectPool>();
		float originOffset = 2f;
		cameraHeight = Camera.main.orthographicSize;
		cameraWidth = cameraHeight * Camera.main.aspect;
		origin = new Vector2(0, cameraHeight + originOffset);
		nextSpawn = spawnTime + Random.Range(-randomOffset, randomOffset);
	}

	// Update is called once per frame
	void Update()
	{
		totalTime += Time.deltaTime;

		spawnTime = Mathf.Lerp(startingDifficulty, maxDifficulty, totalTime / timeToMaxDifficulty);

		if (timePassed > nextSpawn)
		{
			float xOffset = Random.Range(-cameraWidth, cameraWidth);
			Vector2 spawnPosition = new Vector2(origin.x + xOffset, origin.y);
			GameObject asteroid = objectPool.GetBigAsteroid();
			asteroid.transform.position = spawnPosition;
			timePassed = 0;
			nextSpawn = spawnTime + Random.Range(-randomOffset, randomOffset);
		}
		timePassed += Time.deltaTime;
	}
}
