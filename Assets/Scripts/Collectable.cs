using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private GameObject CollectedPrefab;
    [SerializeField] private int Points;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioController.instance.PlaySFX(AudioController.instance.appleSFX);

            GameObject Collected = Instantiate(CollectedPrefab, transform.position, transform.rotation);

            GameController.instance.UpdateScore(Points);

            Destroy(gameObject);
            Destroy(Collected, 1f);
        }
    }
}
