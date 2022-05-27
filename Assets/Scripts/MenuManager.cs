using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject ControlsPanel;
    [SerializeField] GameObject MenuPanel;
    public void StartGame()
    {
        MenuPanel.SetActive(false);
        ControlsPanel.SetActive(true);

        StartCoroutine(StartScene());

        
    }

    IEnumerator StartScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
