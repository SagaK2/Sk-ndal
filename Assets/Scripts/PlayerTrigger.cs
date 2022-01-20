using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour
{
    //Sagas kod
    Vector3 startPos;
    public static bool returnHome;

    //För att kunna avklara spelet, så att man inte på riktigt är fast där
    public GameObject miniGame;
    public Light lampLight;
    public Color lampColor;
    //Gjorde den public så att den inte ändras, det var så att färgen ändrades lite här och där. 

    public ClickDrag clickDrag;
    public Movement movement;

    public GameObject ghoulmar;

    void Start()
    {
        startPos = transform.position;
        returnHome = false;
    }

    public void Return()
    {
        returnHome = true;
    }

    void Update()
    {
        if (transform.position == startPos)
        {
            returnHome = false;
        }
        else if(returnHome)
        {
            transform.position = startPos;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Wall"))
        {
            Return();
            
        }
        else if (collider.gameObject.CompareTag("Finish"))
        {
            clickDrag.Start();
            //Då sätts isDragging till false eftersom den annars sätts till false
            movement.Start();
            movement.PlayerMovement();
            //Som sätter curser lock till locked mode
            ghoulmar.SetActive(true);
            //Ghoulmar sätts på
            miniGame.SetActive(false);
            //röd FF0000
            lampLight.color = lampColor;
            //Lampan ska lysa grönt, animation
            SceneManager.LoadScene(0);
            Cursor.lockState = CursorLockMode.None;

        }
    }

}
