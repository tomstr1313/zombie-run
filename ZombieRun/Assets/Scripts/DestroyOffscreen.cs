using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffscreen : MonoBehaviour
{
    public float offset = 16f;
    public delegate void OnDestroy();
    public event OnDestroy DestroyCallback;

    private bool offscreen;
    private float offscreenX = 0;
    private Rigidbody2D body2d;

    //start the rigidbody component
    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //calculate how far the object is off the screen before it is deleted
        offscreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits) / 2 + offset;
    }

    // Update is called once per frame
    void Update()
    {
        //find out when the object is actually off the screen
        var posX = transform.position.x;
        var dirX = body2d.velocity.x;

        //get absolute value of x position

        if (Mathf.Abs(posX) > offscreenX)
        {
            //check which side of the screen you are going off of
            if(dirX<0 && posX < -offscreenX)
            {
                offscreen = true;
                
            }else if (dirX > 0 && posX > offscreenX)
            {
                offscreen = true;
            }
            else
            {
                offscreen = false;
            }
            //check how far out you are
            if (offscreen){
                OnOutOfBounds();
            }
        }
        void OnOutOfBounds()
        {
            offscreen = false;
            GameObjectUtil.Destroy(gameObject);

            if (DestroyCallback != null)
            {
                DestroyCallback();
            }
        }
        
    }
}
