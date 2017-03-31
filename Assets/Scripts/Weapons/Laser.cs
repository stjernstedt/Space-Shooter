using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Weapon, IWeapon
{
	public void Fire()
	{
		if (timePassed > fireRate)
		{
			GameObject laser = objectPool.GetLaser();
			laser.transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
			timePassed = 0;
		}
	}
}
