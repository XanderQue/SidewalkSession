using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_3D : MonoBehaviour
{
    public Vector3 speed = new Vector3(0.0f,0.0f,0.0f);

    private Transform objTransform;
    // Start is called before the first frame update
    void Start()
    {
        objTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        objTransform.Rotate(speed*Time.deltaTime);
    }
    private void FixedUpdate()
    {
        
    }
}
