using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stoptv : MonoBehaviour
{
    public GameObject estatica; 
     void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Player"){
            Debug.Log("hola otra vez");
         
       estatica.SetActive(false);
        }
        
    }

     void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag=="Player"){
         
        GetComponent<AudioSource>().Stop();
        }
        
    }
}
