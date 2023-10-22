using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


[CreateAssetMenu]
public class GroundTileData : ScriptableObject
{

    public TileBase[] GroundTiles;

    public float walkingSpeed;//standard 1 = 100%, which means full speed;


    public bool isWalkable;//if the tile can be walk through

    public string tilename;//地块的名字
    public string description;//地块的描述

    public float isSafe;//is tile is consider fully safe
    public float brightmultiplier;//光亮度乘数，地块的光亮度 = 环境光亮度 * 地块光亮度乘数 range = 0-1;
    public float wetness;//潮湿度， 1 = fully wet， 0 is dry

   

}

