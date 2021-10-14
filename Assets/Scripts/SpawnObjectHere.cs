using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectHere : MonoBehaviour
{
    public GameLogic gameLogic;

    public int timesToSpawn = -1;


    public List<GameObject> gameObjectList;
    private int gameObjectIndex = 0;
    public bool rand_GameObjectIndex = false;

    public List<float> sizesOfObjectsList;
    private int sizeObjIndex = 0;
    public bool rand_SizeIndex = false;
    public bool randSize_BetweenValsOnly = false;

    public List<float> waitTimesList;
    private int waitTimeIndex = 0;
    public bool rand_WaitTImeIndex = false;
    public bool randWaitTime_BetweenValsOnly = false;


    public List<Vector2> positionList;
    private int positionIndex = 0;
    public bool rand_PositionIndex = false;
    public bool randPosition_BetweenValsOnly = false;

    public float pauseTime = 5.0f;


    [SerializeField]
    private bool alwaysSpawning = false;

    private bool spawning = false;
    private bool firstTime = true;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObjectList != null)
        {
            
            gameLogic = GameObject.FindObjectOfType<GameLogic>();
            StartSpawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void FixedUpdate()
    {
        if (!spawning)
        {
            StartSpawn();
        }
    }
    //To start spawning.
    //After game ends use Game Logic script to start spawning the objects again.
    public void StartSpawn()
    {
        firstTime = true;
        bool alive = gameLogic.CheckAlive();
        if ( (alive || alwaysSpawning) && !spawning)
        {
            pauseTime = SetWaitTimes();
            spawning = true;
            StartCoroutine(WaitToSpawn(pauseTime));
        }
           
    }


    IEnumerator WaitToSpawn(float waitTime)
    {

        if (firstTime)
        {
            
            yield return new WaitForSeconds(waitTime);
            firstTime = false;
        }
        GameObject toSpawn = GetGObject();

        GameObject spawn = Instantiate(toSpawn);

        Vector2 spawnPosition = GetPosition();
        Vector2 spawnSize = Vector2.one * SetSize();

        spawn.transform.localScale = spawnSize;
        spawn.transform.position = spawnPosition;

        yield return new WaitForSeconds(waitTime);

        if ((gameLogic.CheckAlive() || alwaysSpawning ) && spawning)
        {
            pauseTime = SetWaitTimes();
            StartCoroutine(WaitToSpawn(pauseTime));
        }
        else
        {
            spawning = false;
        }
        
        
    }

    private float SetSize()
    {
        if (sizesOfObjectsList.Count > 0 && sizesOfObjectsList != null)
        {
            if (sizesOfObjectsList.Count > 1)
            {
                if (!randSize_BetweenValsOnly)
                {
                    // not just between 2 values
                    if (rand_SizeIndex)
                    {
                        //get random index
                        int randIndex = Random.Range(0, sizesOfObjectsList.Count);

                        return sizesOfObjectsList[randIndex];
                    }
                    else 
                    {
                        //use index to loop (index % sise of list) to prevent walk off
                        float retValue = sizesOfObjectsList[sizeObjIndex % sizesOfObjectsList.Count];
                        sizeObjIndex++;
                        return retValue;
                    }
                }
                else // random between two values only
                {
                    //get min and max
                    float minVal = Mathf.Min(sizesOfObjectsList[0], sizesOfObjectsList[1]);
                    float maxVal = Mathf.Max(sizesOfObjectsList[0], sizesOfObjectsList[1]);
                    //random return rand between 0 and 1
                    return Random.Range(minVal, maxVal);
                }
            }
            else
            {
                return( sizesOfObjectsList[0] );
            }
        }
        //else
        return 1;
    }

    private float SetWaitTimes()
    {
        //check
        if (waitTimesList.Count > 0 && waitTimesList != null)
        {
            if (waitTimesList.Count > 1)
            {
                if (!randWaitTime_BetweenValsOnly)
                {
                    // not just between 2 values
                    if (rand_WaitTImeIndex)
                    {
                        //get random index
                        int randIndex = Random.Range(0, waitTimesList.Count);

                        return waitTimesList[randIndex] + (GameLogic.global_SpeedMultiplyer * 0.01f);
                    }
                    else
                    {
                        //use index to loop (index % sise of list) to prevent walk off
                        float retValue = waitTimesList[waitTimeIndex % waitTimesList.Count];
                        waitTimeIndex++;
                        return retValue + (GameLogic.global_SpeedMultiplyer * 0.01f);
                    }
                }
                else // random between two values only
                {
                    //get min and max
                    float minVal = Mathf.Min(waitTimesList[0], waitTimesList[1]);
                    float maxVal = Mathf.Max(waitTimesList[0], waitTimesList[1]);
                    //random return rand between 0 and 1
                    return Random.Range(minVal, maxVal) + (GameLogic.global_SpeedMultiplyer * 0.01f);
                }
            }
            else
            {
                return waitTimesList[0]+(GameLogic.global_SpeedMultiplyer*0.01f);
            }
        }
        //else
        return 1.0f + (GameLogic.global_SpeedMultiplyer * 0.01f);
    }

    private GameObject GetGObject()
    {
        //check
        if (gameObjectList.Count > 0 && gameObjectList != null)
        {
            if (gameObjectList.Count > 1)
            {
               
                    
                    if (rand_GameObjectIndex)
                    {
                        //get random index
                        int randIndex = Random.Range(0, gameObjectList.Count-1);

                        return gameObjectList[randIndex];
                    }
                    else
                    {
                        //use index to loop (index % sise of list) to prevent walk off
                        GameObject retValue = gameObjectList[gameObjectIndex % gameObjectList.Count];
                        gameObjectIndex++;
                        return retValue;
                    }
                
            }
            else
            {
                return (gameObjectList[0]);
            }
        }
        //else
        return null;
    }
    private Vector2 GetPosition()
    {
        //check
        if (positionList.Count > 0 && positionList != null)
        {
            if (positionList.Count > 1)
            {
                if (!randPosition_BetweenValsOnly)
                {
                    // not just between 2 values
                    if (rand_PositionIndex)
                    {
                        //get random index
                        int randIndex = Random.Range(0, positionList.Count - 1);

                        return positionList[randIndex];
                    }
                    else
                    {
                        //use index to loop (index % sise of list) to prevent walk off
                        Vector2 retValue = positionList[positionIndex % positionList.Count];
                        positionIndex++;
                        return retValue;
                    }
                }
                else // random between two values only
                {
                    //get min and max
                    float minX_Val = Mathf.Min(positionList[0].x, positionList[1].x);
                    float maxX_Val = Mathf.Max(positionList[0].x, positionList[1].x);
                    //random return rand between 0 and 1
                    float xVal = Random.Range(minX_Val, maxX_Val);

                    float minY_Val = Mathf.Min(positionList[0].y, positionList[1].y);
                    float maxY_Val = Mathf.Max(positionList[0].y, positionList[1].y);
                    //random return rand between 0 and 1
                    float yVal = Random.Range(minY_Val, maxY_Val);

                    return new Vector2(xVal, yVal);

                }
            }
            else
            {
                return (positionList[0]);
            }
        }
        //else
        return this.transform.position;
    }

}
