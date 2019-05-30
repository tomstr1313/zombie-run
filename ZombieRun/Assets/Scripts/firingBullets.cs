using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firingBullets : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 100;
    public Rigidbody2D rb;
    //public Rigidbody2D clone;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;

        //if (Input.GetButtonDown("Fire1"))
        //{
            //clone = Instantiate(rb, transform.position, transform.rotation);
          //  clone.velocity = transform.TransformDirection(Vector3.forward * speed);
        //}
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemies enemy = hitInfo.GetComponent<Enemies>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

}
