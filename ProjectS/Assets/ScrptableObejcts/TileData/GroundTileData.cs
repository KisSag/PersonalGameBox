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
    public bool isSafe;//is tile is consider fully safe
}
