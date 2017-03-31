using UnityEngine;
using System.Collections;

public class AsteroidSpawner : MonoBehaviour
{
	Vector2 origin;

	public float spawnTime;
	public float randomOffset;
	float nextSpawn;
	float timePassed;

	ObjectPool objectPool;

	// Use this for initialization
	void Start()
	{
		objectPool = FindObjectOfType<ObjectPool>();
		float originOffset = 6f;
		origin = new Vector2(0, Camera.main.rect.height + originOffset);
		nextSpawn = spawnTime + Random.Range(-randomOffset, randomOffset);
	}

	// Update is called once per frame
	void Update()
	{
		if (timePassed > nextSpawn)
		{
			Vector2 spawnPosition = new Vector2(origin.x + Random.Range(-Camera.main.rect.width, Camera.main.rect.width), origin.y);
			GameObject asteroid = objectPool.GetBigAsteroid();
			asteroid.transform.position = spawnPosition;
			timePassed = 0;
			nextSpawn = spawnTime + Random.Range(-randomOffset, randomOffset);
		}
		timePassed += Time.deltaTime;
	}
}
