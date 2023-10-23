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


    
    public void OnMove(InputAction.CallbackContext ctx)//����ƶ������Ƿ���
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

    public TileBase getCurrentTile()//���ص�ǰ�ĵؿ�
    {
        Vector3Int tilePos = GroundMap.WorldToCell(this.transform.position);
        TileBase currentTile = GroundMap.GetTile(tilePos);
        //Debug.Log(currentTile);

        return currentTile;
    }
}
