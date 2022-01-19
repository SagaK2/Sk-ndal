using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LightSettings : MonoBehaviour
{
    //Sagas kod
    public Light directionalLight;
    public Light gameDirLight;
    public Light gamePonLight;

    public Slider slider;
    
    public void LightStrenght()
    {
        //Varje gång slider värdet ändras, ändras styrkan på ljuset också
        directionalLight.intensity = slider.value;
        //Man vill också att det här ska gälla i spelet så jag har gjort ljusen från spelet till prefabs och gjort
        // så att om ljuset i menyn ändras då ska ljusen i spelet ändras lika mycket
        gameDirLight.intensity = directionalLight.intensity;
        gamePonLight.intensity = directionalLight.intensity;
    }

}
