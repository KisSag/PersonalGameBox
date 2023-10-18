using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusNodePosition : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject objectFollow;

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(this.transform.position.x, objectFollow.transform.position.y);
    }
}
