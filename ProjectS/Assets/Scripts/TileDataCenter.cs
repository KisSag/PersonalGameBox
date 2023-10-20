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




    ////////////////////////////////////////���µķ������Է��صؿ�ĸ�����Ϣ//////////////////////////////////////



    public string getName(TileBase tile)//��ȡ����
    {
        return TileDATA[tile].tilename;
    }

    public string getDescription(TileBase tile)//��ȡ����
    {
        return TileDATA[tile].description;
    }

    public bool getSafe(TileBase tile)//�Ƿ�ȫ(Ŀǰ��ȫ�Ķ������Ƿ��ˢ��)
    {
        return TileDATA[tile].isSafe;
    }

    public bool isWalkable(TileBase tile)//�Ƿ������
    {
        return TileDATA[tile].isWalkable;
    }

    public float getSpeed(TileBase tile)//��ȡ�ٶ�
    {
        return TileDATA[tile].walkingSpeed;
    }

}
