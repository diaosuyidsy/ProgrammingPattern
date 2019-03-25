using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GPP;
public class BossMain : MonoBehaviour
{
	private readonly SerialTasks _game = new SerialTasks();

	// Start is called before the first frame update
	void Start()
	{
		_game.Add(new ShootOutTask());
	}

	private void Update()
	{
		_game.Update();
	}
}
