using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Target), typeof(Speed))]
public class MoveToTarget : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        var target = GetComponent<Target>();
        var speed = GetComponent<Speed>();
        Debug.Assert(target != null);
        transform.position = Vector2.MoveTowards(transform.position, target.Position, speed.value * Time.deltaTime);
    }
}
