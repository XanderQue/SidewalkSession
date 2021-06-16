using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField]
    private Vector2 startPostition = new Vector2(0,0);

    public float xSpeed = 10.0f;

    [SerializeField]
    private float xDeadPosition = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Get starting point
        //start a list of active objects
        //will use this list to delete objects that have reached the other sid eof the screen but also keep track of objects.
        startPostition = (Vector2)transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        MoveHorizontal();
        checkPosition();
    }

    void MoveHorizontal()
    {
        Vector2 newPos = transform.position;
        newPos.x += xSpeed * Time.deltaTime;
        transform.position = newPos;
    }

    void checkPosition()
    {
        if(transform.position.x < xDeadPosition)
        {
            Destroy(this.gameObject);
        }
        
    }
}
