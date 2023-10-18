using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update]
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D myrigidbody;
    BoxCollider2D collusionTrigger;
    GameObject slim;
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        collusionTrigger = GetComponent<BoxCollider2D>();
        slim = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        myrigidbody.velocity = new Vector2(moveSpeed, myrigidbody.velocity.y);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        moveSpeed = -moveSpeed;
        flipFace();
    }

    void flipFace()
    {
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }
}
