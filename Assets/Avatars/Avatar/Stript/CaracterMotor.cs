using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaracterMotor : MonoBehaviour
{


    public float speedHorison;
    public float speedRotat;
    public float angleMax;
    public Vector3 angle;
    CapsuleCollider playercollider;
    // Start is called before the first frame update
    void Start()
    {
        playercollider = gameObject.GetComponent<CapsuleCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(speedHorison * Time.deltaTime, 0, 0, Space.World);
        }



        if (Input.GetKey(KeyCode.LeftArrow))
        {


            this.transform.Rotate(0,speedRotat * Time.deltaTime,0);

            angle = this.transform.rotation.eulerAngles;
            if (angle.y > angleMax && angle.y < 360 - angleMax)
            {
                angle.y = angleMax;
            }
            this.transform.rotation = Quaternion.Euler(angle.x, angle.y, angle.z);


        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, - speedRotat * Time.deltaTime, 0);

            angle = this.transform.rotation.eulerAngles;
            if (angle.y > angleMax && angle.y < 360 - angleMax)
            {
                angle.y = - angleMax;
            }
            this.transform.rotation = Quaternion.Euler(angle.x,angle.y,angle.z);
            //this.transform.eulerAngles.Set(angle.x, 0, angle.z);
            Debug.Log("salut");
        }
        angle = this.transform.rotation.eulerAngles;
    }
}
