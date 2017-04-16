using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropper : MonoBehaviour
{
	public GameObject healthPowerup;
	public GameObject tripleLaserPowerup;

	void Start()
	{
		EventHandler.AsteroidDestroyedSubscribers += OnAsteroidDestroyed;
	}

	void OnAsteroidDestroyed(GameObject asteroid)
	{
		//Checks if this item dropper asteroid is the same as the destroyed asteroid
		if (asteroid == gameObject)
		{
			GameObject powerup = GetPowerup();
			if (powerup != null)
			{
				powerup.transform.position = transform.position;
			}
		}
	}

	GameObject GetPowerup()
	{
		int random = Random.Range(0, 100);
		//TODO add different items and give them a chance to drop
		GameObject powerup = null;

		if (random <= 10)
		{
			powerup = Instantiate(healthPowerup);
			return powerup;
		}
		if (random <= 20)
		{
			powerup = Instantiate(tripleLaserPowerup);
			return powerup;
		}

		return powerup;
	}
}
