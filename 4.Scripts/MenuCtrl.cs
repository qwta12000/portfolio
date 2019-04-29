using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuCtrl : MonoBehaviour
{

    private Sound_Mgr mgrsoun;


    private void Start()
    {
        mgrsoun = GameObject.Find("sound").GetComponent<Sound_Mgr>();
        mgrsoun.stage_1_sound(1);
    }

    public void OnclickEnd()
    {
        Application.Quit();
    }

    public void OnclickSeve()
    {

    }
    
    public void OnclickStart()
    {
        SceneManager.LoadScene("Charrac");
    }
}
