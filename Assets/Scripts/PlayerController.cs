using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Target), typeof(MoveToTarget))]
public class PlayerController : MonoBehaviour
{
	public float WalkSpeed = 10f;
	public GameObject BulletPrefab;
	public float BulletSpeed = 10f;

	private Rigidbody2D _rb;

	private void Start()
	{
		_rb = GetComponent<Rigidbody2D>();
		GetComponent<Target>().Position = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		_checkInput();
	}

	private void _checkMovementControl()
	{
		float hori = Input.GetAxis("Horizontal");
		float vert = Input.GetAxis("Vertical");

		_rb.velocity = new Vector2(hori * WalkSpeed, vert * WalkSpeed);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
			if (!Mathf.Approximately(_rb.velocity.magnitude, 0f))
				bullet.GetComponent<Rigidbody2D>().velocity = _rb.velocity.normalized * BulletSpeed;
			else
				bullet.GetComponent<Rigidbody2D>().velocity = transform.up * BulletSpeed;
		}

	}

	private void _checkInput()
	{
		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		var target = GetComponent<Target>();
		Debug.Assert(target != null);
		if (!Mathf.Approximately(0f, horizontal) || !Mathf.Approximately(0f, vertical))
		{
			target.Position.x = transform.position.x + horizontal;
			target.Position.y = transform.position.y + vertical;
		}
		target.Tag = "Enemy";
		if (Input.GetKeyDown(KeyCode.Space))
		{
			GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
			bullet.GetComponent<Bullet>().Shooter = gameObject;
			bullet.GetComponent<Bullet>().Direction = (GetComponent<Target>().Position - transform.position) * BulletSpeed;
		}
	}
}


