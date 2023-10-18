using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HeightMeasure : MonoBehaviour
{

    [SerializeField] Rigidbody2D myrigibody;
    bool isCollideWithStone = false;

    [SerializeField] TextMeshProUGUI heightScore;
    [SerializeField] GameObject visibleMeasureBar;
    [SerializeField] GameObject basePlatform;
    [SerializeField] int heightScoreMulti;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        move();
        displayHeight();
        //Debug.Log(isCollideWithStone);
    }

    void displayHeight()
    {
        heightScore.text = (((int)((visibleMeasureBar.transform.position.y * heightScoreMulti - basePlatform.transform.position.y * heightScoreMulti) - (0.31 * heightScoreMulti))) - 10).ToString() + "  cm";
    }

    void move()
    {
        if (isCollideWithStone)
        {
            myrigibody.velocity = new Vector2(0, 5f);
        }
        else
        {
            myrigibody.velocity = new Vector2(0, myrigibody.velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Rock")
        {
            isCollideWithStone = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock")
        {
            isCollideWithStone = false;
            myrigibody.gravityScale = 3;
        }
    }



}
