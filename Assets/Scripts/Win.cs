using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Sagas kod som är ett arv från intro
public class Win : Intro
{
    public override void Start()
    {
        base.Start();
        //Det ska stå samma som i Intro koden men cutscenen här är 82 sek 
        menu.timeRemaining = 82;
    }

    public override void Update()
    {
        if (menu.timeRemaining < 0)
        {
            //Om tiden som finns kvar är mer än 0 då ska man transporteras till meny scenen - Saga
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //Om man trycker space kan man även skippa den här cutscenen - JR
            SceneManager.LoadScene(0);
        }

    }
}
