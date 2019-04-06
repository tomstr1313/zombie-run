using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//create interface so that this class can be used with any other script to recycle objects
public interface IRecycle
{
    void Restart();
    void Shutdowm();
}

public class RecycleGameObject : MonoBehaviour
{

    //keep reference that implement IRecycle
    private List<IRecycle> recycleComponents;

    void Awake()
    {
        //manually check all scripts to see if the implement IRecycle
        var compoments = GetComponents<MonoBehaviour>();
        recycleComponents = new List<IRecycle>();
        foreach(var component in compoments)
        {
            if(component is IRecycle)
            {
                recycleComponents.Add(component as IRecycle);
            }
        }
        //statement to test if this is working
       // Debug.Log(name + " Found " + recycleComponents.Count + " Components");
    }
    //recall objects that have been shutdown
   public void Restart()
    {
        //allows us to activate or deactivate an object but still have it exist in our scene
        gameObject.SetActive(true);
        foreach(var component in recycleComponents)
        {
            component.Restart();
        }

    }
    //used to remove objects but not fully destroy them 
   public void Shutdown()
    {
        gameObject.SetActive(false);
        foreach (var component in recycleComponents)
        {
            component.Shutdowm();
        }
    }
}
