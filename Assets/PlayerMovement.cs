using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Editor Game object links
    public Rigidbody2D rigBody;
    public BoxCollider2D groundCheckCollider;
    public BoxCollider2D groundCollider;
    public Animator anim;
    //end** Editor Game object links **end

    [SerializeField]
    private bool grounded;

    public float jumpForce = 7.75f;
    public float pushSpeed = 50.0f;
    public float velocity = 0.0f;
    public ForceMode2D jumpMode = ForceMode2D.Impulse;



    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GroundUpdate();
    }

    void GroundUpdate()
    {
        velocity = rigBody.velocity.y;
        anim.SetFloat("Y Velocity", velocity);
        if (!grounded && rigBody.velocity.y < 0.0f)
        {
            if(groundCheckCollider.IsTouching(groundCollider))
            {
                rigBody.velocity.Set(0.0f, 0.0f);
                grounded = true;
            }
            

        }
        anim.SetBool("Grounded", grounded);

    }

    public void Jump()
    {
        if (groundCheckCollider.IsTouching(groundCollider))
        {
            rigBody.AddForce(jumpForce * Vector2.up, jumpMode);
            grounded = false;
        }
    }

    public void MoveHorizontal(int direction)
    {
        /*Vector2 currPos = transform.position;
        currPos += new Vector2(speed*Time.deltaTime, 0.0f);
        transform.position = currPos;*/

        rigBody.AddForce(new Vector2(direction* pushSpeed * Time.deltaTime, 0.0f), ForceMode2D.Impulse);
    }




}
