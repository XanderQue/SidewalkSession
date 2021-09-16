using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustShaderSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Material> materials;

    private string shaderPropertyReference = "global_SpeedMultiplyer";
    private float currentSpeed = 1.0f;

    public Vector2 uvCoords = new Vector2(0, 0);
    void Start()
    {
        setShaderSpeed();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (materials != null)
        {
            if (currentSpeed != GameLogic.global_SpeedMultiplyer)
            {
                setShaderSpeed();
            }
        }
        updateUV();
    }

    public void setShaderSpeed()
    {
        currentSpeed = GameLogic.global_SpeedMultiplyer;
        foreach (Material material in materials)
        {
            material.SetFloat(shaderPropertyReference, GameLogic.global_SpeedMultiplyer);
        }
    }
    private void updateUV()
    {
        Vector2 speed;
        foreach (Material material in materials)
        {
            if (material.HasProperty("MoveX") && material.HasProperty("uv_Offset"))
            {

                speed = material.GetVector("MoveX");
                uvCoords = material.GetVector("uv_Offset");
                uvCoords += speed * Time.deltaTime * GameLogic.global_SpeedMultiplyer;
                uvCoords.x = uvCoords.x % 1.0f;
                material.SetVector("uv_Offset", uvCoords);
            }
        }
        
    }
}
