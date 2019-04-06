using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathSound : MonoBehaviour
{
    public DestroyOffscreen death;

    public AudioClip jump;
    public AudioClip playerDeath;
    public AudioSource jumpSource;
    public AudioSource deathSource;



    // Start is called before the first frame update
    void Start()
    {




    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKeyDown)
        {
            jumpSource.clip = jump;
            jumpSource.Play();

            //audioSource.clip = AudioDeath;
            //if(GetComponent<DestroyOffscreen>().offset < 30)
            //audioSource.Play();
        }
            //if (GetComponent<DestroyOffscreen>())
            //{
            //    deathSource.clip = playerDeath;
            //    deathSource.Play();
            //}
        }
    }

