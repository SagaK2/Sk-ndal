using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class managerlightsout : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
        int count = 1;

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                GameObject tmpGb = Instantiate(Resources.Load("Cube", typeof(GameObject))) as GameObject;
                tmpGb.transform.position = new Vector3(j * 1.5f - 3, i * -1.5f + 3, 0);
                tmpGb.name = count.ToString();
                count++;
            }
        }
        //this.gameObject.GetComponent<levelHandler>().loadLevel(1);
    }

}

    

