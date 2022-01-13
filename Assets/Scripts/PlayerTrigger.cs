using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wall")
        {
            print("hejda");
            Return();
        }
    }

    void Return()
    {
        transform.position = startPos;
    }
}
