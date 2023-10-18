using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinPickup : MonoBehaviour
{

    [SerializeField] AudioClip coinPickupSFX;
    [SerializeField] int point = 100;

    bool pickcoolDown = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && pickcoolDown == false)
        {
            pickcoolDown = true;
            FindObjectOfType<gameSession>().addToScore(point);
            AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);
            Destroy(gameObject);
        }
    }

    
}
