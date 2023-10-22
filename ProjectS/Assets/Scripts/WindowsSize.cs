using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int width = Screen.width;
        int height = (width / 16) * 10;

        Screen.SetResolution(Screen.width, (Screen.width / 16) * 10, false);
    }
}
