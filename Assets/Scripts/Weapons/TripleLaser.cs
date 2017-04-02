using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleLaser : Weapon, IWeapon
{
	public float fireRate = 0.2f;

	public void Fire()
	{
		if (timePassed > fireRate)
		{
			GameObject laser1 = objectPool.GetLaser();
			GameObject laser2 = objectPool.GetLaser();
			GameObject laser3 = objectPool.GetLaser();
			laser1.transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
			laser2.transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y + 1f);
			laser3.transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y + 1f);
			timePassed = 0;
		}
	}
}
