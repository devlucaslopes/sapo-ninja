using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private int Speed;
    [SerializeField] private int JumpForce;
    [SerializeField] private int KnockbackForce;
    [SerializeField] private Animator animator;
    [SerializeField] private float HitCooldown;

    private Rigidbody2D body;

    public bool isJumping;
    private Vector2 knockbackImpulse;
    private bool isAppearing;
    private bool isDesappearing;
    private float hitCounter;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        knockbackImpulse = Vector2.up * KnockbackForce;
        isAppearing = true;
    }

    private void Update()
    {
        hitCounter += Time.deltaTime;

        if (isAppearing)
        {
            animator.SetTrigger("appear");
            isAppearing = false;
        }
    }

    private void FixedUpdate()
    {
        if (!isAppearing && !isDesappearing)
        {
            OnMove();
        }
    }

    private void OnMove()
    {
        float direction = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(direction * Speed, body.velocity.y);

        if (direction > 0)
        {
            if (!isJumping)
            {
                animator.SetInteger("transition", 1);
            }

            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        
        if (direction < 0)
        {
            if (!isJumping)
            {
                animator.SetInteger("transition", 1);
            }

            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (direction == 0 && !isJumping)
        {
            animator.SetInteger("transition", 0);
        }
    }

    public void OnHit()
    {
        body.AddForce(knockbackImpulse, ForceMode2D.Impulse);

        if (hitCounter >= HitCooldown)
        {
            animator.SetTrigger("hit");
            Health.instance.LostLife();
            hitCounter = 0f;
        }


    }

    public void LevelCompleted()
    {
        body.velocity = Vector2.zero;
        animator.SetTrigger("desappear");
        isDesappearing = true;
    }
}
