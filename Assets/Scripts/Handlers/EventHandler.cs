using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
	public delegate void AsteroidDestroyedDelegate(GameObject asteroid);
	public static event AsteroidDestroyedDelegate AsteroidDestroyedSubscribers;

	public static void AsteroidDestroyed(GameObject asteroid)
	{
		AsteroidDestroyedSubscribers(asteroid);
	}
}
