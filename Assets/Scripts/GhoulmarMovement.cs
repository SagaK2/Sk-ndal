using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulmarMovement : MonoBehaviour
{
    //Sagas kod
    public Rigidbody rb;
    public Animator animator;

    float randomThings; //Används för att sätta igång olika animationer och annat

    readonly bool walking;
    readonly bool running;
    void Start()
    {
        randomThings = Random.Range(1, 30);
    }

    
    void Update()
    {
        print("Searching: " + randomThings + "Velocity:" + rb.velocity);

        if(animator.GetBool("Idle") && randomThings > 8) //Om animationen Idle är true och searching är större än 10 då ska Ghoulmar titta runt
        {
            animator.SetBool("Looking", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Walking", false);
            animator.SetBool("Running", false);
            //Ville göra så att Ghoulmar randomly tittar runt om Idle animationen är igång

        }else if(randomThings >= 20)
        {
            //Måste fixa i både kod och annat med float och transitions
            rb.velocity = new Vector3(0, 0, 2);

        }/*else if(Raycast har hittat playern då ska den ändra velocity och börja springa){

        }*/



    }
}
