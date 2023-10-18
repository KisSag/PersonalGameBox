using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(loadNextLevel());
        }
        
    }

    IEnumerator loadNextLevel()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        int currScenceIndex = SceneManager.GetActiveScene().buildIndex;
        int nextScenIndex = currScenceIndex + 1;

        if (nextScenIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextScenIndex = 0;
        }

        FindObjectOfType<ScenePersist>().resetScenePersist();
        SceneManager.LoadScene(nextScenIndex);
    }


}
