using UnityEngine;
using System;
using System.Collections;

public class Spring : MonoBehaviour
{
    public float springForce = 1000;
    public Collision2D collision;
    static int col = 0;
    int count = 0;
    private bool bouncing = false;
    private Animator animator;
    public AudioSource audio;

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public static int collide(int x)
    {
        x = col;
        return x;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        var rigid = coll.gameObject.GetComponent<Rigidbody2D>();
        if (!bouncing && !animator.GetBool("Pressing"))
        {
            if (coll.gameObject.tag == "Player")
            {
                animator.SetBool("Pressing", true);
                animator.SetBool("Releasing", false);
                audio.Play();
                bouncing = true;
                collision = coll;
                col = 1;
                count += 1;
            }
            else if(coll.gameObject.tag != "Ground" && rigid.mass >= 10)
            {
                animator.SetBool("Pressing", true);
                animator.SetBool("Releasing", false);
                audio.Play();
                bouncing = true;
                collision = coll;
                springForce -= 150;
                col = 1;
                count += 1;
            }
            else if (coll.gameObject.tag != "Ground")
            {
                animator.SetBool("Pressing", true);
                animator.SetBool("Releasing", false);
                audio.Play();
                bouncing = true;
                collision = coll;
                springForce -= 100;
                col = 1;
                count += 1;
            }
        }
    }

    void FixedUpdate()
    {
        if (bouncing)
        {
            animator.SetBool("Pressing", false);
            animator.SetBool("Releasing", true); 
            var rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = new Vector3(0, 0, 0);
            rb.AddForce(new Vector2(0f, springForce));
            bouncing = false;
        }

        if (count >= 2)
        {
            Destroy(gameObject);
            count = 0;
        }
    }
    
}