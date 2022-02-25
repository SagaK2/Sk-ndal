using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jrs kod
public class GhoulmarSounds : MonoBehaviour
{
    //skapar en lista i inspectorn där jag kan lägga in ljudfiler som ska användas.
    public List<AudioClip> soundtrack;
    //En variabel för ljudkällan.
    AudioSource mySource;
    private void Awake()
    {
        //en referens till ljudkällan och vart den ska ta ljudfilen från.
        mySource = gameObject.GetComponent<AudioSource>();
    }
}


