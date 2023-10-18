using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class gameBegin : MonoBehaviour
{

    [SerializeField] CanvasGroup myUIGruop;
    [SerializeField] TextMeshProUGUI resumeButton;
    public bool gamestarting = true;
    void Awake()
    {
        gamestarting = true;
    }

    void Update()
    {
        checkESC();
    }

    public void gameOnRun()
    {
        gamestarting = false;
        myUIGruop.alpha = 0;
        Time.timeScale = 1;
        myUIGruop.interactable = false;
        //Debug.Log("disable");
    }

    public void quit()
    {
        Application.Quit();
        //UnityEditor.EditorApplication.isPlaying = false;
    }

    void checkESC()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            if(myUIGruop.interactable == false)
            {
                pauseTheGame();
            }
        }
    }

    void pauseTheGame()
    {
        myUIGruop.alpha = 1;
        Time.timeScale = 0;
        myUIGruop.interactable = true;
        resumeButton.text = "Resume";
        //Debug.Log(value);
    }
    
}
