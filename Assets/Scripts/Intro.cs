using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    //Saga o Jrs kod
    public Menu menu;
    public virtual void Start()
    {  
        menu.timeIsRunning = true;
        menu.timeRemaining = 19;
    }

    public virtual void Update()
    {
        if(menu.timeRemaining < 0)
        {
            SceneManager.LoadScene(2);
        }
    }

    public virtual void DisplayTime(float visualTime)
    {
        //ändrar enheten från sekunder mellan varje frame till normala sekunder och minuter som går. JR
        float minutes = Mathf.FloorToInt(visualTime / 60);
        float seconds = Mathf.FloorToInt(visualTime % 60);
    }
}
