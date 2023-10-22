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


    //����UI
    [SerializeField] TextMeshProUGUI titleText;
    [SerializeField] TextMeshProUGUI DescriptionText;
    [SerializeField] TextMeshProUGUI weatherText;
    [SerializeField] TextMeshProUGUI temperatureText;
    [SerializeField]
    TextMeshProUGUI environmentSaftyText;
    [SerializeField]
    TextMeshProUGUI walkEffeciencyText;
    [SerializeField]
    TextMeshProUGUI wetnessText;
    [SerializeField]
    TextMeshProUGUI brightnessText;


    TileBase currentTile;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTile = playerLocation.getCurrentTile();
        //Debug.Log(currentTile);

        //������Ϣ
        displayTile(currentTile);
        displayDescription(currentTile);
        displayWalkEffeciency(currentTile);
        displayWetness(currentTile);
        displaySafty(currentTile);
    }

    void displayWetness(TileBase currentTile)
    {
        wetnessText.text = "��ʪ�ȣ�" + tileData.getWetness(currentTile);
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

    void displayWalkEffeciency(TileBase currentTile)
    {
        walkEffeciencyText.text = "ͨ��Ч�ʣ�" + tileData.getSpeed(currentTile);
    }

    void displaySafty(TileBase currentTile)
    {
        environmentSaftyText.text = "Σ�նȣ�" + tileData.getSafe(currentTile);
    }
}
