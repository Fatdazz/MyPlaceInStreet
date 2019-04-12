using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct Pattern
{
    public int id;
    public GameObject[] items ;
    public Vector3[] retad ;

    public int[] lienExt;
    public float[] lienProb;
}


public class Automate : MonoBehaviour
{
    // Start is called before the first frame update
    Pattern[] patterns;

    void Start()
    {

        for (int i= 0; i< patterns.Length; i++)
        {
            patterns[i].id = i;
        }

    }

    // Update is called once per frame
    void Update()
    {




    }
}
