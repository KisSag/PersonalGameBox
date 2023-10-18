using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    // Start is called before the first frame update
    float startPos;
    [SerializeField] GameObject m_Camera;
    [SerializeField] float parallaxEffect;
    void Start()
    {
        startPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = m_Camera.transform.position.y * parallaxEffect;
        transform.position = new Vector3(transform.position.x, startPos + distance, transform.position.z);
    }
}
