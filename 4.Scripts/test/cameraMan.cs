using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMan : MonoBehaviour
{

    //private float movespeed = 10;

    public Transform target;
    private Vector3 pos;

    void Start()
    {
        pos = transform.position - target.position;

    }


    void Update()
    {
        if(target != null)
        {
            transform.position = pos + target.position;

        }
        //transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime * (5 + MgerClass.InstFunc.speed * 2));
        //pos = transform.position;
        //transform.position += (target.position - pos) * movespeed;



    }
}
