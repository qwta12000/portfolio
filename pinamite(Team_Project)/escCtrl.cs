using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class escCtrl : MonoBehaviour
{
    private GameObject escMenu = null;
    private bool chekesc = true;
    void Start()
    {
        escMenu = GameObject.Find("uimger").transform.Find("escmenu").gameObject;
    }


    public void escChekFunc()
    {
        if (chekesc == true)
        {
            escMenu.SetActive(true);
            chekesc = false;
            Time.timeScale = 0f;
        }
        else if (chekesc == false)
        {
            escMenu.SetActive(false);
            chekesc = true;
            Time.timeScale = 1f;
        }
    }

    public void menuchekFunc()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void carracFunc()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Charrac");

    }
    public void endFunc()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (chekesc == true)
            {
                escMenu.SetActive(true);
                chekesc = false;
                Time.timeScale = 0f;
            }
            else if (chekesc == false)
            {
                escMenu.SetActive(false);
                chekesc = true;
                Time.timeScale = 1f;
            }

        }
    }
}
