using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    void Awake()
    {

        int numOfGamePersist = FindObjectsOfType<ScenePersist>().Length;
        if (numOfGamePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void resetScenePersist()
    {
        Destroy(gameObject);
    }
}
