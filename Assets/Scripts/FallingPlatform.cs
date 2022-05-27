using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] private float Delay;
    private Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
            Destroy(gameObject, 3f);
        }
    }

    IEnumerator Fall()
    {
        yield return new WaitForSeconds(Delay);
        body.bodyType = RigidbodyType2D.Dynamic;
        body.gravityScale = 2;

    }
}
