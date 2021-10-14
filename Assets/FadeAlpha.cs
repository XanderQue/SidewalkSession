using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAlpha : MonoBehaviour
{
    // Start is called before the first frame update
    private SpriteRenderer sprite;
    private float start = 1.0f;
    private float end = 0.0f;

    public bool flipped = false;
    public float startFadeSec;
    public float fadeDurationSec;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        StartCoroutine(waitStart());
        switch (flipped)
        {
            case true:
                start = 0.0f;
                end = 1.0f;
                break;
            case false:
                start = 1.0f;
                end = 0.0f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator waitStart()
    {
        yield return new WaitForSeconds(startFadeSec);
        StartCoroutine(fade());

    }

    IEnumerator fade()
    {
        for (float t = 0f; t < fadeDurationSec; t += Time.deltaTime)
        {
            float normalizedTime = t / fadeDurationSec;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            sprite.color = new Color(sprite.color.r,sprite.color.g,sprite.color.b,Mathf.Lerp(start, end, normalizedTime));
            yield return null;
        }
            
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, end);

    }


}
