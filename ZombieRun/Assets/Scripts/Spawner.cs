using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float delay = 2.0f;
    public bool active = true;
    public Vector2 delayRange = new Vector2(1, 2);
    // Start is called before the first frame update
    void Start()
    {
        //start the enemy generator
        //delay gets reset to a random value
        ResetDelay();
        StartCoroutine(EnemyGenerator());
        
    }

    IEnumerator EnemyGenerator()
    {
        //call delay
        yield return new WaitForSeconds(delay);
        //check if spawner is active
        if (active)
        {
            var newTransform = transform;
            //spawn random items from the prefabs list, reset position to 0 of every object spawned
            GameObjectUtil.Instantiate(prefabs[Random.Range(0, prefabs.Length)], newTransform.position);
            ResetDelay();
        }
        //restart the Coroutine for the generator
        StartCoroutine(EnemyGenerator());
    }
    //delay resets with random value
    void ResetDelay()
    {
        delay = Random.Range(delayRange.x, delayRange.y);
    }

   
}
