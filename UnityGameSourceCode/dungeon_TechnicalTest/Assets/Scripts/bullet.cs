using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    Rigidbody2D myrigi;
    [SerializeField] float bulletSpeed;
    GameObject player;
    float bulletDirection;
    void Start()
    {
        myrigi = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        bulletDirection = player.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        myrigi.velocity = new Vector2(bulletSpeed * bulletDirection, 0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemies")
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }

}
