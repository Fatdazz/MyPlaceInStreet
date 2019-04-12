using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CaracterMotorEnemi : MonoBehaviour
{

    public float NormVelocityMax;
    public float NormForceMax;
    public float rayMax;
    public AnimationCurve rayForce;
    public AnimationCurve exitForce;
    public float sigmaDepasement;
    // Start is called before the first frame update
    void Start()
    {
        //this.GetComponent<Rigidbody>().velocity = velocityEnemi;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = Vector3.zero;

        force += forceToExit(force);
        force += forceRay(force);


        force *= NormForceMax;
        GetComponent<Rigidbody>().AddForce(force, ForceMode.Force);

        if (Input.GetKeyDown(KeyCode.B))
        {



        }


    }

    Vector3 forceRay(Vector3 force)
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward);
        Vector3 returnVector3 = Vector3.zero;
        RaycastHit Hit;
        Physics.Raycast(transform.position, direction, out Hit, rayMax);
        Debug.DrawLine(transform.position, transform.position + direction * rayMax, Color.blue);

        if (Physics.Raycast(transform.position, direction, out Hit, rayMax)){
            Vector3 d = transform.position - Hit.point;

            //Debug.LogWarning("vitesse ennemis: " + GetComponent<Rigidbody>().velocity.magnitude + " vitesse Hit: " + Hit.rigidbody.velocity.magnitude);

            if((GetComponent<Rigidbody>().velocity.magnitude > Hit.rigidbody.velocity.magnitude + sigmaDepasement))
            {

                Debug.DrawLine(transform.position, transform.position + direction * rayMax, Color.red);
            }
            else
            {
                returnVector3.z = slowDown(d);
            }

        }
        return returnVector3;
    }

    Vector3 forceToExit(Vector3 force)
    {
        Vector3 returnVec3 = Vector3.zero;
        returnVec3.z = exitForce.Evaluate(GetComponent<Rigidbody>().velocity.magnitude / NormVelocityMax);
        //Debug.LogWarning(1 - (GetComponent<Rigidbody>().velocity.magnitude / velocityMax));

        return returnVec3;
    }


    private float slowDown(Vector3 DisFor2obj)
    {

        return - rayForce.Evaluate(DisFor2obj.magnitude / rayMax);
    }
}
