using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
    public GameObject BulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        _AddRandomBehaviorScript();
    }

    private void _AddRandomBehaviorScript()
    {
        Type[] behaviorComponents = { typeof(FIrer), typeof(Chaser) };
        gameObject.AddComponent(Utility.GetRandomElement(behaviorComponents));
    }


}
