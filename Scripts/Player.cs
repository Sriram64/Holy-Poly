using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public float MovementSpeed = 5f;
    public float JumpSpeed = 5f;
    bool isFacingRight = true;

    Rigidbody2D Body;
    Collider2D myCollider;


    // Start is called before the first frame update
    void Start()
    {
        Body = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        float playerControl = Input.GetAxisRaw("Horizontal");
        Vector2 playerSpeed = new Vector2(playerControl * MovementSpeed, Body.velocity.y);
        Body.velocity = playerSpeed;

        if (playerControl < 0 && isFacingRight) { FlipSprite(); }
        if (playerControl > 0 && !isFacingRight) { FlipSprite(); }
    }

    private void Jump()
    {
        if(!myCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Body.velocity = Vector2.up * JumpSpeed;
        }

    }

    private void FlipSprite()
    {
        isFacingRight = !isFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
