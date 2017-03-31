using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
	public float rotateSpeed;
	float speed;
	float speedOffset = 10f;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
	}

	private void OnEnable()
	{
		bool rotateRight = Random.value < 0.5f;
		if (rotateRight)
		{
			speed = rotateSpeed + Random.Range(0f, speedOffset);
		}
		else
		{
			speed = -rotateSpeed + Random.Range(0f, -speedOffset);
		}
	}
}
