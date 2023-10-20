using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileDataCenter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ConnectTileAndData connectAction;
    Dictionary<TileBase, GroundTileData> TileDATA;

    public void addDATA(Dictionary<TileBase, GroundTileData> TA)
    {
        TileDATA = TA;
        //Debug.Log(TileDATA);
    }

    // Update is called once per frame




    ////////////////////////////////////////以下的方法可以返回地块的各种信息//////////////////////////////////////



    public string getName(TileBase tile)//获取名字
    {
        return TileDATA[tile].tilename;
    }

    public string getDescription(TileBase tile)//获取描述
    {
        return TileDATA[tile].description;
    }

    public bool getSafe(TileBase tile)//是否安全(目前安全的定义是是否会刷怪)
    {
        return TileDATA[tile].isSafe;
    }

    public bool isWalkable(TileBase tile)//是否可行走
    {
        return TileDATA[tile].isWalkable;
    }

    public float getSpeed(TileBase tile)//获取速度
    {
        return TileDATA[tile].walkingSpeed;
    }

}
