using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
	public delegate void AsteroidDestroyedDelegate();
	public static event AsteroidDestroyedDelegate AsteroidDestroyedSubscribers;

	//TODO rewrite for observer pattern
	public static void AsteroidDestroyed()
	{
		AsteroidDestroyedSubscribers();
	}
}
