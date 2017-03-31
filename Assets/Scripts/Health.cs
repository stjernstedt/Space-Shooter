using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public int maxHealth;
	public int health
	{
		get; private set;
	}

	ObjectPool objectPool;
	UIHandler uiHandler;
	SpriteRenderer spriteRenderer;

	float timePassed = 10;
	float blinkSpeed = 0.2f;

	public bool damageable = true;

	void Awake()
	{
		health = maxHealth;
		objectPool = FindObjectOfType<ObjectPool>();
		uiHandler = FindObjectOfType<UIHandler>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		Blink();
	}

	void Blink()
	{
		if (!damageable)
		{
			timePassed += Time.deltaTime;
			if (timePassed > blinkSpeed)
			{
				spriteRenderer.enabled = !spriteRenderer.enabled;
				timePassed = 0;
			}
		}
	}

	IEnumerator PlayerTookDamage()
	{
		damageable = false;
		yield return new WaitForSeconds(2f);
		damageable = true;
		spriteRenderer.enabled = true;
	}

	public void Damage(int damage)
	{
		if (damageable)
		{
			health -= damage;
		}
		if (tag == "Player")
		{
			uiHandler.UpdateUI();
			StartCoroutine(PlayerTookDamage());
		}
		if (health <= 0)
		{
			OnDeath();
		}
	}

	public void ResetHealth()
	{
		health = maxHealth;
	}

	private void OnDeath()
	{
		if (tag == "BigAsteroid")
		{
			EventHandler.AsteroidDestroyed(gameObject);
			uiHandler.AddPoints(50);
			int numberOfSpawns = Random.Range(2, 6);
			GameObject[] asteroids = new GameObject[numberOfSpawns];

			for (int i = 0; i < numberOfSpawns; i++)
			{
				asteroids[i] = objectPool.GetSmallAsteroid();
				asteroids[i].transform.position = transform.position;

				if (i % 2 == 0)
				{
					float randomDir = Random.Range(0.05f, 1f);
					asteroids[i].GetComponent<Move>().direction = new Vector2(randomDir, -1);
				}
				else
				{
					float randomDir = Random.Range(0.05f, 1f);
					asteroids[i].GetComponent<Move>().direction = new Vector2(-randomDir, -1);
				}
			}
		}
		if(tag == "SmallAsteroid")
		{
			uiHandler.AddPoints(10);
		}

		objectPool.ReturnObject(gameObject);
	}
}
