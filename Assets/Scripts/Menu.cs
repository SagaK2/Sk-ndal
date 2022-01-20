using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public float timeRemaining;

    public bool timeIsRunning = false;

    public Animator buttonAnimator;

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
            else if(timeRemaining == 0)
            {
                timeRemaining = 0;
                timeIsRunning = false;
                EndGame();
            }
        }

    }

    public void ChangingScene()
    {
        SceneManager.LoadScene(2);
    }
    public /*virtual*/ void EndGame()
    {
        Application.Quit();
        SceneManager.LoadScene(2);
    }
}
