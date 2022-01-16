using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulmarMovement : MonoBehaviour
{
    //Sagas kod
    public Rigidbody rb;
    public Animator animator;

    bool walking;
    bool running;
    void Start()
    {
        

    }

    
    void Update()
    {
        rb.velocity = new Vector3(0, 0, 2);
    }
}
