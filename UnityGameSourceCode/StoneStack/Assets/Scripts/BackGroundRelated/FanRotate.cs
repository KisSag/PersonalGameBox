using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotate : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D myRigi;
    void Start()
    {
        myRigi = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigi.AddTorque(-1f);
    }
}
