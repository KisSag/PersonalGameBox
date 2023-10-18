using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCemera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    //this thing position should follow the main object

    // Update is called once per frame
    void Update()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0,0,-10);
    }
}
