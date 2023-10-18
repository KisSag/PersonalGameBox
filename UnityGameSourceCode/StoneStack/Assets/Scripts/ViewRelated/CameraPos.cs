using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPos : MonoBehaviour
{
    Rigidbody2D myrigi;
    [SerializeField] GameObject focusPoint;
    [SerializeField] float movSpeed;
    [SerializeField] gameBegin controlCenter;
    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controlCenter.gamestarting)
        {
            this.transform.position = new Vector3(0, 3f, -10f);
        }
        else
        {
            myrigi.velocity = new Vector2((focusPoint.transform.position.x - this.transform.position.x) * movSpeed, (focusPoint.transform.position.y - this.transform.position.y) * movSpeed);
        }
        
    }
}
