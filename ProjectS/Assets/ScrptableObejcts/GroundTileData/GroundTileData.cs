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

    public string tilename;//�ؿ������
    public string description;//�ؿ������

    public float isSafe;//is tile is consider fully safe
    public float brightmultiplier;//�����ȳ������ؿ�Ĺ����� = ���������� * �ؿ�����ȳ��� range = 0-1;
    public float wetness;//��ʪ�ȣ� 1 = fully wet�� 0 is dry

   

}

