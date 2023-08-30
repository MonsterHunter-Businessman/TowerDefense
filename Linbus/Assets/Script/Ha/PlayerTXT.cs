using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTXT : MonoBehaviour
{

    public int score;

    public TextMeshProUGUI scoreTxt;

    public GameObject gameTxt;


    void Start()
    {

        Time.timeScale = 1;

        gameTxt.gameObject.SetActive(false);
    }

    public void Update()
    {
        scoreTxt.text = "Ÿ�� ü�� : " + score.ToString();

        if (score == 0)
        {

            scoreTxt.color = Color.red;

            Time.timeScale = 0;

            gameTxt.gameObject.SetActive(true);
        }

    }
}
