using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
	public float movementSpeed;

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;
	public KeyCode fire;

	IWeapon weapon;

	// Use this for initialization
	void Start()
	{
		weapon = GetComponent<IWeapon>();
	}

	// Update is called once per frame
	void Update()
	{
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
			weapon.Fire();
		}
	}
}
