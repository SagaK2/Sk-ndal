using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDrag : MonoBehaviour
{
    //Sagas Kod
    RaycastHit hit;

    GameObject selectedObject;
    bool isDragging;

    void Start()
    {
        isDragging = false;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray, out hit))
            {
                string tag = hit.collider.gameObject.tag;
                //print(tag); Tar bort den for the moment

                //Man kan skriva en kod för texten här
            }

            if(hit.collider != null)
            {
                //Om vi har klickat på något sätter vi gameobjectet selectedGameobject till det som nyss blivit klickat på
                selectedObject = hit.collider.gameObject;
                isDragging = true;
                //selectedObject blir till det man klickar oå tex Cube och Sphere. isDragging är också true
            }


        }else if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging == true)
        {
            Vector3 pos = MousePos();
            selectedObject.transform.position = pos;
        }
    }
    Vector3 MousePos()
    {
        //Fråga Tobias om det finare sättet att skriva musens alla koordinater istället för att rabbla upp de tre (via en variabel)
        return Camera.main.ScreenToViewportPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
    }
}
