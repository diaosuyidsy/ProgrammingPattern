using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager
{
	public GameObject GameStartButton;
	public Main mainscript;
	private FSM<StateManager> _fsm;

	public StateManager(Main _main, GameObject _gsb)
	{
		mainscript = _main;
		GameStartButton = _gsb;
		init();
	}

	private void init()
	{
		_fsm = new FSM<StateManager>(this);

		_fsm.TransitionTo<Prestart>();

	}

	public void ChangeBackgroundColor(Color color)
	{
		Camera.main.backgroundColor = color;
	}

	public void ShowGameStartButton()
	{
		GameStartButton.SetActive(true);
	}

	public void StartGame()
	{
		mainscript.GameStart();
		GameStartButton.SetActive(false);

	}

	public void EndGame()
	{
		mainscript.GameEnd();
	}

	public void EraseEnemies()
	{
		var bullets = GameObject.FindGameObjectsWithTag("Bullet");
		var enemies = GameObject.FindGameObjectsWithTag("Enemy");
		foreach (var b in bullets)
		{
			GameObject.Destroy(b);
		}
		foreach (var e in enemies)
		{
			GameObject.Destroy(e);
		}
	}

	public bool ClickedRestart()
	{
		if (Input.GetKeyDown(KeyCode.R))
			return true;
		return false;
	}

	public bool ClickedStartButton()
	{
		if (Input.GetMouseButtonUp(0))
		{
			var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			if (Vector2.Distance(pos, GameStartButton.transform.position) < 2f) return true;
		}
		return false;
	}

	public void Update()
	{
		_fsm.Update();
	}
}

public class GameState : FSM<StateManager>.State
{

}

public class Prestart : GameState
{
	public override void OnEnter()
	{
		Context.ChangeBackgroundColor(Color.yellow);
		Context.ShowGameStartButton();
	}

	public override void Update()
	{
		if (Context.ClickedStartButton())
		{
			TransitionTo<Playing>();
			return;
		}
	}
}

public class Playing : GameState
{
	private float time = 10f;
	public override void OnEnter()
	{
		Context.StartGame();
		Context.ChangeBackgroundColor(Color.white);
		this.time = 10f;
	}

	public override void Update()
	{
		time -= Time.deltaTime;
		if (time <= 0f) TransitionTo<Ended>();
	}
}

public class Ended : GameState
{
	public override void OnEnter()
	{
		Context.EndGame();
		Context.ChangeBackgroundColor(Color.black);
		Context.EraseEnemies();
	}

	public override void Update()
	{
		if (Context.ClickedRestart())
		{
			TransitionTo<Prestart>();
		}
	}
}
