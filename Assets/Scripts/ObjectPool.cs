using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	public GameObject bigAsteroidPrefab;
	public GameObject smallAsteroidPrefab;
	public GameObject LaserPrefab;

	public int amountOfBigAsteroids;
	public int amountOfSmallAsteroids;
	public int amountOfLasers;

	public List<GameObject> bigAsteroids = new List<GameObject>();
	public List<GameObject> smallAsteroids = new List<GameObject>();
	List<GameObject> lasers = new List<GameObject>();

	void Start()
	{
		Transform bigAsteroidsParent = new GameObject().transform;
		bigAsteroidsParent.name = "Big Asteroids";
		bigAsteroidsParent.transform.SetParent(transform);
		Transform smallAsteroidsParent = new GameObject().transform;
		smallAsteroidsParent.name = "Small Asteroids";
		smallAsteroidsParent.transform.SetParent(transform);
		Transform lasersParent = new GameObject().transform;
		lasersParent.name = "Lasers";
		lasersParent.transform.SetParent(transform);
		for (int i = 0; i < amountOfBigAsteroids; i++)
		{
			GameObject poolObject = Instantiate(bigAsteroidPrefab);
			bigAsteroids.Add(poolObject);
			poolObject.transform.SetParent(bigAsteroidsParent);
			poolObject.SetActive(false);
		}
		for (int i = 0; i < amountOfSmallAsteroids; i++)
		{
			GameObject poolObject = Instantiate(smallAsteroidPrefab);
			smallAsteroids.Add(poolObject);
			poolObject.transform.SetParent(smallAsteroidsParent);
			poolObject.SetActive(false);
		}
		for (int i = 0; i < amountOfLasers; i++)
		{
			GameObject poolObject = Instantiate(LaserPrefab);
			lasers.Add(poolObject);
			poolObject.transform.SetParent(lasersParent);
			poolObject.SetActive(false);
		}
	}

	public GameObject GetBigAsteroid()
	{
		GameObject poolObject = bigAsteroids[0];
		bigAsteroids.Remove(poolObject);

		poolObject.SetActive(true);
		return poolObject;
	}

	public GameObject GetSmallAsteroid()
	{
		GameObject poolObject = smallAsteroids[0];
		smallAsteroids.Remove(poolObject);

		poolObject.SetActive(true);
		return poolObject;
	}

	public GameObject GetLaser()
	{
		GameObject poolObject = lasers[0];
		lasers.Remove(poolObject);

		poolObject.SetActive(true);
		return poolObject;
	}

	public void ReturnObject(GameObject poolObject)
	{
		switch (poolObject.tag)
		{
			case "BigAsteroid":
				bigAsteroids.Add(poolObject);
				poolObject.GetComponent<Health>().ResetHealth();
				break;
			case "SmallAsteroid":
				smallAsteroids.Add(poolObject);
				poolObject.GetComponent<Health>().ResetHealth();
				break;
			case "Laser":
				lasers.Add(poolObject);
				break;
			default:
				Destroy(poolObject);
				break;
		}

		if (poolObject != null)
		{
			poolObject.SetActive(false);
		}
	}
}
