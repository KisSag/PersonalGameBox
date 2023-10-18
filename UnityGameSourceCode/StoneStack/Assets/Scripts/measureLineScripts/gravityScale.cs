using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityScale : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 0;
            //Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), collision.gameObject.GetComponent<Collider2D>(), false);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            this.GetComponent<Rigidbody2D>().gravityScale = 3;
        }
    }
}
