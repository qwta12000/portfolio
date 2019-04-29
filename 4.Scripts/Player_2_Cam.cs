using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_2_Cam : MonoBehaviour
{

    public Transform player_tg;
    private Vector3 axisVec;
    private float dist = 3.0f;


    void Start()
    {
        
    }

    
    public void distzoom()
    {
        transform.position = Vector3.Lerp(transform.position, player_tg.position, (5 + MgerClass.InstFunc.speed * 2) * Time.deltaTime);
        axisVec = transform.forward * -1;
        axisVec *= dist;
        transform.position = transform.position + axisVec;
        transform.LookAt(player_tg);
    }



    void Update()
    {
        distzoom();
    }
}
