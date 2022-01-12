using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour//, ITakeable
{
    public Camera camera;

    RaycastHit hit;

    void Start()
    {
        camera.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            //Om objektet träffar något. Vad ska den göra
            print("hit");
            //ITakeable take = hit.transform.GetComponent(typeof(ITakeable)) as ITakeable;
            string tag = hit.collider.gameObject.tag;
        }
    }
}
