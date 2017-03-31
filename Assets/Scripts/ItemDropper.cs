using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
	public GameObject healthPowerup;

	void Start()
	{
		EventHandler.AsteroidDestroyedSubscribers += OnAsteroidDestroyed;
	}

	void OnAsteroidDestroyed(GameObject asteroid)
	{
		//Checks if this item dropper asteroid is the same as the destroyed asteroid
		if(asteroid == gameObject)
		{
			GameObject powerup = Instantiate(healthPowerup);
			powerup.transform.position = transform.position;
		}
	}
}
