using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class JumpAndDoubleJump : MonoBehaviour
{
    [SerializeField] private bool CanDoubleJump;
    [SerializeField] private Rigidbody2D Body;
    [SerializeField] private FloatReference JumpForce;
    [SerializeField] private Animator Anim;

    private readonly int PLATFORM_LAYER = 3;
    private bool IsJumping;
    private Vector2 JumpImpulse;


    private void Awake()
    {
        JumpImpulse = Vector2.up * JumpForce;
    }

    private void Update()
    {
        OnJump();
    }

    public void OnJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!IsJumping)
            {
                Body.AddForce(JumpImpulse, ForceMode2D.Impulse);
                Anim.SetInteger("transition", 2);
                IsJumping = true;
                CanDoubleJump = true;
                AudioController.instance.PlaySFX(AudioController.instance.jumpSFX);
            }
            else if (CanDoubleJump)
            {
                Body.AddForce(JumpImpulse, ForceMode2D.Impulse);
                Anim.SetTrigger("doubleJump");
                CanDoubleJump = false;
                AudioController.instance.PlaySFX(AudioController.instance.jumpSFX);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == PLATFORM_LAYER)
        {
            IsJumping = false;
        }
    }
}
