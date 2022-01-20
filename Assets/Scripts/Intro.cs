using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    Menu menu;
    void Start()
    {
        menu.GetComponent<Menu>();
        menu.timeIsRunning = true;
        menu.timeRemaining = 19;
    }

    void Update()
    {
        if(menu.timeRemaining == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}
