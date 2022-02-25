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
    float randomThings; //Används för att sätta igång olika animationer och annat - Saga
    float timer;

    //Rörelse runt mappen - Saga
    //public GameObject player;
    public NavMeshAgent mob;
    public float distanceGhoulmar = 20;
    float gotYouDistance = 6;
    public Transform[] patrolpoints;
    public Transform playerPoint;
    int currentPatrolPoint;

    //Här och ner är Sagas kod enbart
    void Start()
    {
        mob.GetComponent<NavMeshAgent>();
        //Vill att man ska starta med att vara Idle
        animator.SetBool("Idle", true);
    }

    public void Reset()
    {
        //Så att det blir variation mellan att titta runt och gå runt. Genom att starta om timern efter ett visst nummer 
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
        
        
        if (distance < distanceGhoulmar)
        {
            //Gör så att Ghoulmar alltid är faced mot spelaren när den jagar 
            //mob.SetDestination(player.transform.position);
            mob.SetDestination(playerPoint.position);
            mob.speed = 5;
            mob.isStopped = false;
            animator.SetBool("Running", true);
            print("distance " + distance);

            if (Vector3.Distance(mob.transform.position, playerPoint.position) < 0.8f)
            {
                //När Ghoulmar är tillräckligt nära spelaren (mindre än 0.8f) ska den flyttas till en jumpscrae scen
                SceneManager.LoadScene(4);
            }

        }
        else
        {
            //Om den inte har någonting att jaga är det bara att gå tillbaka till det vanliga 
            
            if (randomThings > 4 && randomThings < 10)
            {
                //När randomthings är på ett av numrena mellan 5-9 då ska den patrullera, den ska gå mot punkterna jag lagt ut på banan som finns i listan
                mob.SetDestination(patrolpoints[currentPatrolPoint].position);

                if (Vector3.Distance(mob.transform.position, patrolpoints[currentPatrolPoint].position) < 1)
                {
                    //Om Ghoulmar är närmare än 
                    //Varför händer inte den här koden?
                    print("next" + currentPatrolPoint);
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
            else if (randomThings > 1 && randomThings < 5)
            {
                //mob.isStopped = true;
                animator.SetBool("Looking", true);
                animator.SetBool("Idle", false);
                animator.SetBool("Walking", false);
            }
        }

        if (timer > 5)
        {
            //Den här if-satsen gör så att variationen blir större. Så att den inte gör en animation för länge
            Reset();
        }

    }
}
