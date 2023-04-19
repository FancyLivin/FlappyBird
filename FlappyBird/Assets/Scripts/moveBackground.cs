using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveBackground : MonoBehaviour
{
    public RawImage background;
    private float x = 0.1f, y = 0.0f;

    // Update is called once per frame
    void Update()
    {
        background.uvRect = new Rect(background.uvRect.position + new Vector2(x, y) * Time.deltaTime, background.uvRect.size);
    }
}
