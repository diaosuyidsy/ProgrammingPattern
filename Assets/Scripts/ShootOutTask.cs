using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GPP;

public class ShootOutTask : Task
{
	private readonly SerialTasks _tasks = new SerialTasks();

	private List<GameObject> _bullets;

	public ShootOutTask()
	{
	}

	protected override void Init()
	{
		Debug.Log("Starting Init");

		_bullets = new List<GameObject>();

		_tasks.Add(new DO(() =>
		{
			if (_bullets.Count < 5)
			{
				CreatBullet();
			}
		}));
	}

	internal override void Update()
	{
		_tasks.Update();
	}

	private void CreatBullet()
	{
		Debug.Log("Create Bullet");
		var bullet = (GameObject)Resources.Load("Prefabs/BulletPrefab", typeof(GameObject));
		GameObject b = Object.Instantiate(bullet, Vector3.zero, Quaternion.identity) as GameObject;
		_bullets.Add(b);
		b.GetComponent<Bullet>().Direction = new Vector3(0, 1);
	}
}
