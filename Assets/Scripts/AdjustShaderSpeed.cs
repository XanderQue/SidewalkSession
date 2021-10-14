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
        SetShaderSpeed();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (materials != null)
        {
            if (currentSpeed != GameLogic.global_SpeedMultiplyer)
            {
                SetShaderSpeed();
            }
        }
        UpdateUV();
    }

    public void SetShaderSpeed()
    {
        currentSpeed = GameLogic.global_SpeedMultiplyer;
        foreach (Material material in materials)
        {
            material.SetFloat(shaderPropertyReference, GameLogic.global_SpeedMultiplyer);
        }
    }
    private void UpdateUV()
    {
        Vector2 speed;

        foreach (Material material in materials)
        {
            if (material.HasProperty("SpeedScroll") && material.HasProperty("uv_Offset"))
            {

                speed = material.GetVector("SpeedScroll");
                
                uvCoords = material.GetVector("uv_Offset");

                if (material.HasProperty("staticX"))
                {
                    if (material.GetInt("staticX") == 1)
                    {
                        uvCoords.x += speed.x * Time.deltaTime;
                    }
                    else
                    {
                        uvCoords.x += speed.x * Time.deltaTime * GameLogic.global_SpeedMultiplyer;
                    }
                    uvCoords.x = uvCoords.x % 1.0f;
                }
                else {
                    uvCoords.x += speed.x * Time.deltaTime * GameLogic.global_SpeedMultiplyer;
                    uvCoords.x = uvCoords.x % 1.0f;
                }
                if (material.HasProperty("staticY"))
                {
                    if (material.GetInt("staticY") == 1)
                    {
                        uvCoords.y += speed.y * Time.deltaTime;
                    }
                    else
                    {
                        uvCoords.y += speed.y * Time.deltaTime * GameLogic.global_SpeedMultiplyer;
                    }
                    uvCoords.y = uvCoords.y % 1.0f;
                }
                else 
                {
                    uvCoords.y += speed.y * Time.deltaTime * GameLogic.global_SpeedMultiplyer;
                    uvCoords.y = uvCoords.y % 1.0f;
                }
                material.SetVector("uv_Offset", uvCoords);
            }
        }
        
    }
}
