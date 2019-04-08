using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
public class SpecialEnemy2 : MonoBehaviour
{
	private Tree<SpecialEnemy2> _tree;
	public GameObject Player;
	public float Speed;
	public float Range;

	private float timeToChangeDirection = 1.5f;
	private void Start()
	{
		_tree = new Tree<SpecialEnemy2>(new Selector<SpecialEnemy2>(
			new Sequence<SpecialEnemy2>(
				new IsPlayerInRange(),
				new Wonder()
				),
			new Sequence<SpecialEnemy2>(
				new Attack()
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

	private class Attack : Node<SpecialEnemy2>
	{
		public override bool Update(SpecialEnemy2 context)
		{
			context.AttackPlayer();
			return true;
		}
	}

	private class IsPlayerInRange : Node<SpecialEnemy2>
	{
		public override bool Update(SpecialEnemy2 enemy)
		{
			var playerPos = enemy.Player.transform.position;
			var enemyPos = enemy.transform.position;
			return Vector3.Distance(playerPos, enemyPos) < enemy.Range;
		}
	}

	private class Wonder : Node<SpecialEnemy2>
	{
		public override bool Update(SpecialEnemy2 context)
		{
			context.WonderAround();
			return true;
		}
	}

	private class Idle : Node<SpecialEnemy2>
	{
		public override bool Update(SpecialEnemy2 context)
		{
			return true;
		}
	}
}
