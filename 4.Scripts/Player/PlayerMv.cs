using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMv : MonoBehaviour
{
    //private void Awake()
    //{
    //    anim = GetComponent<Animator>();
    //}
    ////PlayerCrash obj;
    //Animator anim;

    //private int speed;
    //private int count = 0;

    //float h;
    //float v;

    //private void PlayerMove(float h, float v)
    //{
    //    h = Input.GetAxis("Horizontal");
    //    v = Input.GetAxis("Vertical");        

    //    speed = 10 + MgerClass.InstFunc.speed * 2;
    //    Vector3 move = new Vector3(h, 0.0f, v);

    //    //초기 움직임 대상 park
    //    if (count == 0)
    //    {
    //        GameObject first = GameObject.FindGameObjectWithTag("player_1");
    //        if (first == null)
    //        {
    //            return;
    //        }
    //        else
    //        {
    //            first.transform.position += move * speed * Time.deltaTime;
    //            anim.SetBool("walk", true);
    //            //anim.SetBool("idle", false);
    //            if (h > 0)
    //            {
    //                //Debug.Log("i'm right");
    //                first.transform.rotation = Quaternion.Euler(0, 90, 0);
    //            }
    //            else if (h < 0)
    //            {
    //                //Debug.Log("i'm left");
    //                first.transform.rotation = Quaternion.Euler(0, 270, 0);
    //            }
    //            else if (v > 0)
    //            {
    //                //Debug.Log("i'm up");
    //                first.transform.rotation = Quaternion.Euler(0, 0, 0);
    //            }
    //            else if (v < 0)
    //            {
    //                //Debug.Log("i'm down");
    //                first.transform.rotation = Quaternion.Euler(0, 180, 0);
    //            }
    //            else
    //            {
    //                anim.SetBool("walk", false);
    //                //anim.SetBool("idle", true);
    //            }
    //        }
    //    }
    //}

    //private void FixedUpdate()
    //{
    //    PlayerMove(h,v);
    //}



    //public GameObject hid_Item;

    private Animator anim;

    private float speed;

    public Camera cam;
    float h;
    float v;

    private void Awake()
    {
        h = 0;
        v = 0;
        anim = GetComponent<Animator>();
    }

    private void PlayerMove(float h, float v)
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
     

        Vector3 move = new Vector3(h, 0.0f, v);
        GameObject first = GameObject.FindGameObjectWithTag("player_1");

        speed = 10 + MgerClass.InstFunc.speed * 2;

        first.transform.position += move * speed * Time.deltaTime;

        anim.SetBool("walk", true);
        //anim.SetBool("run", false);
        //anim.SetBool("idle", false);

        //if (PlayerCrash.run_OK == 1)
        //{
        //    if (Input.GetKey(KeyCode.LeftShift) == true)
        //    {
        //        first.transform.position += move * (speed + 0.2f) * Time.deltaTime;
        //        anim.SetBool("walk", false);
        //        anim.SetBool("idle", false);
        //        anim.SetBool("run", true);
        //    }
        //}
        if (h > 0)
        {
            if (v > 0)
            {
                first.transform.rotation = Quaternion.Euler(0, 45, 0);
            }
            else if (v < 0)
            {
                first.transform.rotation = Quaternion.Euler(0, 135, 0);
            }
            else
            {
                first.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
        else if (h < 0)
        {
            if (v > 0)
            {
                first.transform.rotation = Quaternion.Euler(0, -45, 0);
            }
            else if (v < 0)
            {
                first.transform.rotation = Quaternion.Euler(0, 225, 0);
            }
            else
            {
                first.transform.rotation = Quaternion.Euler(0, 270, 0);
            }
        }
        else if (v > 0)
        {
            first.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (v < 0)
        {
            first.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            anim.SetBool("walk", false);
            //anim.SetBool("run", false);
            //anim.SetBool("idle", true);
        }
    }

    private void position_Ck()
    {
        GameObject player = GameObject.FindGameObjectWithTag("player_1");
        if (this.gameObject.transform.position.y > 5.01f)
        {
            player.transform.position = new Vector3(player.transform.position.x, 5.0f, player.transform.position.z);
        }
    }

    //private void hidden_Item()
    //{
    //    if (GameObject.FindGameObjectWithTag("obj") == null && count == 0)
    //    {
    //        count++;
    //        Instantiate(hid_Item, this.gameObject.transform.position + new Vector3(0, 10.0f, 0), Quaternion.identity);
    //    }
    //}

    private void FixedUpdate()
    {



        if (GameObject.FindGameObjectWithTag("player_1") != null)
        {



            //position_Ck();

            if (PlayerCrash.player_die == false)
            {
                PlayerMove(h, v);
            }
        }
        //hidden_Item();
    }
}
