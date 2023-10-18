using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class randomScale : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float randomMax;
    Light2D myLight;
    void Start()
    {
        float randomScale = Random.Range(0.1f, randomMax);
        myLight = GetComponent<Light2D>();

        myLight.intensity = randomScale * 20;
    }

    // Update is called once per frame
}
