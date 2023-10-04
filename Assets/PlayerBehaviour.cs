using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    [SerializeField] private LayerMask groundLayer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 moveVelocity = new Vector3();
        if (Input.GetKey(KeyCode.D))
            moveVelocity.x = speed;
        else if (Input.GetKey(KeyCode.A))
            moveVelocity.x = -speed;

        moveVelocity.y = rb.velocity.y;

        bool onGround = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, groundLayer);
        if (hit.collider != null)
            onGround = true;

        if (onGround)
        {
            float jumpVelocity = 10f;
            if (Input.GetKeyDown("w"))
                moveVelocity.y = jumpVelocity;
        }

        rb.velocity = moveVelocity;
    }
}
