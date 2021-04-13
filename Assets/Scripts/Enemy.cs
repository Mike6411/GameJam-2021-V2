using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
  public float speed;
  float actualspeed;

  


    // Update is called once per frame
    void Update()
    {
        
        actualspeed=0f;
        actualspeed=speed;
        transform.Translate(speed*Time.deltaTime,0,0);


    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.tag=="limitePatrulla"){
           Debug.Log("chocando");
           if(transform.rotation.y==0){
               transform.eulerAngles = new Vector3 (0,180,0);

           }else{
               transform.eulerAngles = new Vector3 (0,0,0);
           }
       } 
    
    }


}
