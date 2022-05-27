using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float timeOn;
    [SerializeField] private float timeOff;

    private bool isOn = true;
    private CircleCollider2D fireCollider;
    private Animator anim;

    void Start()
    {
        fireCollider = GetComponent<CircleCollider2D>();
        anim = GetComponent<Animator>();

        StartCoroutine(ToggleFire());
    }

    IEnumerator ToggleFire()
    {
        fireCollider.enabled = isOn;
        anim.SetBool("isOn", isOn);

        if (isOn)
        {
            yield return new WaitForSeconds(timeOn);
        } else
        {
            yield return new WaitForSeconds(timeOff);
        }

        isOn = !isOn;

        StartCoroutine(ToggleFire());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<Player>().OnHit();
        }
    }
}
