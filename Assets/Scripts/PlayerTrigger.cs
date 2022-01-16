using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    //Sagas kod
    Vector3 startPos;
    public static bool returnHome;

    //För att kunna avklara spelet, så att man inte på riktigt är fast där
    public GameObject miniGame;
    public GameObject lamp;
    public Light lampLight;
    Color lampColor;

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
            miniGame.SetActive(false);
            //röd FF0000
            lampColor.r = 0;
            lampColor.g = 255;
            lampColor.b = 4;
            lampColor.a = 255;
            lampLight.color = lampColor;
            //Lampan ska lysa grönt
        }
    }

}
