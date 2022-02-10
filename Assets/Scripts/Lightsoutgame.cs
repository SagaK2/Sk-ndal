using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Lightsoutgame : MonoBehaviour
{
    public int y;
    public int x;

    public GameObject[] buttons;
    public bool[] spaces;
    public Color activated;
    public Color inactivated;

    public Text winText;
    public GameObject panelWinner;

    public void Start()
    {
        Near();
        Activateb();
    }

    private void Update()
    {
        Hitting();
        Win();
    }

    public void Changeactivity(int who)
    {
        spaces[who] = !spaces[who];
        buttons[who].GetComponent<Image>().color = spaces[who] ? activated : inactivated;
    }

    void Near(int MaxValue = 2)
    {
        for(int i = 0; i < spaces.Length; i++)
        {
            spaces[i] = (Random.Range(0, MaxValue) == 0);
        }
    }

    public void Win()
    {
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
    }

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
    }

    public void Hitting()
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

            }
            if (hit.collider.CompareTag("4"))
            {

            }
            if (hit.collider.CompareTag("5"))
            {

            }
            if (hit.collider.CompareTag("6"))
            {

            }
            if (hit.collider.CompareTag("7"))
            {

            }
            if (hit.collider.CompareTag("8"))
            {

            }
            if (hit.collider.CompareTag("9"))
            {

            }
            if (hit.collider.CompareTag("10"))
            {

            }
            if (hit.collider.CompareTag("11"))
            {

            }
            if (hit.collider.CompareTag("12"))
            {

            }
            if (hit.collider.CompareTag("13"))
            {

            }
            if (hit.collider.CompareTag("14"))
            {

            }
            if (hit.collider.CompareTag("15"))
            {

            }
            if (hit.collider.CompareTag("16"))
            {

            }
            if (hit.collider.CompareTag("17"))
            {

            }
            if (hit.collider.CompareTag("18"))
            {

            }
            if (hit.collider.CompareTag("19"))
            {

            }
            if (hit.collider.CompareTag("20"))
            {

            }
            if (hit.collider.CompareTag("21"))
            {

            }
            if (hit.collider.CompareTag("22"))
            {

            }
            if (hit.collider.CompareTag("23"))
            {

            }
            if (hit.collider.CompareTag("24"))
            {

            }


        }
    }
}
