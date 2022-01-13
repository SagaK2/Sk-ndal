using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class LightSettings : MonoBehaviour
{
    //public Color myColor;
    public Light directionalLight;
    public Slider slider;

    float lightStrenght;
    void Start()
    {
        //directionalLight.color = myColor; (Pröva på i andra tillfällen kanske)
        directionalLight.intensity = lightStrenght;
        
    }

    public void LightStrenght()
    {
        //Gör så att float värdet stämmer in på sliderns float värde.
        //lightStrenght = slider.value;
    }
}
