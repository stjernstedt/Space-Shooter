using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
	protected ObjectPool objectPool;

	protected float timePassed;

	void Start()
	{
		objectPool = FindObjectOfType<ObjectPool>();
	}

	void Update()
	{
		timePassed += Time.deltaTime;
	}
}
