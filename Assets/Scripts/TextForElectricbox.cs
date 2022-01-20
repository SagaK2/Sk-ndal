using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class TextForElectricbox : MonoBehaviour
{
   //Luvas kod
    public GameObject text; //Referens till text gameobject
    public Text dialog; //Referens till UI:n vad som står.
    public int dialogcounter = 0;// Visar att dialog countern är på 0 när man börjar
  
    public bool showText = false; //Betyder att showtext är falsk i början
   
    public void Start()
    {
        
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && showText)//Om man klickar T och Showtext är sann?
        {
            dialogcounter += 1; //Dialogcounter ökar med en varje gång man trycker på T

            switch (dialogcounter) //Switch till Dialogcounter så att när man trycker T igen ska Nästa Case hända
            {
                case 1: //Gör så att när man trycker T igen så kommer första Dialogen upp
                    dialog.text = "You cant open this now";

                    break;

                case 2:
                    dialog.text = "Try another electric box";

                    break;
              
            }
        }
    }

    public void OnTriggerStay(Collider collision)
    {
        print("ele");
        if (collision.transform.tag == "talk") //Om man är inaför collisonen
        {
            text.SetActive(true); //Kommer UI:n inte att synas
            if (!showText) //Om showtexten är false
            {
                dialog.text = "Press 'E'"; //Gör så att om du går in i colliderna så kommer texten "press T" komma fram
            }
            showText = true; //Gör att om man är innanför collisonen så är showText sann
            Debug.Log("Showtext");
        }
    }
    public void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "talk")  //Om man inte är inaför collisonen
        {
            text.SetActive(false); //Kommer UI:n inte att synas
            showText = false; //Showtext blir false
        }
    }

    
}

