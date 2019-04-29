using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MgerClass : MonoBehaviour
{
    private static MgerClass Inst = null;
    private static GameObject single_obj = null;
    public static MgerClass InstFunc
    {
        get
        {
            if(Inst == null)
            {
                single_obj = new GameObject();
                single_obj.name = "MgerClass";
                Inst = single_obj.AddComponent(typeof(MgerClass)) as MgerClass;
            }
            return Inst;
        }
    }

    public int enemyCount = 5;

    public bool chek_boss = false;
    
    //public int defens = 0;
    //public int hand = 0;
    //public int shoe = 0;

    public int life = 5;
    public int speed = 0;
    public int power = 0;
    public int count = 1;
    public int score = 0;
    private string stage = " ";

    public void sevestage(string str)
    {
        PlayerPrefs.SetString("stage",str);
    }

    public string loadstage()
    {
        stage = PlayerPrefs.GetString("stage");
        return stage;
    }


    public void seveLife()
    {
        PlayerPrefs.SetInt("life", life);
    }
    public void loadLife()
    {
        life = PlayerPrefs.GetInt("life");
    }

    public void seveData()
    {
        
        PlayerPrefs.SetInt("speed", speed);
        PlayerPrefs.SetInt("power", power);
        PlayerPrefs.SetInt("count", count);
        PlayerPrefs.SetInt("score", score);
        //PlayerPrefs.SetInt("hand", hand);
        //PlayerPrefs.SetInt("shoe", shoe);
        //PlayerPrefs.SetInt("defens", defens);        
    }

    public void loadData()
    {        
        speed = PlayerPrefs.GetInt("speed");
        power = PlayerPrefs.GetInt("power");
        count = PlayerPrefs.GetInt("count");
        score = PlayerPrefs.GetInt("score");
        //hand = PlayerPrefs.GetInt("hand");
       //shoe = PlayerPrefs.GetInt("shoe");
        //defens = PlayerPrefs.GetInt("defens");       
    }

    public void initData()
    {
        //defens = 0;
        //hand = 0;
        //shoe = 0;
        life = 5;
        speed = 0;
        power = 0;
        count = 1;
        score = 0;

        PlayerPrefs.SetInt("speed", speed);
        PlayerPrefs.SetInt("power", power);
        PlayerPrefs.SetInt("count", count);
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("life", life);
        //PlayerPrefs.SetInt("hand", hand);
        //PlayerPrefs.SetInt("shoe", shoe);
       // PlayerPrefs.SetInt("defens", defens);
    }

}
