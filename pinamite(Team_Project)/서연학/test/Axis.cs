using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : MonoBehaviour
{
    public Quaternion tgrot;
    public Transform camvec;
    private Vector3 gap;
    private Transform tg;
    
    private float distance = 5;
    private Vector3 Axisvec;
    public Transform cam;
    private float zomspeed = 5;

    void Start()
    {
        tg = GameObject.FindGameObjectWithTag("player_2").transform;
        cam = cam.transform;
    }

    public void Discam()
    {

        distance += Input.GetAxis("Mouse ScrollWheel") * zomspeed * -1;
        distance = Mathf.Clamp(distance, 3f, 20f);

        Axisvec = transform.forward * -1;
        Axisvec *= distance;
        cam.position = transform.position + Axisvec;
    }


    public void camrot()
    {
        if(transform.rotation != tgrot)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, tgrot, 10f * Time.deltaTime);

        }

        if(Input.GetMouseButton(1))
        {
            
            transform.Rotate(Vector3.up * Time.deltaTime * 3f * Input.GetAxis("Mouse X"));

            //float rotspeed = (5 + MgerClass.InstFunc.speed * 2) * Time.deltaTime;

            gap.x += Input.GetAxis("Mouse Y") * 3f * -1;
            gap.y += Input.GetAxis("Mouse X") * Time.deltaTime * 100f;
            //gap.y += Input.GetAxis("Mouse X") * (5 + MgerClass.InstFunc.speed * 2)*Time.deltaTime;

            gap.x = Mathf.Clamp(gap.x, -5f, 85f);

            tgrot = Quaternion.Euler(gap);

            Quaternion q = tgrot;
            q.x = q.z = 0f;

            camvec.transform.rotation = q;

        }


    }

    void Update()
    {
        if (PlayerCrash.player_die == false)
        {
            
            transform.position = Vector3.Lerp(transform.position, tg.position, Time.deltaTime * (Player_Camera.p_speed + MgerClass.InstFunc.speed * 2));
            camrot();
            Discam();
        }
    }
}
