using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastobj : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject[] pointRayCast;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //this.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 getinffe()
    {


        return new Vector3(1, 1, 3);
    }
}
