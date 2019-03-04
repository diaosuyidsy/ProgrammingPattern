using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
	private Text _scoreText;
	private int _score;

	private void Awake()
	{
		_scoreText = GetComponent<Text>();
	}

	private void OnEnable()
	{
		EventManager.Instance.AddHandler<EnemyDied>(_onEnemyDied);
	}

	private void OnDisable()
	{
		EventManager.Instance.RemoveHandler<EnemyDied>(_onEnemyDied);
	}

	private void _onEnemyDied(EnemyDied ed)
	{
		_score += ed.PointValue;
		_scoreText.text = _score.ToString();
	}
}
