using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//Sagas kod
public class Menu : MonoBehaviour
{
    public float timeRemaining;

    public bool timeIsRunning = false;

    public Animator buttonAnimator;

    //Kommer använda funktionerna med knapparna i Unity 

    public GameObject optionMenu;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        //Man ska kunna se musen för att veta vilka knappar man klickar på i menyn - Saga
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void OnGUI()
    {
        //Jrs kod
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;

        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }

    public void StartGame()
    {
        //Man ska inte se musen här för att man kommer gå till en cutscene - JR
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene(1);
        timeIsRunning = true;
    }

    //Här och neråt har Saga skrivit
    void Update()
    {
        if (timeIsRunning)
        {
            //Om timern är igång och.. 
            if(timeRemaining > 0)
            {
                //Tiden är mer än 0. Då ska den gå neråt som en timer
                timeRemaining -= Time.deltaTime;
            }
            else if(timeRemaining == 0)
            {
                //Tiden är 0 då ska floaten timeRemaining sättas till 0 
                timeRemaining = 0;
                timeIsRunning = false;
                EndGame();
                //Då ska applikationen stängas ner
            }
        }

    }

    //Funktion till när man trycker ner start - Saga
    public void ChangingScene()
    {
        SceneManager.LoadScene(2);
    }
    //Till när man trycker på Quit knappen -Saga
    public void EndGame()
    {
        Application.Quit();
    }
}
