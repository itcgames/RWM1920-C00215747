using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class move : MonoBehaviour
{
    float velocityX = 0;
    float velocityY = 0;

    void Update()
    {
        float time = 1.0f / 60.0f;
        Position.X = Position.X + (velocityX * time) + 0.5f * 9.8f * (time * time);
        Position.Y = Position.Y + (velocityX * time) + 0.5f * 0.0f * (time * time);
        velocityX = velocityX + 9.8f * time;
        velocityY = velocityY + 0.0f * time;
    }
}
