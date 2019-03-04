using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
	public EnemyManager Manager { get; set; }
	public GameObject BulletPrefab;
	public int PointValue = 5;
	// Start is called before the first frame update
	void Start()
	{
		_AddRandomBehaviorScript();
	}

	private void _AddRandomBehaviorScript()
	{
		Type[] behaviorComponents = { typeof(FIrer), typeof(Chaser), typeof(RandomRunner) };
		gameObject.AddComponent(Utility.GetRandomElement(behaviorComponents));
	}

	public void DestroySelf()
	{
		EventManager.Instance.TriggerEvent(new EnemyDied(PointValue));
		Manager.Destroy(this);
	}
}
