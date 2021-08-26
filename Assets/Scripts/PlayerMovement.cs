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

    [SerializeField]
    public Vector2  fowardForce = new Vector2(1.0f,0.0f);

    private int onlyGroundLayer = 13;//this is to change to the physics tag that ignores all objects but the ground.
    private int playerLayer = 9;

    public bool fell = false;
    public bool waitToCheckGround = false;

    [SerializeField]
    private float xDeadPosition = -11.0f;
    public float xSpeed = -7.0f;
    public bool canSpawn = false;

    public GameObject skateboard;
    public GameObject spawnedBoard;

    // Start is called before the first frame update
    void Start()
    {
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
        if (grounded && alive)
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
        if (grounded && alive)
            rigBody.AddForce(new Vector2(direction * pushSpeed * Time.deltaTime, 0.0f), ForceMode2D.Impulse);
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
        Quaternion rot = transform.rotation;
        transform.SetPositionAndRotation(Vector3.zero, rot);
        rigBody.WakeUp();
        gameObject.layer = playerLayer;
        anim.Play("Ride");
    }

    public void MoveAfterFall()
    {

        if (grounded && fell && transform.position.x > xDeadPosition)
        {
            Debug.Log("Move after fall");
            Vector2 newPos = transform.position;
            newPos.x += xSpeed * Time.deltaTime;
            transform.position = newPos;
            canSpawn = true;

        }
    }
    
}
