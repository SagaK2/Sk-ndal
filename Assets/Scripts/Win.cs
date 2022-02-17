using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : Intro
{
    public override void Start()
    {
        base.Start();
        menu.timeRemaining = 82;
    }

    public override void Update()
    {
        if (menu.timeRemaining < 0)
        {
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }

    }
}
