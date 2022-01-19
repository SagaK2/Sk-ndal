using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhoulmarSounds : MonoBehaviour
{
    //skapar en lista i inspectorn där jag kan lägga in ljudfiler
    public List<AudioClip> soundtrack;
    //En variabel för ljudkällan den skulle lika gärna kunna heta "musik" eller nåt men orkaaaaaaaaaaaaaa.
    AudioSource mySource;
    private void Awake()
    {
        //en referens till ljudkällan och vart den ska ta ljudfilen från.
        mySource = gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {      //Ifall en låt ska spelas så väljer den en låt slumpmässigt mellan 10 olika låtar och spelar upp den.
        if (!mySource.playOnAwake)
        {
            mySource.clip = soundtrack[1];
            mySource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {   //Ifall en låt spelat klart så väljer den en ny slumpmässig låt bland dessa 10 ljudfiler.
        if (!mySource.isPlaying)
        {
            mySource.clip = soundtrack[1];
            mySource.Play();
        }

    }
}


