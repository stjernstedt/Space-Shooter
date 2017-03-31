using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
	public float movementSpeed;
	public float fireRate;

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;
	public KeyCode fire;

	ObjectPool objectPool;

	float timePassed;

	// Use this for initialization
	void Start()
	{
		objectPool = FindObjectOfType<ObjectPool>();
	}

	// Update is called once per frame
	void Update()
	{
		timePassed += Time.deltaTime;
		if (Input.GetKey(up))
		{
			transform.Translate(Vector2.up * Time.deltaTime * movementSpeed, Space.World);
		}
		if (Input.GetKey(down))
		{
			transform.Translate(Vector2.down * Time.deltaTime * movementSpeed, Space.World);
		}
		if (Input.GetKey(left))
		{
			transform.Translate(Vector2.left * Time.deltaTime * movementSpeed, Space.World);
		}
		if (Input.GetKey(right))
		{
			transform.Translate(Vector2.right * Time.deltaTime * movementSpeed, Space.World);
		}
		if (Input.GetKey(fire))
		{
			if(timePassed > fireRate)
			{
				GameObject laser = objectPool.GetLaser();
				laser.transform.position = new Vector2(transform.position.x, transform.position.y + 1f);
				timePassed = 0;
			}
		}
	}
}
