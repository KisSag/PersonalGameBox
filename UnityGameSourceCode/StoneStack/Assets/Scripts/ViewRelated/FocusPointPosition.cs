using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FocusPointPosition : MonoBehaviour
{
    
    [SerializeField] GameObject focusNode;
    [SerializeField] float radiousLimit;
    float xDifference;
    float yDifference;
    Vector3 mousPosWorld;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousPosWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());


        xDifference = (mousPosWorld.x - focusNode.transform.position.x) / 2;
        yDifference = (mousPosWorld.y - focusNode.transform.position.y) / 2;

        if(Mathf.Abs(xDifference) > radiousLimit * 0.2f)
        {
            xDifference = radiousLimit * Mathf.Sign(xDifference) * 0.2f;
        }

        if(Mathf.Abs(yDifference) > radiousLimit)
        {
            yDifference = radiousLimit * Mathf.Sign(yDifference);
        }

        this.transform.position = new Vector2(focusNode.transform.position.x + xDifference, focusNode.transform.position.y + yDifference);
    }
}
