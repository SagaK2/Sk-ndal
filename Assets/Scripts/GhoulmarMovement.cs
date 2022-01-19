using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GhoulmarMovement : MonoBehaviour
{
    //Sagas kod
    public Animator animator;

    float randomThings; //Används för att sätta igång olika animationer och annat
    float timer;

    //Rörelse runt mappen
    public GameObject player;
    public NavMeshAgent mob;
    public float distanceGhoulmar = 5;
    public Transform[] patrolpoints;
    int currentPatrolPoint;

    /*RaycastHit hit;

    bool walking;
    bool running;*/
    void Start()
    {
        mob.GetComponent<NavMeshAgent>();
        animator.SetBool("Idle", true);
        //Vill att man ska starta med att vara Idle
        
    }

    public void Reset()
    {
        //Så att det blir variation mellan att titta runt och gå runt
        print("reset");
        timer = 0;
        randomThings = Random.Range(1, 10);
        //mob.updateRotation = true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        print(randomThings);
        mob.updateRotation = true;
        //För att kunna springa till spelaren om den är i räckhåll
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < distanceGhoulmar)
        {
            print("ahhh");
            //Gör så att Ghoulmar alltid är faced mot spelaren när den jagar 
            mob.SetDestination(player.transform.position);
            mob.speed = 5;
            mob.isStopped = false;

            // animator.SetBool("Running", true);
        }
        else
        {
            print("yes");
            //Reset();
            //Om den inte har någonting att jaga är det bara att gå tillbaka till det vanliga
            //Animationer till Ghoulmar
            if (randomThings > 1 && randomThings < 5) //Om animationen Idle är true och searching är större än 10 då ska Ghoulmar titta runt
            {
                mob.isStopped = true;
                animator.SetBool("Looking", true);
                animator.SetBool("Idle", false);
                animator.SetBool("Walking", false);
                //Ville göra så att Ghoulmar randomly tittar runt

            }
            else if (randomThings > 4 && randomThings < 10)
            {
                print("Go Ghoulmar, go Ghoulmar!");
                mob.SetDestination(patrolpoints[currentPatrolPoint].position);

                if (Vector3.Distance(mob.transform.position, patrolpoints[currentPatrolPoint].position) < 0.05f)
                {
                    print("next");
                    currentPatrolPoint++;
                    if (currentPatrolPoint > patrolpoints.Length - 1)
                    {
                        currentPatrolPoint = 0;
                    }
                }

                animator.SetBool("Idle", false);
                animator.SetBool("Looking", false);
                animator.SetBool("Walking", true);

            }
        }

        

        if (timer > 5)
        {
            Reset();
            //Den här if-satsen gör så att variationen blir större. Så att den inte gör en animation för länge
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        print("collider");
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(5);

        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print("hit");
        if (hit.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(5);
        }
    }
}
