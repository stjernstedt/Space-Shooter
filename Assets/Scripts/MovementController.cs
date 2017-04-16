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
		EventHandler.WeaponChangedSubscribers += ChangeWeapon;
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
		if (Input.GetMouseButton(0))
		{
			weapon.Fire();
			Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Vector2.Distance(transform.position, target) > 0.1)
			{
				Vector2 pos = transform.position;
				Vector2 dir = target - pos;
				dir = dir.normalized;
				transform.Translate(dir * Time.deltaTime * movementSpeed, Space.World);
			}
		}
	}

	void ChangeWeapon(IWeapon weapon)
	{
		StartCoroutine(WeaponBoost());
		this.weapon = weapon;
	}

	IEnumerator WeaponBoost()
	{
		yield return new WaitForSeconds(5);
		Destroy(GetComponent<Weapon>());
		IWeapon weapon = gameObject.AddComponent<Laser>();
		this.weapon = weapon;
	}
}
