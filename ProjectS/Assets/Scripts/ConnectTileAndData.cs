using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class ConnectTileAndData : MonoBehaviour
{

    [SerializeField] Tilemap GroundMap;
    [SerializeField] List<GroundTileData> GroundTileDatas;

    private Dictionary<TileBase, GroundTileData> DataDictionaryOfTile;
    void Awake()
    {
        addDataToTiles();
    }

    // Update is called once per frame
    void Update()
    {
        tileInfoDebuger();
    }



    void addDataToTiles()//这个方法为每个Tile添加了数据
    {
        DataDictionaryOfTile = new Dictionary<TileBase, GroundTileData>();

        foreach (var GroundTileData in GroundTileDatas)
        {
            foreach (var tile in GroundTileData.GroundTiles)
            {
                DataDictionaryOfTile.Add(tile, GroundTileData);
            }
        }
    }

    void tileInfoDebuger()//this is the method to check the data of tiles
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPos = GroundMap.WorldToCell(mousePos);

            TileBase clickedTile = GroundMap.GetTile(gridPos);

            Debug.Log(gridPos + " " + clickedTile + " " + DataDictionaryOfTile[clickedTile].isSafe);
        }
    }

    public bool isWalkable(TileBase tile)
    {
        return DataDictionaryOfTile[tile].isWalkable;
    }
}
