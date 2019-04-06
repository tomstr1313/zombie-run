using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSounds : MonoBehaviour
{

    public AudioSource soundSource;
    //public AudioClip zombie;
    public AudioClip[] sounds;


    // Start is called before the first frame update
    void Start()
    {

        
            soundSource.clip = sounds[Random.Range(0,sounds.Length)];
            soundSource.Play();

            //soundSource.loop = true;
           
        



        //int index = Random.Range(0, sounds.Length);
        //zombie = sounds[index];
        //soundSource.clip = zombie;
        //soundSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
