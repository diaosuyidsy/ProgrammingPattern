using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Target), typeof(Speed), typeof(Collision))]
public class Bullet : MonoBehaviour
{
    public Vector2 Direction;
    public GameObject Shooter;

    private void Update()
    {
        transform.Translate(Direction * Time.deltaTime * GetComponent<Speed>().value);
        GetComponent<Target>().Tag = Shooter.GetComponent<Target>().Tag;
    }
}
