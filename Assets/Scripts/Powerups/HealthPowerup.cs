﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : MonoBehaviour, IPowerup
{
	public void ApplyPowerup()
	{
		Health health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
		health.AddHealth(1);
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
