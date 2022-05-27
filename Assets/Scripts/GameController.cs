using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextScore;
    [SerializeField] private GameObject Checkpoint;
    [SerializeField] private GameObject Instructions;
    [SerializeField] private GameObject GameOver;

    private int totalScore;
    private int appleCounts;
    private bool isCompleted;

    public static GameController instance;

    void Start()
    {
        Time.timeScale = 1;

        instance = this;
        appleCounts = GameObject.FindGameObjectsWithTag("Apple").Length;
        TextScore.text = $"00/{appleCounts}";
        StartCoroutine(ShowInstructions());
    }

    private void Update()
    {
        if (!isCompleted && totalScore == appleCounts) {
            isCompleted = true;
            Checkpoint.SetActive(true);
        }
    }

    public void UpdateScore(int points)
    {
        totalScore += points;
        string totalScoreText = totalScore < 10 ? $"0{totalScore}" : $"{totalScore}";

        TextScore.text = $"{totalScoreText}/{appleCounts}";
    }

    IEnumerator ShowInstructions()
    {
        yield return new WaitForSeconds(3f);
        Instructions.SetActive(false);
    }

    public void ShowGameOver()
    {
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        Scene scene = SceneManager.GetActiveScene();

        SceneManager.LoadScene(scene.name);
    }
}
