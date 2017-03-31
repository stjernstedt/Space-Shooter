using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
	public Vector2 direction;
	public float moveSpeed;
	float despawnOffset;

	ObjectPool objectPool;

	// Use this for initialization
	void Start()
	{
		objectPool = FindObjectOfType<ObjectPool>();
		despawnOffset = 6f;
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(direction.normalized * moveSpeed * Time.deltaTime, Space.World);

		if (transform.position.y > Camera.main.rect.height + despawnOffset || transform.position.y < -Camera.main.rect.height - despawnOffset)
		{
			objectPool.ReturnObject(gameObject);
		}
	}

}
