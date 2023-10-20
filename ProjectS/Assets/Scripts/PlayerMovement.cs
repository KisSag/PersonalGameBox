using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Tilemap GroundMap;
    Vector2 moveInput;

    [SerializeField] TileDataCenter tileData;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }



    void OnMove(InputValue value)//����ƶ������Ƿ���
    {
        
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);


        if (ismoveAble(moveInput))
        {
            this.transform.position += (Vector3)moveInput;
        }
        
    }

    bool ismoveAble(Vector2 moveInput)//����ܷ��ƶ�����һ���ؿ� ������1.û��Խ�� 2.�ǿ�ͨ�еؿ�
    {
        Vector3Int tilePos = GroundMap.WorldToCell(this.transform.position + (Vector3)moveInput);
        TileBase tileNext;


        if (!GroundMap.HasTile(tilePos))
        {
            return false;
        }
        else
        {
            tileNext = GroundMap.GetTile(tilePos);
            if (!tileData.isWalkable(tileNext))
            {
                return false;
            }
        }
        return true;
    }
}
