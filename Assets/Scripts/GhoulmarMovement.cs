using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulmarMovement : MonoBehaviour
{
    //Sagas kod
    public Rigidbody rb;
    void Start()
    {
        
    }

    
    void Update()
    {
        rb.velocity = new Vector3(-2, 0, 0);
    }
}
