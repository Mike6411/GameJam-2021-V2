using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_Script : MonoBehaviour
{
    public float scaleRate = 0f;
    public float maxScale = 0f;
    public float minScale = 0f;
    public float aux = 0f;
    public bool freeze = false;
    public bool hit = false;


    void Start()
    {
        aux = scaleRate;
    }

    void Update()
    {
        mainLoop();
    }

    public void ApplyScaleRate()
        {
            transform.localScale += Vector3.one * scaleRate;
    }

    public void mainLoop()
    {

        if (hit)
        {
            if (transform.localScale.x > minScale)
            {
                scaleRate = -Mathf.Abs(scaleRate);
            }
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            hit = false;
            freeze = false;
        }
    }
}
