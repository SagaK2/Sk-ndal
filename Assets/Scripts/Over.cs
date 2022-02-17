using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Over : Intro
{
    // Sagas kod som är ett arv från intro
    public override void Start()
    {
        //Vi vill fortfarande att timeIsRunning ska vara true så den behöver man inte ändra på
        base.Start();
        //Man vill inte kunna se musen i jumpscaren för det skulle förstöra effekten lite
        Cursor.lockState = CursorLockMode.Locked;
        //Jumpscaren är mycket kortare än introt
        menu.timeRemaining = 4;
    }
    public override void Update()
    {
        if (menu.timeRemaining < 0)
        {
            SceneManager.LoadScene(0);
            //Här vill man ha tillbaka musen. -Luva
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
