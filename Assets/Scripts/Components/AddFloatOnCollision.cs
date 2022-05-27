using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddFloatOnCollision : MonoBehaviour
{
    [SerializeField] float Increment;
    [SerializeField] FloatVariable Value;
    [SerializeField] string Tag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tag))
        {
            Value.Increment(Increment);
        }
    }
}
