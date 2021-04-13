﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aipatrol : MonoBehaviour
{
    public float speed;
    public float distance; //esto es lo que hace que se recorra la distancia sino queda parado temblando

    private bool movingRight = true;
   
    public Transform groundDetection;
  
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance); //origin direction y distnce
        if (groundInfo.collider == false) {
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                movingRight = false;
            }
            else {
                transform.eulerAngles = new Vector3(0, 0, 0);
                movingRight = true;
            }
        }
    }


}
