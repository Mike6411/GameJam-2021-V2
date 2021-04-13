using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Script : MonoBehaviour
{
    public float speed;
    public float jump;
    private float speedx;
    public Rigidbody2D rb;
    private int counter = 0;
    public float maxX = 5;
    public AudioSource footstepsGrass;
    public AudioSource footstepsStone;
    public AudioSource footstepsWood;


    float moveVelocity;
    public bool grounded = true;

    public void Start()
    {
        footstepsGrass = GetComponent<AudioSource>();
        footstepsStone = GetComponent<AudioSource>();
        footstepsWood = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Jumping 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!grounded)
            {
                if (counter < 1)
                {
                    rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
                    counter++;
                }
            }
            else
            {
                rb.AddForce(transform.up * jump, ForceMode2D.Impulse);
                counter = 0;
            }
        }
    }

    void FixedUpdate()
    {
        float delta = Time.fixedDeltaTime;

        //Left Right Movement 
        if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x > -maxX)
            {
                rb.AddForce((Vector2.left * speed) , ForceMode2D.Force);
            }
        }


        if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x < maxX)
            {
                rb.AddForce((Vector2.right * speed) , ForceMode2D.Force);
            }
        }


    }
    //Check if Grounded 
    void OnCollisionStay2D()
    {
        grounded = true;
    }
    void OnCollisionExit2D()
    {
        grounded = false;
    }

     public void OnCollisionEnter2D(Collision2D collision)
     {
          if (collision.gameObject.tag == "grass") {
                footstepsGrass.Play();
          }
          else if (collision.gameObject.tag == "stone")
          {
                footstepsStone.Play();
          } 
          else if (collision.gameObject.tag == "wood")
          {
                footstepsWood.Play();
          }
     }


}
