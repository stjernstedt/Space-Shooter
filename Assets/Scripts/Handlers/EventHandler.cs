using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
	public delegate void AsteroidDestroyedDelegate(GameObject asteroid);
	public static event AsteroidDestroyedDelegate AsteroidDestroyedSubscribers;

	public delegate void WeaponChangedDelegate(IWeapon weapon);
	public static event WeaponChangedDelegate WeaponChangedSubscribers;

	public static void AsteroidDestroyed(GameObject asteroid)
	{
		AsteroidDestroyedSubscribers(asteroid);
	}

	public static void WeaponChanged(IWeapon weapon)
	{
		WeaponChangedSubscribers(weapon);
	}
}
