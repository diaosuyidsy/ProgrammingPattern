using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Target), typeof(CircleCollider2D))]
public class Collision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("DeathZone")) Destroy(gameObject);
        var target = GetComponent<Target>();
        if (target.Tag == null || target.Tag == "") return;
        if (collision.transform.CompareTag(target.Tag))
        {
            Destroy(gameObject);
        }
    }
}
