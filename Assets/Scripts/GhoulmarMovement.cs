using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
//Sagas kod
public class GhoulmarMovement : MonoBehaviour
{
    public Animator animator;
    //Låter mig använda andra variabler i detta skript. JR
    public GhoulmarSounds Ljud;
    float randomThings; //Används för att sätta igång olika animationer och annat
    float timer;

    //Rörelse runt mappen
    //public GameObject player;
    public NavMeshAgent mob;
    public float distanceGhoulmar = 20;
    float gotYouDistance = 6;
    public Transform[] patrolpoints;
    public Transform playerPoint;
    int currentPatrolPoint;

    //RaycastHit hit;
    
    void Start()
    {
        mob.GetComponent<NavMeshAgent>();
        animator.SetBool("Idle", true);
        //Vill att man ska starta med att vara Idle
    }

    public void Reset()
    {
        //Så att det blir variation mellan att titta runt och gå runt
        timer = 0;
        randomThings = Random.Range(1, 10);
        //mob.updateRotation = true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        mob.updateRotation = true;
        //För att kunna springa till spelaren om den är i räckhåll
        float distance = Vector3.Distance(transform.position, playerPoint.position);
        
        /*if (Vector3.Distance(mob.transform.position, playerPoint.position) > 0.8f)
        {
            print("got you");
            /*if (Vector3.Distance(mob.transform.position, playerPoint.position) < 0.4f)
              {
                 //Collidern på Ghoulmar är vid sidan och empty player point är i mitten av playern inte längst upp
                 //SceneManager.LoadScene(4);
              }
        }*/
        
        if (distance < distanceGhoulmar)
        {
            //Gör så att Ghoulmar alltid är faced mot spelaren när den jagar 
            //mob.SetDestination(player.transform.position);
            mob.SetDestination(playerPoint.position);
            mob.speed = 5;
            mob.isStopped = false;
            animator.SetBool("Running", true);
            print("distance " + distance);

            /*if(Vector3.Distance(mob.transform.position, player.transform.position) < 0.1f)
            {
                print("got you");
                SceneManager.LoadScene(4);
            }*/

        }
        

        /*
        else if (Vector3.Distance(mob.transform.position, playerPoint.position) < 4)
        {
            //Collidern på Ghoulmar är vid sidan och empty player point är i mitten av playern inte längst upp
            print("got you");
            SceneManager.LoadScene(4);
        }
         
         */
        else
        {
            //Om den inte har någonting att jaga är det bara att gå tillbaka till det vanliga
            //Animationer till Ghoulmar
            if (randomThings > 1 && randomThings < 5) 
            {
                //mob.isStopped = true;
                animator.SetBool("Looking", true);
                animator.SetBool("Idle", false);
                animator.SetBool("Walking", false);
                //Ville göra så att Ghoulmar randomly tittar runt

            }
            else if (randomThings > 4 && randomThings < 10)
            {
                mob.SetDestination(patrolpoints[currentPatrolPoint].position);

                if (Vector3.Distance(mob.transform.position, patrolpoints[currentPatrolPoint].position) < 0.1f)
                {
                    //Varför händer inte den här koden?
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

    /*void OnCollisionEnter(Collision collision)
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
    }*/
}
