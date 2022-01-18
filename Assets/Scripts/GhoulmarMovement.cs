using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GhoulmarMovement : MonoBehaviour
{
    //Sagas kod
    public Rigidbody rb;
    public Animator animator;

    float randomThings; //Används för att sätta igång olika animationer och annat
    float timer;

    Vector3 direction;
    float speed = 2;

    //Rörelse runt mappen
    public GameObject player;
    public NavMeshAgent mob;
    public float distanceGhoulmar = 5;

    /*RaycastHit hit;

    bool walking;
    bool running;*/
    void Start()
    {
        mob.GetComponent<NavMeshAgent>();
    }

    public void Reset()
    {
        print("reset");
        timer = 0;
        randomThings = Random.Range(1, 10);
    }
    void Update()
    {
        timer += Time.deltaTime;
        print(randomThings);
        //För att kunna springa till spelaren om den är i räckhåll
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if(distance < distanceGhoulmar)
        {

            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;

            mob.SetDestination(newPos);
            mob.speed = 5;
            //Fråga Tobias hur man gör så att den alltid är faced mot playern 
            animator.SetBool("Running", true);
            print("run");
        }
        else
        {
            animator.SetBool("Running", false);
            Reset();
        }

        //Animationer till Ghoulmar
        if(randomThings >= 1 && randomThings <= 5) //Om animationen Idle är true och searching är större än 10 då ska Ghoulmar titta runt
        {
            //print("looking");
            animator.SetBool("Looking", true);
            animator.SetBool("Idle", false);
            //Ville göra så att Ghoulmar randomly tittar runt. Han glider runt?
            

        }else if(randomThings >= 5 && randomThings >= 10)
        {
            //print("walking");
            rb.velocity = new Vector3(0, 0, 2);
            //rb.velocity = new Vector3( 0, 0, direction.z + speed);
            animator.SetBool("Idle", false);
            animator.SetBool("Looking", false);
            animator.SetBool("Walking", true);
           
        }

        if (timer > 5)
        {
            Reset();
        }

        /*else if(Raycast har hittat playern då ska den ändra velocity och börja springa){
            Fråga Tobias
        }*/

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            print("hit");
            rb.velocity = new Vector3(direction.x * -1, 0, 0);
        }
    }
}
