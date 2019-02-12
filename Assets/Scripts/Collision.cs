using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Target), typeof(CircleCollider2D))]
public class Collision : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.CompareTag("DeathZone"))
		{
			var enemyMain = GetComponent<EnemyMain>();
			if (enemyMain != null)
				GetComponent<EnemyMain>().DestroySelf();
			else
				Destroy(gameObject);
		}
		var target = GetComponent<Target>();
		if (target.Tag == null || target.Tag == "") return;
		if (collision.transform.CompareTag(target.Tag))
		{
			var enemyMain = GetComponent<EnemyMain>();
			if (enemyMain != null)
				GetComponent<EnemyMain>().DestroySelf();
			else
				Destroy(gameObject);
		}
	}
}
