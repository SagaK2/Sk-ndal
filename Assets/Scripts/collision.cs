using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Sagas kod
public class collision : MonoBehaviour
{
    public GameObject toClose;
    public GameObject toBeContinued;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("ToClose"))
        {
            //Man är för nära skåpet när man nuddar denna collider. Därför poppar det upp en text som säger att an inte borde vara det
            toClose.SetActive(true);

        }else if (hit.gameObject.CompareTag("ToBeContinued"))
        {
            //De här lådorna fungerar inte just nu så man kommer få en text då man förstår att de inte fungerar. (Man måste leta efter en annan)
            toBeContinued.SetActive(true);
        }
        else
        {
            //Man ska annars inte se texten eller när man är för nära/nuddar vid collidern
            toClose.SetActive(false);
            toBeContinued.SetActive(false);
        }
    }
    
}
