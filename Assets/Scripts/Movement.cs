using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //En variabel som gör mus sensitivity till en siffra vi kan ändra i inspektorn. JR
    public float Sensitivity = 100f;
    //En variabel för vårans spelares transform, alltså position, rotation och skala. JR
    public Transform playerModel;
    //
    float Xpos = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //gör så man inte ser musen. JR
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //Gör om musens position till en float som kan sparas. JR
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        //Varje frame minskar x-rotationen baserat på mouse Y. JR
        Xpos -= mouseY;
        Xpos = Mathf.Clamp(Xpos, -90f, 90f);
        //Gör så man inte kan bryta nacken genom att kolla bakom sig på Y-axeln. JR
        transform.localRotation = Quaternion.Euler(Xpos, 0f, 0f);
        //Rotera runt spelarens Y-axel när man rör runt musen på X-axeln. JR
        playerModel.Rotate(Vector3.up * mouseX);
    }
}
