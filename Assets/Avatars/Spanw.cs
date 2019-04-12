using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spanw : MonoBehaviour
{
    public GameObject objSpanw;
    public GameObject objDestroy;
    public GameObject preFab;
    private float distanceSpanwDestroy;
    public Automate automate;

    void Start()
    {
        distanceSpanwDestroy = Vector3.Distance(objSpanw.transform.position, objSpanw.transform.position);

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.A))
        {
            GameObject obj;
            obj = Instantiate(preFab);
            obj.transform.position = objSpanw.transform.position;
            obj.GetComponent<MoveBoids>().velocity = Random.Range(3.0f, 5.0f); 
        }

    }
}
