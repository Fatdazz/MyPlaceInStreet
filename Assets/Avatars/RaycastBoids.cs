using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct raycastObj
{
    public bool left;
    public bool right;
    public Vector3 ptLeft;
    public Vector3 ptRight;
    public GameObject HitObj;
    public MoveBoids HitMoveBoids;
    public Rigidbody HitRb;
}

public class RaycastBoids : MonoBehaviour
{
    public bool debugDraw;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public raycastObj Raycast(float _distance)
    {
        Vector3 positionRight = new Vector3(transform.position.x + transform.localScale.x/2, transform.position.y - 0.4f, transform.position.z);
        Vector3 positionleft = new Vector3(transform.position.x - transform.localScale.x/2, transform.position.y - 0.4f, transform.position.z);

        raycastObj objHit;
        RaycastHit Hit_1,Hit_2 ;
        objHit.HitObj = gameObject;
        objHit.HitMoveBoids = gameObject.GetComponent<MoveBoids>();
        objHit.HitRb = gameObject.GetComponent<Rigidbody>();
        objHit.right = Physics.Raycast(positionRight, transform.TransformDirection(Vector3.right),out Hit_1, _distance);
        objHit.left = Physics.Raycast(positionleft, transform.TransformDirection(Vector3.left),out Hit_2, _distance);
        objHit.ptLeft = positionleft + Vector3.left * _distance/2;
        objHit.ptRight = positionRight + Vector3.right * _distance/2; 

        if (debugDraw)
        {
            DebugExtension.DebugArrow(positionRight, transform.TransformDirection(Vector3.right)*_distance, Color.magenta);
            DebugExtension.DebugArrow(positionleft, transform.TransformDirection(Vector3.left)*_distance, Color.magenta);
            DebugExtension.DebugPoint(objHit.ptLeft, Color.magenta, 0.20f);
            DebugExtension.DebugPoint(objHit.ptRight, Color.magenta, 0.20f);

        }

        if(objHit.left|| objHit.right)
        {
            //Debug.LogWarning(" Je touche un bord ");
        }
        return objHit;
    }

}
