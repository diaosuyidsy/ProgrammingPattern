using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProgrammingPattern
{
    public class PlayerController : MonoBehaviour
    {
        public float WalkSpeed = 10f;
        public GameObject BulletPrefab;
        public float BulletSpeed = 10f;

        private Rigidbody2D _rb;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            _checkMovementControl();
        }

        private void _checkMovementControl()
        {
            float hori = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");

            _rb.velocity = new Vector2(hori * WalkSpeed, vert * WalkSpeed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GameObject bullet = Instantiate(BulletPrefab, transform.position, Quaternion.identity);
                if (!Mathf.Approximately(_rb.velocity.magnitude, 0f))
                    bullet.GetComponent<Rigidbody2D>().velocity = _rb.velocity.normalized * BulletSpeed;
                else
                    bullet.GetComponent<Rigidbody2D>().velocity = transform.up * BulletSpeed;
            }

        }
    }
}

