using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    //Kommer använda funktionerna(?) med knapparna i Unity - Saga 

    public GameObject optionMenu;
    public /*virtual jag vet inte om vi vill ha en pausmeny än, annars kan den scripten ära från denna*/ void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public /*virtual*/ void EndGame()
    {
        Application.Quit();
    }
}
