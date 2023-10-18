using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 carColorHas = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 carColorNo = new Color32(1, 1, 1, 1);

    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Package")
        {
            if(hasPackage == true)
            {
                Debug.Log("deliver current package first!!");
            }else
            {
                Debug.Log("Package picked up!");
                hasPackage = true;
                spriteRenderer.color = carColorHas;
                Destroy(other.gameObject, destroyDelay);
            }
        }

        if(other.tag == "goal")
        {
            if(hasPackage == false)
            {
                Debug.Log("Pick up package first!");
            }else
            {
                Debug.Log("package delivered!!");
                hasPackage = false;
                spriteRenderer.color = carColorNo;
            }
        }

    }
}
