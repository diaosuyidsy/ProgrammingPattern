using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Target), typeof(MoveToTarget), typeof(Collision))]
[RequireComponent(typeof(SpriteRenderer))]
public class Chaser : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindWithTag("Player");
        var target = GetComponent<Target>();
        Debug.Assert(target != null);

        target.Position = player.transform.position;
        target.Tag = player.tag;
    }
}
