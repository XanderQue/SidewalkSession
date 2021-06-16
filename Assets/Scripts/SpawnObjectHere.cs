using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectHere : MonoBehaviour
{

    public GameObject goToSpawn;
    public float pauseTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitToSpawn(pauseTime));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waitToSpawn(float waitTime)
    { 
        Instantiate(goToSpawn,transform);

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(waitToSpawn(pauseTime));
    }
}
