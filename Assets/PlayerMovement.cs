﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Editor Game object links
    public Rigidbody2D rigBody;
    public BoxCollider2D groundCollider;
    //end** Editor Game object links **end

    [SerializeField]
    private bool grounded;
    
    public float jumpForce = 7.75f;
    public ForceMode2D jumpMode = ForceMode2D.Impulse;

    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
           
    }

    void FixedUpdate()
    {
        
       
    }

    public void Jump()
    {
        if (grounded == true)
        {
            rigBody.AddForce(jumpForce * Vector2.up, jumpMode);
            grounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (grounded == false)
        {
            if(collision.tag.ToString() == "ground")

            grounded = true;
        }    
    }



}
