using UnityEngine;

public class EnemyManager : Manager<EnemyMain>
{
	protected override EnemyMain CreateObject()
	{
		var temp = (GameObject)Resources.Load("Prefabs/Enemy", typeof(GameObject));
		var go = GameObject.Instantiate(temp);
		var enemyMain = go.GetComponent<EnemyMain>();
		enemyMain.Manager = this;

		return enemyMain;
	}

	protected override void DestroyObject(EnemyMain obj)
	{
		GameObject.Destroy(obj.gameObject);
	}
}
