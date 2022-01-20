using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    //En variabel som gör mus sensitivity till en siffra vi kan ändra i inspektorn. JR
    public float Sensitivity = 100f;
    //En variabel för våran spelares transform, alltså position, rotation och skala. JR
    public Transform spelare;
    //x-rotation vet inte riktigt vad den gör men behövs. JR
    float Xpos = 0f;
    //referens till spelaren
    public CharacterController Player;
    //Låter oss välja vilken hastighet vi rör oss framåt och bakåt i. JR
    public float speed = 12;
    //variabel för vår nuvarande hastighet. JR
    Vector3 Velocity;
    //variabel för gravitation
    public float gravity = -11;
    //Låter mig använda ClickDrag variabler och sånt i detta skript. JR
    public ClickDrag Clickish;

    public GameObject model;

    public Vector3 offset;
    public Transform gameTarget;

    public void Start()
    {
        //gör så man inte ser musen. JR
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Skapar en else sats och flyttar movement för att begränsa beteende när spelet är aktivt - Saga
      if (Clickish.miniGameActive) 
      {
            model.SetActive(false);
            //Ifall minigamet spelas så kan man se musen igen. JR  
            Cursor.lockState = CursorLockMode.None;
            // Spelaren kan inte röra på sig eller titta runt omkring när hen spelar. - Saga
            Player.Move(Velocity * 0);
            
            transform.position = gameTarget.position + (offset);
            transform.LookAt(gameTarget);
            // Spelaren flyttas för att se spelet i full skärm - Saga
            //spelare.transform.position = new Vector3();

      } else
      {
            if (model.activeSelf == false)
            {
                model.SetActive(true);
            }

            PlayerMovement();
      }

    }

    public void PlayerMovement()
    {
        //referens till mouse x och mouse y från unity inputmanager. deltaTime gör så rotationen är oberoende av FPS. JR
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        //Varje frame minskar x-rotationen baserat på mouse Y. JR
        Xpos -= mouseY;
        //Gör så man inte kan bryta nacken när man kollar bakom sig på Y-axeln. JR
        Xpos = Mathf.Clamp(Xpos, -90f, 90f);
        //låter dig rotera (kolla runt in-game). JR
        transform.localRotation = Quaternion.Euler(Xpos, -182, 0f);
        //Rotera runt spelarens Y-axel när man rör runt musen på X-axeln. JR
        spelare.Rotate(Vector3.up * mouseX);

        //Koden Nedan är för att faktiskt röra sig. Borde fungera med kontroll också. JR

        //referenser till inputmanager igen. JR
        float Zmovement = Input.GetAxis("Vertical");
        float xmovement = Input.GetAxis("Horizontal");
        //Väljer en riktning som är i förhållande till spelaren (alltså vänster eller höger istället för väst eller öst). JR
        Vector3 rörelse = transform.right * xmovement + transform.forward * Zmovement;
        //Faktiskt rör oss åt den riktningen. Detta gör också att vi inte rör oss snabbare ifall vi har högre FPS. JR
        Player.Move(rörelse * speed * Time.deltaTime);

        //koden nedan är för gravitation. JR

        //våran fart på y-axeln är gravitationen. JR
        Velocity.y += gravity * Time.deltaTime;
        //Rör spelaren 
        Player.Move(Velocity * Time.deltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print("hit");
        if (hit.gameObject.CompareTag("Ghoulmar"))
        {
            SceneManager.LoadScene(5);
        }
    }
}
