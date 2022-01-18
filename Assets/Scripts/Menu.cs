using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public float timeRemaining;

    public bool timeIsRunning = false;


    //Kommer använda funktionerna(?) med knapparna i Unity - Saga 

    public GameObject optionMenu;
    public /*virtual jag vet inte om vi vill ha en pausmeny än, annars kan den scripten ära från denna*/ void StartGame()
    {
        SceneManager.LoadScene(1);

        timeIsRunning = true;

    }

    void Update()
    {
        if (timeIsRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timeIsRunning = false;
                EndGame();
            }
        }

    }
    public /*virtual*/ void EndGame()
    {
        Application.Quit();
        SceneManager.LoadScene(2);
    }
}
