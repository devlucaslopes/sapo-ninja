using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private int JumpForce;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerBody = collision.gameObject.GetComponent<Rigidbody2D>();
            playerBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);

            animator.SetTrigger("jump");
        }
    }
}
