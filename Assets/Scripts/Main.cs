﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
	public int numEnemies = 30;
	public int batch = 2;
	private readonly EnemyManager _manager = new EnemyManager();

	// Start is called before the first frame update
	void Start()
	{
		StartCoroutine(GenerateEnemies(2f));
	}

	IEnumerator GenerateEnemies(float time)
	{
		while (true)
		{
			yield return new WaitForSeconds(time);

			for (int i = 0; i < batch && _manager.Population < numEnemies; i++)
			{
				var enemy = _manager.Create();
				var randomPosition = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
				randomPosition.z = 0f;
				enemy.transform.position = randomPosition;
			}
		}
	}

}