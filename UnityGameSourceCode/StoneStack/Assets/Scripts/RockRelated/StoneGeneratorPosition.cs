using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGeneratorPosition : MonoBehaviour
{
    [SerializeField] GameObject objectFollow;
    [SerializeField] float height;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x, objectFollow.transform.position.y + height);
    }
}
