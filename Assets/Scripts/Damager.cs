using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
	public int damage;

	//ObjectPool objectPool;

	//private void Start()
	//{
	//	objectPool = FindObjectOfType<ObjectPool>();
	//}

	void OnCollisionEnter2D(Collision2D collision)
	{
		//HACK rewrite
		if (tag == "SmallAsteroid" || tag == "BigAsteroid")
		{
			if (collision.collider.tag == "Player" || collision.collider.tag == "Laser")
			{
				if (collision.collider.GetComponent<Health>())
				{
					collision.collider.GetComponent<Health>().Damage(damage);
				}
			}
		}
		else if (tag == "Laser")
		{
			if (collision.collider.tag == "Player" || collision.collider.tag == "Laser")
			{

			}
			else
			{
				if (collision.collider.GetComponent<Health>())
				{
					collision.collider.GetComponent<Health>().Damage(damage);
				}
			}
		}
	}
}
