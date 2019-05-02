using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    private string stage = " ";
    private GameObject msg;
    private Sound_Mgr stg_sound;
    void Start()
    {
        //stg_sound = GameObject.Find("sound").GetComponent<Sound_Mgr>();
        //stg_sound.stage_1_sound(2);
        stage = MgerClass.InstFunc.loadstage();
        msg = GameObject.Find("msg");
        
    }


    public void OnclickRestart()
    {
        //if (stage ==null)
        //{
        //    msg.SetActive(true);
        //    StartCoroutine(timechek());            
        //}
        //else
        //{
        //    SceneManager.LoadScene(stage);
        //}

        
        MgerClass.InstFunc.initData();

        SceneManager.LoadScene(stage);

    }

    IEnumerator timechek()
    {
        yield return new WaitForSeconds(1.0f);
        msg.SetActive(false);
    }

    public void OnclickMenu()
    {

        MgerClass.InstFunc.sevestage(" ");
        MgerClass.InstFunc.initData();

        SceneManager.LoadScene("SampleScene");
    }

    public void Onclickend()
    {

        MgerClass.InstFunc.sevestage(" ");
        Application.Quit();
    }

    
    void Update()
    {
        
    }
}
