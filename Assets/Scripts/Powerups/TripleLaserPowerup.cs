using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleLaserPowerup : MonoBehaviour, IPowerup
{

	public void ApplyPowerup()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Destroy(player.GetComponent<Weapon>());
		IWeapon weapon = player.AddComponent<TripleLaser>();
		EventHandler.WeaponChanged(weapon);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "Player")
		{
			ApplyPowerup();
			Destroy(gameObject);
		}
	}
}
