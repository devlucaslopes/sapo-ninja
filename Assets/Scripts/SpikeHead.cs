using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    [SerializeField] private int Speed;
    [SerializeField] private float Radius;
    [SerializeField] private bool isRight;
    [SerializeField] private Transform PointRight;
    [SerializeField] private Transform PointLeft;

    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        OnMove();
        OnCollision();
    }

    void OnMove()
    {
        if (isRight)
        {
            body.velocity = Vector2.right * Speed;
        } else
        {
            body.velocity = Vector2.left * Speed;
        }
    }

    void OnCollision()
    {
        Collider2D hitRight = Physics2D.OverlapCircle(PointRight.position, Radius);
        Collider2D hitLeft = Physics2D.OverlapCircle(PointLeft.position, Radius);

        if (hitRight != null)
        {
            if (hitRight.name == "Border")
            {
                isRight = false;
            }
        }

        if (hitLeft != null)
        {
            if (hitLeft.name == "Ground")
            {
                isRight = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.GetComponent<Player>().OnHit();

        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(PointRight.position, Radius);
        Gizmos.DrawWireSphere(PointLeft.position, Radius);
    }


}
