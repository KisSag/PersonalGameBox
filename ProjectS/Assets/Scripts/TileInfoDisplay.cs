using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;
using System;

public class TileInfoDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] PlayerMovement playerLocation;
    [SerializeField] TileDataCenter tileData;


    //链接UI
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI DescriptionText;

    TileBase currentTile;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTile = playerLocation.getCurrentTile();
        //Debug.Log(currentTile);

        //更新信息
        displayTile(currentTile);
        displayDescription(currentTile);
    }

    void displayDescription(TileBase currentTile)
    {
        DescriptionText.text = tileData.getDescription(currentTile);
    }

    void displayTile(TileBase currentTile)
    {
        //Debug.Log(tileData.getName(currentTile));
        titleText.text = tileData.getName(currentTile);
    }
}
