﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    
    public void StartGame() { 
    
        SceneManager.LoadScene("Nivel_1");
    }
    
    public void CloseGame() {
        Application.Quit();
        Debug.Log("Exit");
    
    }
}
