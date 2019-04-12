using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MoveBoids : MonoBehaviour
{
    public float widthObj;
    public float separ;
    public float alig;
    public float cohe;
    public bool debugArrow;
    public float velocity;
    private Vector3 intPosition;
    // Start is called before the first frame update
    void Start()
    {
        intPosition = transform.position;
    }

    // Update is called once per frame  
    void Update()
    {
        Vector3 direction = transform.TransformDirection(new Vector3(intPosition.x - transform.position.x, 0, cohe));
        if (debugArrow)
        {
            DebugExtension.DebugArrow(transform.position, direction, Color.blue);
            //DebugExtension.DrawCircle(transform.position,Vector3.up, Color.red, alig);
            DebugExtension.DebugCircle(transform.position, Vector3.up, Color.red, alig);
            DebugExtension.DebugPoint(transform.position + new Vector3(3 * transform.localScale.x / 2 , -0.4f, 0),Color.yellow, 0.20f);
            DebugExtension.DebugPoint(transform.position + new Vector3(-3 * transform.localScale.x / 2, -0.4f, 0), Color.yellow, 0.20f);

        }
        GameObject[] allBoids;
        allBoids = GameObject.FindGameObjectsWithTag("Boids");

        for(int i = 0; i < allBoids.Length; i++)
        {
            Vector3 foceBoids = Vector3.zero;
            ref GameObject obj = ref allBoids[i];
            if(obj.transform.position.z > transform.position.z  && obj.transform.position.z < transform.position.z + alig  && obj.GetComponent<Rigidbody>().velocity.magnitude < this.GetComponent<Rigidbody>().velocity.magnitude)
            {

                RaycastBoids rB = obj.GetComponent<RaycastBoids>();
                raycastObj objHit = rB.Raycast(widthObj);


                if (!objHit.right && transform.TransformDirection(objHit.ptRight - transform.position).x > 0 )
                {
                    foceBoids = transform.TransformDirection(objHit.ptRight - transform.position);
                }

                if(!objHit.left && transform.TransformDirection(objHit.ptLeft - transform.position).x < 0)
                {
                    foceBoids = transform.TransformDirection(objHit.ptLeft - transform.position);
                }

                if (debugArrow)
                {
                    //Debug.LogWarning(" magnitude: " + foceBoids.magnitude);
                    DebugExtension.DebugArrow(transform.position, foceBoids.normalized, Color.cyan);
                }

            }

            direction += foceBoids*10;
        }


        direction.Normalize();
        if (debugArrow)
        {
            DebugExtension.DebugArrow(transform.position, direction , Color.red);

        }
        this.GetComponent<Rigidbody>().AddForce(direction.normalized, ForceMode.Impulse);

        this.GetComponent<Rigidbody>().velocity = this.GetComponent<Rigidbody>().velocity.normalized * velocity;
    }


    public void setWidthObj(float _widthObj)
    {
        widthObj = _widthObj;
    }

    private void OnCollisionEnter(Collision collision)
    {

    }

}
