using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour, IRecycle
{
    //array of sprites
    public Sprite[] sprites;

    public Vector2 colliderOffset = Vector2.zero;

   public void Restart()
    {
        //render different sprites 
        var renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];

        //resize the collider to the size of the object
        //reset the y collider size and position
        var collider = GetComponent<BoxCollider2D>();
        
        var size = renderer.bounds.size;

        size.y += colliderOffset.y;
        collider.size = size;
        collider.offset = new Vector2(-colliderOffset.x, collider.size.y / 2 - colliderOffset.y);

    }

    public void Shutdowm()
    {
        
    }

    
}
