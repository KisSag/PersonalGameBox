using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class gameSession : MonoBehaviour
{

    [SerializeField] int playerAlive = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int score = 0;
    void Awake()
    {

        playerAlive = 3;

        int numOfGameSession = FindObjectsOfType<gameSession>().Length;
        if(numOfGameSession > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        livesText.text = playerAlive.ToString();
        scoreText.text = score.ToString();
    }


    void Update()
    {
        scoreText.text = score.ToString();
    }

    public void addToScore(int point)
    {
        score += point;
    }
    public void ProcessPlayerDeath()
    {
        if(playerAlive > 1)
        {
            takeLive();
        }
        else
        {
            ResetGameSessino();
        }
    }

    void ResetGameSessino()
    {
        FindObjectOfType<ScenePersist>().resetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }

    void takeLive()
    {
        playerAlive -= 1;
        int currSencIndex = SceneManager.GetActiveScene().buildIndex;
        livesText.text = playerAlive.ToString();
        SceneManager.LoadScene(currSencIndex);
    }

}
