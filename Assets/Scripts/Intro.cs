using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Saga o Jrs kod

public class Intro : MonoBehaviour
{
    public float timeRemaining;

    public bool timeIsRunning = false;
    //Den ska inte tickas ner när man inte är i själva scenen som den annars skulle göra - Saga
    public Menu menu;
    //Menu koden används inte här men används i andra koder som ärver Intro koden (Over & Win) - S
    public virtual void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        //Sagas del i funktionen
        timeIsRunning = true;
        //När man är i scenen ska tiden börja ticka ner - S
        timeRemaining = 19;
        //Vi tittade hur lång cutscenen är och den är ungefär 19 sek - S
    }

    public virtual void Update()
    {
        if (timeIsRunning)
        {
            //När cutscenen är igång ska tiden (floaten) ticka neråt som en vanlig timer - Saga
            timeRemaining -= Time.deltaTime;
        }

        if(timeRemaining < 0)
        {
            //Om det inte finns någon tid kvar då ska man föras till själva spelscenen - Saga
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //Om man trycker space kan man skippa intro cutscenen och förs automatiskt till spelet - JR
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
