using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Sagas Kod
public class ClickDrag : MonoBehaviour
{
    RaycastHit hit;

    GameObject selectedObject;
    public GameObject miniGame;

    public static bool isDragging;
    public bool miniGameActive;

    public Vector3 pos;

    public void Start()
    {
        //När man är i start och inte håller på med mini spelet då ska inte någon av mini spelets funktioner fungera. 
        isDragging = false;
        miniGameActive = false;
    }

    public void MiniGame()
    {
        //Men nu när minispelet är igång då ska funktionerna vara igång
        miniGame.SetActive(true);
        miniGameActive = true;
    }

    void Update()
    {
        //När man trycker ner höger musknapp då ska..
        if (Input.GetMouseButtonDown(0))
        {
            //Raycastens position vara muspositionen
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                //string tag = hit.collider.gameObject.tag;
                if (hit.collider.gameObject.CompareTag("ElectricBox"))
                {
                    //Om raycasten träffar ett object som har namnet Electricbox då ska minispelet gå igång via funktionen MiniGame
                    MiniGame();
                }

                if (hit.collider != null)
                {
                    //Om vi har klickat på något sätter vi gameobjectet selectedGameobject till det som nyss blivit klickat på
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        //Om man trycker på spelaren i minispeket i form av en kub då ska boolen isDragging bli true för att man ska kunna röra på spelaren med musens position
                        selectedObject = hit.collider.gameObject;
                        isDragging = true;
                        //selectedObject blir till det man klickar oå tex Cube och Sphere. isDragging är också true
                    }

                }
            }

        }

        if (isDragging)
        {
            float horizontal = Input.GetAxis("Mouse X");
            float vertical = Input.GetAxis("Mouse Y");
            selectedObject.transform.localPosition += new Vector3(horizontal, vertical, 0) * 10 * Time.deltaTime;
            /*
            pos = MousePos();
            selectedObject.transform.position = pos;
            selectedObject.transform.localPosition = new Vector3(selectedObject.transform.localPosition.x, selectedObject.transform.localPosition.y,-0.07f);
            //selectedObject.transform.localPosition = new Vector3(selectedObject.transform.position.x, selectedObject.transform.position.y, 0);
            */
        }
        
        if (PlayerTrigger.returnHome)
        {
            isDragging = false;
        }
    }
    Vector3 MousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Mathf.Abs(Camera.main.transform.position.z);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        return mousePos;
    }
}
