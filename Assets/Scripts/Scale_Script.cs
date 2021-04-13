using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_Script : MonoBehaviour
{
    public float scaleRate = 0f;
    public float currentScale = 0f;
    public float maxScale = 0f;
    public float minScale = 0f;
    public float deathScale = 0f;
    public float aux = 0f;
    public float delta;
    public bool freeze = false;
    public bool hit = false;
    public bool banana = false;
    public bool dead = false;
    public Vector3 respawn;


    void Start()
    {
        aux = scaleRate;
        respawn = transform.position;
    }

    void Update()
    {
        float delta = Time.fixedDeltaTime * 1000;
        if (transform.localScale.x < deathScale)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Invoke("Respawn", 3f);
        }
        mainLoop();
        //if ( transform.localScale > deathScale)
        //{
           
        //}
    }

    public void Respawn()
    {
        transform.position = respawn;

        GetComponent<SpriteRenderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }

    public void ApplyScaleRate()
    {
        transform.localScale += Vector3.one * scaleRate;
        //currentScale = transform.localScale += Vector3.one * scaleRate;
    }

    public void mainLoop()
    {
        scaleRate = aux;

        if (hit)
        {
            if (transform.localScale.x > minScale)
            {
                scaleRate = -Mathf.Abs(scaleRate);
            }
        }
        else if (banana)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        else if (transform.localScale.x < maxScale)
        {
            scaleRate = aux;
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if (transform.localScale.x > maxScale) {
            scaleRate = 0;
        }    

        ApplyScaleRate();
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if ( collision.gameObject.tag == "Light")
        {
            hit = true;
        }
        if (collision.gameObject.tag == "Death")
        {
            banana = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            hit = false;
        }
        if (collision.gameObject.tag == "Death")
        {
            banana = false;
        }
        if (collision.gameObject.tag == "Checkpoint")
        {
            respawn = transform.position;
        }
    }
}
