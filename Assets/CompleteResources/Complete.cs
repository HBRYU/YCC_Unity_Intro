using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Complete : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private Animator anim;
    private AudioSource _audioSource;

    private bool onGround;

    [SerializeField] private AudioClip stepAudio, jumpAudio;

    [SerializeField] private LayerMask groundLayer;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        Vector3 moveVelocity = new Vector3();
        if (Input.GetKey(KeyCode.D))
        {
            moveVelocity.x = speed;
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveVelocity.x = -speed;
            GetComponent<SpriteRenderer>().flipX = true;
        }

        moveVelocity.y = rb.velocity.y;
        onGround = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 2f, groundLayer);
        if (hit.collider != null)
            onGround = true;

        if (onGround)
        {
            float jumpVelocity = 10f;
            if (Input.GetKeyDown("w"))
            {
                moveVelocity.y = jumpVelocity;
                PlayJumpAudio();
            }
        }
        rb.velocity = moveVelocity;
        
        if(moveVelocity.x != 0f)
            anim.SetBool("running", true);
        else
            anim.SetBool("running", false);
        
        // Alt: anim.SetBool("running", moveVelocity.x != 0f);
    }

    void PlayStepAudio()
    {
        if (!onGround)
            return;
        _audioSource.clip = stepAudio;
        _audioSource.Play();
    }

    void PlayJumpAudio()
    {
        _audioSource.clip = jumpAudio;
        _audioSource.Play();
    }
}
