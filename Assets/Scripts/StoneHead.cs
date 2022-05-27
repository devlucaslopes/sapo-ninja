using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneHead : MonoBehaviour
{
    [SerializeField] private float Delay;
    [SerializeField] private Transform Point;

    private Rigidbody2D body;
    private Animator anim;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(Point.position, -Vector2.up);

        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            body.bodyType = RigidbodyType2D.Dynamic;
            body.gravityScale = 3f;
            Destroy(gameObject, 3f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<Player>().OnHit();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(Point.position, -Vector2.up);
    }
}
