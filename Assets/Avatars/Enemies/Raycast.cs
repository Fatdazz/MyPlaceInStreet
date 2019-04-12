using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    //bool debug = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        RaycastHit Hit;
        Physics.Raycast(this.transform.position,direction ,out Hit, 15);
        //Debug.DrawRay(transform.position, direction, Color.blue, 15);

    }
}
