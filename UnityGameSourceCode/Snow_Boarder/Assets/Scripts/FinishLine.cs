using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{

    [SerializeField] float delaytime = 1f;
    [SerializeField] ParticleSystem finishEffect;
    int playonce = 1;

    void OnTriggerEnter2D(Collider2D other)

    {
        if(other.tag == "Player")
        {
            if(playonce > 0)
            {
                finishEffect.Play();
                GetComponent<AudioSource>().Play();
                playonce -= 1;
                Invoke("ReloadScene", delaytime);
            }
            
        }
        
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
