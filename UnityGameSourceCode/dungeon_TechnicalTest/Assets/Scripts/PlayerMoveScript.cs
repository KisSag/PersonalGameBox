using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveScript : MonoBehaviour
{

    Vector2 moveInput;
    Rigidbody2D myRigibody;
    [SerializeField] float moveSpeed = 0f;
    [SerializeField] float jumpHeight = 0f;
    [SerializeField] float climbSpeed = 0f;
    [SerializeField] Vector2 deathKick = new Vector2(10f,10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;
    BoxCollider2D myCollider;
    CapsuleCollider2D myfeetCollider;
    Animator myAnimator;

    bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigibody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        myfeetCollider = GetComponent <CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
        {
            Run();
            flipSprite();
            Climb();
            beenKilled();
        }
        
    }

    void Climb()
    {


        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Climbing"))){
            myAnimator.SetBool("isClimbing", myCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")));
            myAnimator.speed = Mathf.Abs(moveInput.y);
            Vector2 climbVelocity = new Vector2(myRigibody.velocity.x, moveInput.y * climbSpeed);
            myRigibody.velocity = climbVelocity;
            myRigibody.gravityScale = 0f;
        }
        else
        {
            myAnimator.SetBool("isClimbing", myCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")));
            myAnimator.speed = 1f;
            myRigibody.gravityScale = 3f;
        }

    }

    void flipSprite()
    {
        bool playerMoving = Mathf.Abs(myRigibody.velocity.x) > Mathf.Epsilon;

        if(playerMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigibody.velocity.x), 1f);
        }
        
    }

    void OnMove(InputValue value)
    {
        if (!alive)
        {
            return;
        }
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
        
    }

    void OnFire(InputValue value)
    {
        if (!alive)
        {
            return;
        }

        Instantiate(bullet, gun.position, transform.rotation);
    }

    void OnJump(InputValue value)
    {

        if (!alive)
        {
            return;
        }

        if (value.isPressed && isOnTheGround())
        {
            myRigibody.velocity += new Vector2(0f, jumpHeight);
        }

    }

    bool isOnTheGround()
    {
        return myfeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground"));
    }

    void beenKilled()
    {
        if (myCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "SwordTile")))
        {
            alive = false;
            myAnimator.SetTrigger("isDead");
            myRigibody.velocity = deathKick;
            FindObjectOfType<gameSession>().ProcessPlayerDeath();
        }
    }
    void Run()
    {
        Vector2 palyerVelocity = new Vector2(moveInput.x * moveSpeed, myRigibody.velocity.y);
        myRigibody.velocity = palyerVelocity;

        myAnimator.SetBool("isRunning", myRigibody.velocity.x != 0);

    }
}
