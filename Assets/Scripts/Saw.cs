using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] private bool isRight;

    void Update()
    {
        float xAxis = transform.position.x;
        float yAxis = transform.position.y;
        float zAxis = transform.position.z;

        Vector3 direction;
        Vector3 angle;

        if (isRight)
        {
            angle = new Vector3(0, 180, 0);
            direction = new Vector3(xAxis + Speed * Time.deltaTime, yAxis, zAxis);
        } else
        {
            angle = Vector3.zero;
            direction = new Vector3(xAxis - Speed * Time.deltaTime, yAxis, zAxis);
        }

        transform.position = direction;
        transform.eulerAngles = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            isRight = gameObject.transform.position.x > 0 ? false : true;
        }

        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().OnHit();
        }
    }
}
