using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int Lifes;
    [SerializeField] private GameObject[] LifeIcons;

    public static Health instance;

    void Start()
    {
        instance = this;

       for(int index  = 0; index < LifeIcons.Length; index++)
        {
            LifeIcons[index].SetActive(true);
        }
    }

    public void LostLife()
    {
        Lifes--;
        LifeIcons[Lifes].SetActive(false);

        if (Lifes <= 0)
        {
            GameController.instance.ShowGameOver();
        }
    }
}
