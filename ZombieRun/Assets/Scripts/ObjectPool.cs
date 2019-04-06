using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    //prefab reference
    public RecycleGameObject prefab;

    private List<RecycleGameObject> poolInstances = new List<RecycleGameObject>();

    //create an instance when we need it
    private RecycleGameObject CreateInstance(Vector3 pos)
    {
        //only instantiate it here directly instead of routing through object= utility otherwise it will create an endless loop
        var clone = GameObject.Instantiate(prefab);
        //set position of the clone
        clone.transform.position = pos;
        //make sure clone is nested
        clone.transform.parent = transform;
        //add to list
        poolInstances.Add(clone);
        return clone;

    }

    //return instance when we need it
    public RecycleGameObject NextObject(Vector3 pos)
    {
        RecycleGameObject instance = null;

        //create a loop that will go through and check which objects can be reused

        foreach(var go in poolInstances)
        {
            if (go.gameObject.activeSelf != true)
            {
                instance = go;
                instance.transform.position = pos;
            }
        }
        //create new instance if there are no recycled objects in the pool
        if (instance == null) 
        instance = CreateInstance(pos);
        //call restart method to reload object
        instance.Restart();

        return instance;
    }

    

}
