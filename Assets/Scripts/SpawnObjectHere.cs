using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectHere : MonoBehaviour
{
    public GameLogic gameLogic;

    public GameObject goToSpawn;
   
    public float pauseTime = 5.0f;

    private bool spawning = false;
    private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        gameLogic = GameObject.FindObjectOfType<GameLogic>();
        startSpawn();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        if (!spawning)
        {
            startSpawn();
        }
    }
    //To start spawning.
    //After game ends use Game Logic script to start spawning the objects again.
    public void startSpawn()
    {
        firstTime = true;
        bool alive = gameLogic.checkAlive();
        if (alive && !spawning)
        {
            spawning = true;
            StartCoroutine(waitToSpawn(pauseTime));
        }
           
    }


    IEnumerator waitToSpawn(float waitTime)
    {
        if (firstTime)
        {
            
            yield return new WaitForSeconds(waitTime);
            firstTime = false;
        }
        GameObject spawn = Instantiate(goToSpawn,transform);

        yield return new WaitForSeconds(waitTime);

        if (gameLogic.checkAlive() && spawning)
        {
            StartCoroutine(waitToSpawn(pauseTime));
        }
        else
        {
            spawning = false;
        }
        
        
    }

}
