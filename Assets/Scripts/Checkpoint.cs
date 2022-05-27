using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private int nextLevel;

    IEnumerator GoToNextLevel()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextLevel);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.GetComponent<Player>().LevelCompleted();
            StartCoroutine(GoToNextLevel());
        }
    }
}
