using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int health = 100;
    public bool hasDied;

    private void Start()
    {
        hasDied = false;
    }

    private void Update()
    {
        if (gameObject.transform.position.y < -7)
        {
            hasDied = true;
        }
    }
}
