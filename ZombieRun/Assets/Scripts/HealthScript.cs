using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    
    public float health = 100f;

  public void RemoveHealth(float amount)
    {
        amount -= health;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
