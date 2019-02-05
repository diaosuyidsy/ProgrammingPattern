using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Target), typeof(MoveToTarget), typeof(Collision))]
[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D))]
public class RandomRunner : MonoBehaviour
{
    float Range = 3f;
    float WanderInterval = 1f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("_setRandomTarget", 0.1f, WanderInterval);
        GetComponent<SpriteRenderer>().color = Color.black;
    }

    private void _setRandomTarget()
    {
        float x = transform.position.x + Random.Range(-Range, Range);

        float y = transform.position.y + Random.Range(-Range, Range);
        var target = GetComponent<Target>();
        Debug.Assert(target != null);
        target.Position = new Vector2(x, y);
        target.Tag = "Player";
    }
}
