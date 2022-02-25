using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonclicknoise : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource buttonnoise;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            buttonnoise.Play();
        }
    }
}
