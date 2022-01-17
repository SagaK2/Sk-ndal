using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulmarMovement : MonoBehaviour
{
    //Sagas kod
    public Rigidbody rb;
    public Animator animator;

    float randomThings; //Används för att sätta igång olika animationer och annat
    float timer;

    RaycastHit hit;

    readonly bool walking;
    readonly bool running;
    void Start()
    {
        randomThings = 10;
    }

    public void Reset()
    {
        randomThings = Random.Range(1, 30);
    }
    void Update()
    {
        

        timer += Time.deltaTime;

        print("Searching: " + randomThings + "Velocity:" + rb.velocity + " ... Timer: " + timer);

        if(animator.GetBool("Idle") && randomThings >= 10 && randomThings <= 20) //Om animationen Idle är true och searching är större än 10 då ska Ghoulmar titta runt
        {
            animator.SetBool("Looking", true);
            animator.SetBool("Idle", false);
            //Ville göra så att Ghoulmar randomly tittar runt om Idle animationen är igång
            Reset();

        }else if(randomThings >= 20 && animator.GetBool("Looking") == false)
        {
            //Måste fixa i både kod och annat med float och transitions
            rb.velocity = new Vector3(0, 0, 2);
            animator.SetBool("Idle", false);
            animator.SetBool("Looking", false);
            timer = 0;
            Reset();
            /*if ()
            {
                Gör så att randomThings kan ändras ungefär hela tiden
            }
            */

        }
        /*else if(Raycast har hittat playern då ska den ändra velocity och börja springa){
            Fråga Tobias
        }*/

    }
}
