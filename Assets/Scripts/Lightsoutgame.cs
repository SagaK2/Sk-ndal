using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Lightsoutgame : MonoBehaviour
{
    // Luvas kod
    public int y;
    public int x;

    //Ger mig en lista av buttons och spaces
    public GameObject[] buttons;
    public bool[] spaces;

   
    public Color activated;
    public Color inactivated;

    public Text winText;
    public GameObject panelWinner;

    public void Start() //Dessa funktioner aktiveras vid start
    {
        Near();
        Activateb();
    }

    private void Update() //Dessa funktioner aktiveras efter start
    {
        Hitting();
        Win();
    }

    public void Changeactivity(int who) //Det här är hur knapparna ändrar färg, de ändras med hjälp av två states activated och inactivated
    {
        spaces[who] = !spaces[who];
        buttons[who].GetComponent<Image>().color = spaces[who] ? activated : inactivated;
    }

    void Near(int MaxValue = 2) //När man startar spelet sätter den ett value till alla spaces och om det är sant så är knappen aktiverad om den är falsk så är den inaktiverad
    {
        for(int i = 0; i < spaces.Length; i++)
        {
            spaces[i] = (Random.Range(0, MaxValue) == 0);
        }
    }

    public void Win()
    {
        //Om alla spaces är falska så kommer det fram en vinnar text
        if (spaces[0] == false && spaces[1] == false && spaces[2] == false && spaces[3] == false && spaces[4] == false
            && spaces[5] == false && spaces[6] == false && spaces[7] == false && spaces[8] == false && spaces[9] == false
            && spaces[10] == false && spaces[11] == false && spaces[12] == false && spaces[13] == false && spaces[14] == false &&
            spaces[15] == false && spaces[16] == false && spaces[17] == false && spaces[18] == false && spaces[19] == false
            && spaces[20] == false &&
            spaces[21] == false && spaces[22] == false && spaces[23] == false && spaces[24] == false)
        {
            winText.text = "Good job!";
            panelWinner.SetActive(true);
            Inactivateb();
        }

    }

    public void Activateb()
    {
        Changeactivity(0);
        Changeactivity(1);
        Changeactivity(2);
        Changeactivity(3);
        Changeactivity(4);
        Changeactivity(5);
        Changeactivity(6);
        Changeactivity(7);
        Changeactivity(8);
        Changeactivity(9);
        Changeactivity(10);
        Changeactivity(11);
        Changeactivity(12);
        Changeactivity(13);
        Changeactivity(14);
        Changeactivity(15);
        Changeactivity(16);
        Changeactivity(17);
        Changeactivity(18);
        Changeactivity(19);
        Changeactivity(20);
        Changeactivity(21);
        Changeactivity(22);
        Changeactivity(23);
        Changeactivity(24);
    }// Detta gör så att under spelet är alla knappar antingen på eller av

    public void Inactivateb()
    {
        buttons[1].GetComponent<BoxCollider2D>().enabled = false;
        buttons[2].GetComponent<BoxCollider2D>().enabled = false;
        buttons[3].GetComponent<BoxCollider2D>().enabled = false;
        buttons[4].GetComponent<BoxCollider2D>().enabled = false;
        buttons[5].GetComponent<BoxCollider2D>().enabled = false;
        buttons[6].GetComponent<BoxCollider2D>().enabled = false;
        buttons[7].GetComponent<BoxCollider2D>().enabled = false;
        buttons[10].GetComponent<BoxCollider2D>().enabled = false;
        buttons[11].GetComponent<BoxCollider2D>().enabled = false;
        buttons[12].GetComponent<BoxCollider2D>().enabled = false;
        buttons[13].GetComponent<BoxCollider2D>().enabled = false;
        buttons[14].GetComponent<BoxCollider2D>().enabled = false;
        buttons[15].GetComponent<BoxCollider2D>().enabled = false;
        buttons[16].GetComponent<BoxCollider2D>().enabled = false;
        buttons[17].GetComponent<BoxCollider2D>().enabled = false;
        buttons[18].GetComponent<BoxCollider2D>().enabled = false;
        buttons[19].GetComponent<BoxCollider2D>().enabled = false;
        buttons[20].GetComponent<BoxCollider2D>().enabled = false;
        buttons[21].GetComponent<BoxCollider2D>().enabled = false;
        buttons[22].GetComponent<BoxCollider2D>().enabled = false;
        buttons[23].GetComponent<BoxCollider2D>().enabled = false;
        buttons[24].GetComponent<BoxCollider2D>().enabled = false;
    }//Detta är när man avklarat spelet då alla knappar är av.

    public void Hitting() //När man klickar ned musen så ändras knapparnas granne
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
           

            if (hit.collider.CompareTag("0"))
            {
                Changeactivity(1);
                Changeactivity(5);

            }
            if (hit.collider.CompareTag("1"))
            {
                Changeactivity(0);
                Changeactivity(2);
                Changeactivity(6);
            }
            if (hit.collider.CompareTag("2"))
            {

                Changeactivity(1);
                Changeactivity(3);
                Changeactivity(7);
            }
            if (hit.collider.CompareTag("3"))
            {
                Changeactivity(2);
                Changeactivity(4);
                Changeactivity(8);
            }
            if (hit.collider.CompareTag("4"))
            {
                Changeactivity(3);
                
                Changeactivity(9);
            }
            if (hit.collider.CompareTag("5"))
            {
                Changeactivity(0);
                Changeactivity(6);
                Changeactivity(10);
            }
            if (hit.collider.CompareTag("6"))
            {
                Changeactivity(5);
                Changeactivity(7);
                Changeactivity(11);
                Changeactivity(1);

            }
            if (hit.collider.CompareTag("7"))
            {
                Changeactivity(6);
                Changeactivity(8);
                Changeactivity(12);
                Changeactivity(2);
            }
            if (hit.collider.CompareTag("8"))
            {
                Changeactivity(7);
                Changeactivity(9);
                Changeactivity(13);
                Changeactivity(3);
            }
            if (hit.collider.CompareTag("9"))
            {
                Changeactivity(8);
                Changeactivity(4);
                Changeactivity(14);
            }
            if (hit.collider.CompareTag("10"))
            {
                Changeactivity(11);
                Changeactivity(5);
                Changeactivity(15);
            }
            if (hit.collider.CompareTag("11"))
            {
                Changeactivity(10);
                Changeactivity(12);
                Changeactivity(16);
                Changeactivity(6);
            }
            if (hit.collider.CompareTag("12"))
            {
                Changeactivity(11);
                Changeactivity(7);
                Changeactivity(17);
                Changeactivity(13);
            }
            if (hit.collider.CompareTag("13"))
            {
                Changeactivity(12);
                Changeactivity(14);
                Changeactivity(18);
                Changeactivity(8);
            }
            if (hit.collider.CompareTag("14"))
            {
                Changeactivity(13);
                Changeactivity(9);
                Changeactivity(19);
            }
            if (hit.collider.CompareTag("15"))
            {
                Changeactivity(10);
                Changeactivity(16);
                Changeactivity(20);
            }
            if (hit.collider.CompareTag("16"))
            {
                Changeactivity(15);
                Changeactivity(17);
                Changeactivity(21);
                Changeactivity(11);
            }
            if (hit.collider.CompareTag("17"))
            {
                Changeactivity(16);
                Changeactivity(18);
                Changeactivity(22);
                Changeactivity(12);
            }
            if (hit.collider.CompareTag("18"))
            {
                Changeactivity(17);
                Changeactivity(19);
                Changeactivity(23);
                Changeactivity(13);
            }
            if (hit.collider.CompareTag("19"))
            {
                Changeactivity(18);
                Changeactivity(14);
                Changeactivity(24);
            }
            if (hit.collider.CompareTag("20"))
            {
                
                Changeactivity(21);
                Changeactivity(15);
            }
            if (hit.collider.CompareTag("21"))
            {
                Changeactivity(16);
                Changeactivity(20);
                Changeactivity(22);
            }
            if (hit.collider.CompareTag("22"))
            {
                Changeactivity(17);
                Changeactivity(23);
                Changeactivity(21);
            }
            if (hit.collider.CompareTag("23"))
            {
                Changeactivity(18);
                Changeactivity(24);
                Changeactivity(22);
            }
            if (hit.collider.CompareTag("24"))
            {
                Changeactivity(19);
                Changeactivity(23);
            }


        }
    }
}
