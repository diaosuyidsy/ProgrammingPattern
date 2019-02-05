using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Target), typeof(Collision), typeof(Shoot))]
[RequireComponent(typeof(SpriteRenderer))]
public class FIrer : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindWithTag("Player");
        var target = GetComponent<Target>();
        target.Position = player.transform.position;
        target.Tag = player.tag;
    }
}
