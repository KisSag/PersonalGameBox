using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.IMGUI.Controls;
//using UnityEditor.U2D.Path;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class DragNDrop : MonoBehaviour
{
    Vector3 dragOffset;
    Rigidbody2D myRigi;
    bool beenSelected = false;
    int roo;

    PlayerInput playin;
    void Start()
    {
        myRigi = this.GetComponent<Rigidbody2D>();
        myRigi.gravityScale = 0;

        myRigi.velocity = new Vector3(0, 0, 0);

        playin = GetComponent<PlayerInput>();

        playin.DeactivateInput();

    }

    void Update()
    {
        rotate();
        
    }

    void OnMouseDown()
    {

        //myRigi.freezeRotation = true;
        //gameObject.tag = "RockMoving";
        playin.ActivateInput();
        gameObject.layer = LayerMask.NameToLayer("MovingObject");
        myRigi.gravityScale = 3;
        dragOffset = transform.position - getMousePos();
        beenSelected = true;
    }

    void OnMouseUp()
    {
        //myRigi.freezeRotation = false;
        playin.DeactivateInput();
        gameObject.tag = "Rock";
        gameObject.layer = LayerMask.NameToLayer("ColliderableObject");
        myRigi.velocity = Vector3.zero;
        beenSelected = false;
    }

    void OnRotate(InputValue value)
    {
        roo = Convert.ToInt16(value.Get<float>());
        //Debug.Log(value);
    }

    void rotate()
    {

        //myRigi.AddTorque(0.5f * myRigi.mass * roo);

        
        if (beenSelected)
        {
            myRigi.AddTorque(0.5f * myRigi.mass * roo);
            //Debug.Log(roo);
        }
        
        
    }

    void OnMouseDrag()
    {

        myRigi.velocity = (getMousePos() + dragOffset - transform.position) * 2;
        //transform.position = getMousePos() + dragOffset;
    }

    Vector3 getMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        mousePos.z = 0;
        return mousePos;
    }
}
