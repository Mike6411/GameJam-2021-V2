using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXenemy : MonoBehaviour
{
    // Start is called before the first frame update
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
         
        GetComponent<AudioSource>().Play();
        }
        
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player"){
         
        GetComponent<AudioSource>().Stop();
        }
        
    }
}
