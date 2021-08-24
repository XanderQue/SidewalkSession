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
    public AudioClip pop;
    public AudioClip land;
    public AudioSource audioSource;
    //end** Editor Game object links **end

    [SerializeField]
    private bool grounded;

    public float jumpForce = 7.75f;
    public float pushSpeed = 50.0f;
    public float velocity = 0.0f;
    public ForceMode2D jumpMode = ForceMode2D.Impulse;
    public GameLogic gameLogic;
    public bool alive = true;



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
            if(groundCheckCollider.IsTouchingLayers(LayerMask.NameToLayer("Floor")))
            {
                rigBody.velocity.Set(0.0f, 0.0f);
                grounded = true;
                PlayLandAudio();
            }
            

        }
        anim.SetBool("Grounded", grounded);

    }

    public void TriggerJump()
    {
        if (groundCheckCollider.IsTouchingLayers(LayerMask.NameToLayer("Floor")))
        {

            grounded = false;
            anim.SetBool("Ollie", true);
        }
        
        
    }
    public void Jump()
    {
        
            rigBody.AddForce(jumpForce * Vector2.up, jumpMode);
            PlayPopAudio();
        
        
    }

    public void MoveHorizontal(int direction)
    {
        /*Vector2 currPos = transform.position;
        currPos += new Vector2(speed*Time.deltaTime, 0.0f);
        transform.position = currPos;*/
        if (grounded)
            rigBody.AddForce(new Vector2(direction * pushSpeed * Time.deltaTime, 0.0f), ForceMode2D.Impulse);
        else
            Debug.Log("Can only move while grounded");
    }


    public void PlayPopAudio()
    {
        audioSource.PlayOneShot(pop);
    }

    public void PlayLandAudio()
    {
        audioSource.PlayOneShot(land);    
    }

}
