using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiledBackground : MonoBehaviour
{
    public int textureSize = 32;

    public bool scaledHorizontally = true;
    public bool scaledVertically = true;
    // Start is called before the first frame update
    void Start()
    {
        var newWidth = !scaledHorizontally ? 1:Mathf.Ceil(Screen.width / (textureSize * PixelPerfectCamera.scale));
        var newHeight = !scaledVertically ? 1: Mathf.Ceil(Screen.height / (textureSize * PixelPerfectCamera.scale));
        transform.localScale = new Vector3(newWidth * textureSize, newHeight * textureSize, 1);
        GetComponent<Renderer>().material.mainTextureScale = new Vector3(newWidth, newHeight,1);
    }

    // Update is called once per frame

}
