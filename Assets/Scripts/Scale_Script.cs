using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scale_Script : MonoBehaviour
{
    public float scaleRate = 1.0f;
    public float maxScale = 20.0f;
    public float minScale = 1.0f;
    public bool freeze = false;
 
 public void ApplyScaleRate()
    {
        transform.localScale += Vector3.one * scaleRate;
    }

    public void mainLoop()
    {
        //if we exceed the defined range then correct the sign of scaleRate.
        if (transform.localScale.x < minScale)
        {
            scaleRate = Mathf.Abs(scaleRate);
        }
        else if (transform.localScale.x > maxScale)
        {
            scaleRate = -Mathf.Abs(scaleRate);
        }
        ApplyScaleRate();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (freeze)
            {
                freeze = false;
            }
            else if (!freeze)
            {
                freeze = true;
            }
        }

        if (freeze)
        {
            mainLoop();
        }
    }
}
