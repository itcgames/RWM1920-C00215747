using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringFunction : MonoBehaviour
{
    public GameObject gameObject;
    
    private float jump = 44.27f;

    void Update()
    {
        gameObject.velocityX = gameObject.velocityX + jump;
    }
}
