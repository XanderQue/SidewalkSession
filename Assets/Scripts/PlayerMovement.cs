﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private PlayerActionControls playerActionControls;
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
    public bool canPush = true;
    public ForceMode2D jumpMode = ForceMode2D.Impulse;
    public GameLogic gameLogic;
    public bool alive = true;

    [SerializeField]
    public Vector2  fowardForce = new Vector2(1.0f,0.0f);

    private int onlyGroundLayer = 13;//this is to change to the physics tag that ignores all objects but the ground.
    private int playerLayer = 9;

    private Vector2 startPos;
    public bool fell = false;
    public bool waitToCheckGround = false;

    [SerializeField]
    private float xDeadPosition = -11.0f;
    public float xSpeed = -7.0f;
    public bool canSpawn = false;

    private int flashTime = 5;
    public SpriteRenderer sprtRenderer;
    public GameObject skateboard;
    public GameObject spawnedBoard;

    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();

    }
    // Start is called before the first frame update
    void Start()
    {
        startPos = new Vector2(0, 0);
        startPos.x = transform.position.x;
        startPos.y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        GroundUpdate();
        MoveAfterFall();
    }

    void GroundUpdate()
    {
        velocity = rigBody.velocity.y;
        anim.SetFloat("Y Velocity", velocity);
        if (!grounded && rigBody.velocity.y < 0.0f)
        {
            if (groundCheckCollider.IsTouchingLayers(LayerMask.GetMask(new string[]{"Ground","Rideable"})))
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
        if (!GameLogic.paused)
        {
            if (grounded && alive)
            {

                grounded = false;
                if ((gameLogic.getNumJumps() + 1) % 5 == 0)
                {
                    //front shuv - extra points and fan fare
                    anim.SetBool("FrontShuv", true);

                }
                else 
                {
                    anim.SetBool("Ollie", true);
                }
                
            }
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

        if (!GameLogic.paused)
        {
            if (grounded && alive && canPush)
            {


                if (direction > 0)
                {
                    //rigBody.AddForce(new Vector2(direction * pushSpeed * 2 * Time.deltaTime, 0.0f), ForceMode2D.Impulse);
                    anim.Play("Push");
                    gameLogic.speedMult += 0.1f;
                }
                else
                {
                    //rigBody.AddForce(new Vector2(direction * pushSpeed * Time.deltaTime, 0.0f), ForceMode2D.Impulse);
                    footDown();
                    if(GameLogic.global_SpeedMultiplyer > 1.0f + (gameLogic.score * 0.005f))
                        gameLogic.speedMult -= 0.1f;
                
                    anim.Play("slow");
                }
                canPush = false;
            }
        }

    }
    public void footUp()
    {
        if (anim != null)
        {
            if (anim.GetBool("footDown"))
            {
                anim.SetBool("footDown", false);
            }
        }
    }
    public void footDown()
    {
        if (anim != null)
        {
            if (!anim.GetBool("footDown"))
            {
                anim.SetBool("footDown", true);
            }
        }
    }


    public void PlayPopAudio()
    {
        audioSource.PlayOneShot(pop);
    }

    public void PlayLandAudio()
    {
        audioSource.PlayOneShot(land);    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //if hazad then fall
       
        if (collision.tag == "hazard" )
        {
            alive = false;
            
            gameLogic.GameOver();
            rigBody.AddRelativeForce(fowardForce);
            fall();

        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
    }

    void fall()
    {
        if(spawnedBoard == null)
            spawnedBoard = Instantiate(skateboard);
        anim.Play("FallFoward");
        PlayPopAudio();
        //Change Player game object tag so that it ignores collisions with objects but still collides with ground.
        gameObject.layer = onlyGroundLayer;
        fell = true;
        StartCoroutine(WaitToCheckGround());
        
    }
    IEnumerator WaitToCheckGround()
    {
        waitToCheckGround = true;
        grounded = false;
        yield return new WaitForSeconds(2.0f);
        waitToCheckGround = false;
    }
    public void respawn()
    {
        canSpawn = false;

        grounded = false;

        anim.SetBool("Grounded", grounded);
        alive = true;
        fell = false;
        gameObject.layer = LayerMask.NameToLayer("OnlyGround");
        Quaternion rot = transform.rotation;
        transform.SetPositionAndRotation(startPos, rot);
        rigBody.WakeUp();
        anim.Play("Ride");
        StartCoroutine(waitFlash(flashTime));
    }

    public void MoveAfterFall()
    {

        if (grounded && fell && transform.position.x > xDeadPosition)
        {
            //Debug.Log("Move after fall");
            Vector2 newPos = transform.position;
            newPos.x += xSpeed * Time.deltaTime;
            transform.position = newPos;
            canSpawn = true;

        }
    }

    IEnumerator waitFlash(int count)
    {

        sprtRenderer.enabled = false;
        yield return new WaitForSeconds(0.25f);
        sprtRenderer.enabled = true;
        yield return new WaitForSeconds(0.5f);
        count--;
        if (count > 0)
        {
            StartCoroutine(waitFlash(count));
        }
            
        else 
        {
            gameObject.layer = LayerMask.NameToLayer("Player");
        }

    }

    public void checkTouch(InputAction.CallbackContext context)
    {
        Debug.Log("checkTouch"+ context.phase);
    }
}
