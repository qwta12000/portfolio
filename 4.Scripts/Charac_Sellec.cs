using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Charac_Sellec : MonoBehaviour
{
    public GameObject target;
    public Animator anim;
    private bool chekslec_1 = false;
    private bool chekslec_2 = false;
    private bool chekslec_3 = false;
    private Sound_Mgr mgrsound;


    private void Start()
    {
        MgerClass.InstFunc.initData();
        mgrsound = GameObject.Find("sound").GetComponent<Sound_Mgr>();
        mgrsound.stage_1_sound(1);
    }

    public void OnclicSelection_3()
    {
        chekslec_3 = true;
        anim.SetBool("isRun_3", true);

    }


    public void OnclicSelection_2()
    {
        chekslec_2 = true;
        anim.SetBool("isRun_2", true);
    }

    public void OnclicSelection_1()
    {
        chekslec_1 = true;
        anim.SetBool("isRun_1", true);
    }

    public void Onclic_l_r()
    {
        chekslec_1 = false;
        chekslec_2 = false;
        chekslec_3 = false;
        anim.SetBool("isRun_1", false);
        anim.SetBool("isRun_2", false);
        anim.SetBool("isRun_3", false);
    }

    public void OnclikStart()
    {

        if (chekslec_1 == true)
        {
            
            PlayerPrefs.SetInt("charac", 1);
            

        }
        else if(chekslec_2 ==true)
        {
            

            PlayerPrefs.SetInt("charac", 2);
            


        }
        else if(chekslec_3 == true)
        {
            
            


        }
        else
        {

        }
        SceneManager.LoadScene("Stage_1");

    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit;

        }

        //transform.LookAt(target.transform.position);        
    }
}
