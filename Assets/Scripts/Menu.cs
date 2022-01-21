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

    /*private void Start()
    {
        //Man ska kunna se sin skärm här. (Men när den är locked då fungerar knapparna bra?)
        Cursor.lockState = CursorLockMode.None;
    }*/

    public /*virtual jag vet inte om vi vill ha en pausmeny än, annars kan den scripten ära från denna*/ void StartGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
