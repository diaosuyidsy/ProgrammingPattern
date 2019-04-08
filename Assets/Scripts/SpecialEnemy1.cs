using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class SpecialEnemy1 : MonoBehaviour
{
	private Tree<SpecialEnemy1> _tree;
	public GameObject Player;
	public float Speed;
	public float Range;

	private float timeToChangeDirection = 1.5f;
	private void Start()
	{
		_tree = new Tree<SpecialEnemy1>(new Selector<SpecialEnemy1>(
			new Sequence<SpecialEnemy1>(
				new IsPlayerInRange(),
				new Attack()
				),
			new Sequence<SpecialEnemy1>(
				new Wonder()
				)
			));
	}

	private void Update()
	{
		_tree.Update(this);
	}

	private void WonderAround()
	{
		timeToChangeDirection -= Time.deltaTime;

		if (timeToChangeDirection <= 0)
		{
			ChangeDirection();
		}

		transform.position += transform.up * Speed * Time.deltaTime;
	}

	private void ChangeDirection()
	{
		float angle = Random.Range(0f, 360f);
		Quaternion quat = Quaternion.AngleAxis(angle, Vector3.forward);
		Vector3 newUp = quat * Vector3.up;
		newUp.z = 0;
		newUp.Normalize();
		transform.up = newUp;
		timeToChangeDirection = 1.5f;
	}

	private void AttackPlayer()
	{
		transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * Speed);
	}

	private class Attack : Node<SpecialEnemy1>
	{
		public override bool Update(SpecialEnemy1 context)
		{
			context.AttackPlayer();
			return true;
		}
	}

	private class IsPlayerInRange : Node<SpecialEnemy1>
	{
		public override bool Update(SpecialEnemy1 enemy)
		{
			var playerPos = enemy.Player.transform.position;
			var enemyPos = enemy.transform.position;
			return Vector3.Distance(playerPos, enemyPos) < enemy.Range;
		}
	}

	private class Wonder : Node<SpecialEnemy1>
	{
		public override bool Update(SpecialEnemy1 context)
		{
			context.WonderAround();
			return true;
		}
	}

	private class Idle : Node<SpecialEnemy1>
	{
		public override bool Update(SpecialEnemy1 context)
		{
			return true;
		}
	}
}
