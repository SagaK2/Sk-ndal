using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Sagas kod
public class PlayerTrigger : MonoBehaviour
{
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
        //För att man ska kunna transporteras till samma position man startar på gör jag en vector som är vart spelaren är i start
        startPos = transform.position;
        //Man ska inte kunna gå igneom collider väggar runt banan. Men man 
        returnHome = false;
    }

    void Update()
    {
        if (transform.position == startPos)
        {
            //Om man transporterats tillbaka till start ska man inte hela tiden fortsätta åka tillbaka för att man kör
            returnHome = false;
        }
        else if(returnHome)
        {
            //Men om man nuddat en vägg och returnHome blir sann då ska man transporteras till start positionen som sparades i början
            transform.position = startPos;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //Om spelaren nuddar väggen i minispelet.. 
        if (collider.gameObject.CompareTag("Wall"))
        {
            //Kommer den transporteras hem igen
            returnHome = true;
        }
        else if (collider.gameObject.CompareTag("Finish"))
        {
            //Men om man nuddar collider väggen vid målet.. 
            clickDrag.Start();
            //Då sätts isDragging till false eftersom den annars sätts till false
            movement.Start();
            //Som sätter curser lock till locked mode
            movement.PlayerMovement();
            //Man kommer kunna röra sig igen som vanligt
            ghoulmar.SetActive(true);
            //Ghoulmar sätts på
            miniGame.SetActive(false);
            //minigamet försvinner i syne
            lampLight.color = lampColor;
            //Färgen som annars lyser rött blir till färgen man valt i unity som just nu är grön



            //SceneManager.LoadScene(3); Skickade spelaren till end scene men man måste nu ha tre ellådor inte bara en
        }
    }

}
