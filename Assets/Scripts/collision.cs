using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class collision : MonoBehaviour
{
    //Sagas kod
    public GameObject text;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Ghoulmar"))
        {
            //Då när Ghoulmar rört vid än, då ska en annan scen med en jumpscare dyka upp
            SceneManager.LoadScene(4);

        }else if (hit.gameObject.CompareTag("ToClose"))
        {
            //Man är för nära skåpet när man nuddar denna collider. Därför poppar det upp en text som säger att an inte borde vara det
            text.SetActive(true);
        }
        else
        {
            //Man ska annars inte se texten eller när man är för nära/nuddar vid collidern
            text.SetActive(false);
        }
    }
}
