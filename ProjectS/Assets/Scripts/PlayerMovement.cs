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



    void OnMove(InputValue value)//检测移动按键是否按下
    {
        
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);


        if (ismoveAble(moveInput))
        {
            this.transform.position += (Vector3)moveInput;
        }
        
    }

    bool ismoveAble(Vector2 moveInput)//检测能否移动到下一个地块 条件：1.没有越界 2.是可通行地块
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
