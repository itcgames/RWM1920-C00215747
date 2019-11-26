using UnityEngine;
using System;
using System.Collections;

public class Spring : MonoBehaviour
{
    public float springForce = 1000;
    private Collision2D collision;
    private bool bouncing = false;


    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!bouncing)
        {
            bouncing = true;
            collision = coll;
        }
    }

    void FixedUpdate()
    {
        if (bouncing)
        {
            var rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(new Vector2(0f, springForce));
            bouncing = false;
        }
    }
    
}