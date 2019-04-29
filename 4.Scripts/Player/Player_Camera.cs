using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{

    private Animator anim;
    private Player_2_Cam p_cam;
    public static float p_speed = 10.0f;

    private void Start()
    {
        
        anim = GetComponent<Animator>();

    }


    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 100f * Input.GetAxis("Mouse X"));
        }
        

    }


    private void FixedUpdate()
    {
        if (PlayerCrash.player_die == false)
        {

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 move = (Vector3.forward * v) + (Vector3.right * h);
            transform.Translate(move * (p_speed + MgerClass.InstFunc.speed * 2) * Time.deltaTime);




            if (h != 0 || v != 0)
            {
                anim.SetBool("run", true);
            }
            else
            {
                anim.SetBool("run", false);
            }
        }
    }

}
