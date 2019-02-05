using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Target), typeof(EnemyMain))]
public class Shoot : MonoBehaviour
{
    public float Interval = 3f;
    private void _shoot()
    {
        var main = GetComponent<EnemyMain>();
        GameObject bullet = Instantiate(main.BulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().Direction = GetComponent<Target>().Position - transform.position;
        bullet.GetComponent<Bullet>().Shooter = gameObject;
    }

    private void Start()
    {
        InvokeRepeating("_shoot", 0f, Interval);
    }
}
