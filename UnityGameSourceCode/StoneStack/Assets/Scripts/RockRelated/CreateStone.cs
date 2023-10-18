using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CreateStone : MonoBehaviour
{
    [SerializeField] GameObject itemGenerated;
    [SerializeField] gameBegin controlCenter;


    bool iSOnSpawing = false;
    CircleCollider2D mycircleCollider;

    void Start()
    {
        mycircleCollider = this.GetComponent<CircleCollider2D>();
        iSOnSpawing = false;
    }
    void OnGenerate()
    {
        if (!iSOnSpawing && controlCenter.gamestarting == false) {
            Instantiate(itemGenerated, transform.position, Quaternion.identity);
            iSOnSpawing = true;

        }

        //Debug.Log(iSOnSpawing);
        
    }


    void OnTriggerExit2D(Collider2D collision)
    {     
            iSOnSpawing = false;
    }

}
