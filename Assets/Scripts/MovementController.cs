using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour
{
	public float movementSpeed;
	public int weaponBoostDuration;

	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;
	public KeyCode fire;

	IWeapon weapon;

	float maxLeft;
	float maxRight;
	float maxUp;
	float maxDown;

	float cameraWidth;
	float cameraHeight;
	float playerWidth;
	float playerHeight;

	// Use this for initialization
	void Start()
	{
		EventHandler.WeaponChangedSubscribers += ChangeWeapon;
		weapon = GetComponent<IWeapon>();

		cameraHeight = Camera.main.orthographicSize;
		cameraWidth = cameraHeight * Camera.main.aspect;
		playerHeight = GetComponent<Collider2D>().bounds.extents.y;
		playerWidth = GetComponent<Collider2D>().bounds.extents.x;

		maxLeft = Camera.main.transform.position.x - cameraWidth + playerWidth;
		maxRight = Camera.main.transform.position.x + cameraWidth - playerWidth;
		maxUp = Camera.main.transform.position.y + cameraHeight - playerHeight;
		maxDown = Camera.main.transform.position.y - cameraHeight + playerHeight;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKey(up))
		{
			if (transform.position.y < maxUp)
				transform.Translate(Vector2.up * Time.deltaTime * movementSpeed, Space.World);
		}
		if (Input.GetKey(down))
		{
			if (transform.position.y > maxDown)
				transform.Translate(Vector2.down * Time.deltaTime * movementSpeed, Space.World);
		}
		if (Input.GetKey(left))
		{
			if (transform.position.x > maxLeft)
				transform.Translate(Vector2.left * Time.deltaTime * movementSpeed, Space.World);
		}
		if (Input.GetKey(right))
		{
			if (transform.position.x < maxRight)
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
			target.y = target.y + 1;
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
		yield return new WaitForSeconds(weaponBoostDuration);
		Destroy(GetComponent<Weapon>());
		IWeapon weapon = gameObject.AddComponent<Laser>();
		this.weapon = weapon;
	}
}
