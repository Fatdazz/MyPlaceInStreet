using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sawn : MonoBehaviour
{
    public GameObject object_creat;
    public Vector3 speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.A))
        {

            //gameObject obj=Instantiate(Resources.Load("Player1", typeof(GameObject)));
            //GameObject obj = Instantiate(object_creat);
            //obj.transform.position = this.transform.position;
            //obj.GetComponent<Rigidbody>().velocity.Set(0, 100, 0);
            //obj.GetComponent<Rigidbody>().velocity.Set(speed.x,speed.y,speed.z);
            //obj.GetComponent<CaracterMotorEnemi>().velocityEnemi = speed;
            //obj.tag = "alex";

                        //obj.GetComponent<CaracterMotor>().angleMax = 0;

        }
    }
}

