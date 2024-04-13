using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GFX;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.3f;
    [SerializeField] private float jumpTime = 0.3f;
    [SerializeField] private float height = 2.5f;

    public bool isGrounded = false;
    public bool isJumping = false;
    private float jumpTimer;
    public Animator animator;

    private void Update()
    {
        Jump();
        Crouch();

        if (isGrounded)
        {
            animator.SetBool("IsJumping", false);
        }

        if (!isGrounded)
        {
            animator.SetBool("IsJumping", true);
        }

        //if (height < 2.5f)
        //{
        //    animator.SetBool("IsCrouching", true)
        //}

        //if (height >= 2.5f)
        //{
        //    animator.SetBool("IsCrouching", false)
        //}
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        if (isGrounded && Input.GetKeyDown(KeyCode.W))
        {
            isJumping = true;
            rb.velocity = Vector2.up * jumpForce;
        }

        if (isJumping && Input.GetKey(KeyCode.W))
        {
            if (jumpTimer < jumpTime)
            {
                rb.velocity = Vector2.up * jumpForce;

                jumpTimer += Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            isJumping = false;
            jumpTimer = 0;
        }
    }

    //private void Crouch()
    //{
    //    if (isGrounded && Input.GetKey(KeyCode.S))
    //    {
    //        //animator.SetBool("IsCrouching", true)
    //        Vector3 newPosition = transform.position - new Vector3(0, 0.35f, 0);
    //        GFX.position = newPosition;
    //        GFX.localScale = new Vector3(GFX.localScale.x, height * 0.5f, GFX.localScale.z);


    //        if (isJumping)
    //        {
    //            //animator.SetBool("IsCrouching", false)
    //            GFX.localScale = new Vector3(GFX.localScale.x, height, GFX.localScale.z);
    //        }
    //    }

    //    if (Input.GetKeyUp(KeyCode.S))
    //    {
    //        //animator.SetBool("IsCrouching", false)
    //        GFX.localScale = new Vector3(GFX.localScale.x, height, GFX.localScale.z);
    //    }
    //}

    private void Crouch()
    {
        if (isGrounded)
        {
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("IsCrouching", true);

                Vector3 newPosition = transform.position - new Vector3(0, 0.35f, 0);
                GFX.position = newPosition;
                GFX.localScale = new Vector3(GFX.localScale.x, height * 0.5f, GFX.localScale.z);
            }
            else
            {
                animator.SetBool("IsCrouching", false);
                GFX.localScale = new Vector3(GFX.localScale.x, height, GFX.localScale.z);
            }
        }
    }

}
