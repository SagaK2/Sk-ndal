using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        print("hit");
        if (hit.gameObject.CompareTag("talk"))
        {
            SceneManager.LoadScene(5);
        }
    }
}
