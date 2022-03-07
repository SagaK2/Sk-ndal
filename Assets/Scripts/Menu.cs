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

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void OnGUI()
    {
        Vector3 point = new Vector3();
        Event currentEvent = Event.current;
        Vector2 mousePos = new Vector2();

        // Get the mouse position from Event.
        // Note that the y position from Event is inverted.
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        // För att musen inte ska ha en offset -Emre
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));
        
        //låter oss se position på mus, spelare och location enligt pixlar på kameran. -Emre
        GUILayout.BeginArea(new Rect(20, 20, 250, 120));
        GUILayout.Label("Screen pixels: " + cam.pixelWidth + ":" + cam.pixelHeight);
        GUILayout.Label("Mouse position: " + mousePos);
        GUILayout.Label("World position: " + point.ToString("F3"));
        GUILayout.EndArea();
    }    


    
    public /*virtual jag vet inte om vi vill ha en pausmeny än, annars kan den scripten ärva från denna*/ void StartGame()
    {
        //gör så att muspekaren inte är synlig -JR
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //laddar in nästa scene - JR
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
