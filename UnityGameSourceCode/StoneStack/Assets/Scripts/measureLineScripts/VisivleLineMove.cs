using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisivleLineMove : MonoBehaviour
{
    Rigidbody2D myrigi;
    [SerializeField] GameObject followObject;
    [SerializeField] float moveSpeed;
    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myrigi.velocity = new Vector2(moveSpeed * (followObject.transform.position.x - this.transform.position.x), moveSpeed * (followObject.transform.position.y - this.transform.position.y));
    }
}
