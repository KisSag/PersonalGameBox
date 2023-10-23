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
    [SerializeField] TimeData timeData;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    
    public void OnMove(InputAction.CallbackContext ctx)//检测移动按键是否按下
    {

        moveInput = ctx.ReadValue<Vector2>();
        //Debug.Log(moveInput);

        if (ctx.performed)
        {
            if (ismoveAble(moveInput))
            {
                this.transform.position += (Vector3)moveInput;
                //Debug.Log("move");

                timeData.addMinute(15);

            }
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

    public TileBase getCurrentTile()//返回当前的地块
    {
        Vector3Int tilePos = GroundMap.WorldToCell(this.transform.position);
        TileBase currentTile = GroundMap.GetTile(tilePos);
        //Debug.Log(currentTile);

        return currentTile;
    }
}
