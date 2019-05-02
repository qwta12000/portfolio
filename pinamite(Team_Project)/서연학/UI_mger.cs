using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class UI_mger : MonoBehaviour
{
    private GameObject red_1 = null;
    private GameObject red_2 = null;
    private GameObject red_3 = null;
    private GameObject red_4 = null;
    private GameObject red_5 = null;

    private GameObject speed_1 = null;
    private GameObject speed_2 = null;
    private GameObject speed_3 = null;
    private GameObject speed_4 = null;

    private GameObject power_1 = null;
    private GameObject power_2 = null;
    private GameObject power_3 = null;
    private GameObject power_4 = null;

    private GameObject count_1 = null;
    private GameObject count_2 = null;
    private GameObject count_3 = null;
    private GameObject count_4 = null;

    private GameObject mon_1 = null;
    private GameObject mon_2 = null;
    private GameObject mon_3 = null;
    private GameObject mon_4 = null;
    private GameObject mon_5 = null;

    private Text gold = null;


    private Text timechek;
    private float secont = 0;
    private float chektime = 0;
    private int minute = 0;



    public static int enemy_gold = 0;
    public static int box_gold = 0;
    public static int time_gold = 0;
    public static int item_gold = 0;
    public static int total = 0;


    void Start()
    {
        red_1 = transform.Find("red_1").gameObject;
        red_2 = transform.Find("red_2").gameObject;
        red_3 = transform.Find("red_3").gameObject;
        red_4 = transform.Find("red_4").gameObject;
        red_5 = transform.Find("red_5").gameObject;

        

        speed_1 =transform.Find("speed_1").gameObject;
        speed_2 =transform.Find("speed_2").gameObject;
        speed_3 =transform.Find("speed_3").gameObject;
        speed_4 =transform.Find("speed_4").gameObject;

        power_1 =transform.Find("power_1").gameObject;
        power_2 =transform.Find("power_2").gameObject;
        power_3 =transform.Find("power_3").gameObject;
        power_4 =transform.Find("power_4").gameObject;

        count_1 = transform.Find("count_1").gameObject;
        count_2 = transform.Find("count_2").gameObject;
        count_3 = transform.Find("count_3").gameObject;
        count_4 = transform.Find("count_4").gameObject;

        mon_1 = transform.Find("mon_1").gameObject;
        mon_2 = transform.Find("mon_2").gameObject;
        mon_3 = transform.Find("mon_3").gameObject;
        mon_4 = transform.Find("mon_4").gameObject;
        mon_5 = transform.Find("mon_5").gameObject;

        gold = transform.Find("gold_text").GetComponent<Text>();

        timechek = transform.Find("timechek").gameObject.GetComponent<Text>();

    }


    void Update()
    {
        chektime += Time.deltaTime;
        if(chektime>=2.5)
        {
            time_func();
        }
        lifeFunc();
        countFunc();
        powerFunc();
        speedFunc();
        monFunc();


        total = enemy_gold + box_gold + time_gold + item_gold; ;
        MgerClass.InstFunc.score = total;
        gold.text = MgerClass.InstFunc.score.ToString("000000");
    }


    public void collTotal_func()
    {

    }



    public void time_func()
    {
        secont += Time.deltaTime;
        if(secont >= 60)
        {
            minute += 1;
            secont = 0;            
        }

        timechek.text = minute.ToString("00") + ":" + secont.ToString("00");
    }




    public void monFunc()
    {
        if(MgerClass.InstFunc.enemyCount == 5)
        {
            mon_1.GetComponent<Image>().enabled = true;
            mon_2.GetComponent<Image>().enabled = true;
            mon_3.GetComponent<Image>().enabled = true;
            mon_4.GetComponent<Image>().enabled = true;
            mon_5.GetComponent<Image>().enabled = true;
        }
        else if(MgerClass.InstFunc.enemyCount == 4)
        {
            mon_1.GetComponent<Image>().enabled = false;
            mon_2.GetComponent<Image>().enabled = true;
            mon_3.GetComponent<Image>().enabled = true;
            mon_4.GetComponent<Image>().enabled = true;
            mon_5.GetComponent<Image>().enabled = true;
        }
        else if(MgerClass.InstFunc.enemyCount == 3)
        {
            mon_1.GetComponent<Image>().enabled = false;
            mon_2.GetComponent<Image>().enabled = false;
            mon_3.GetComponent<Image>().enabled = true;
            mon_4.GetComponent<Image>().enabled = true;
            mon_5.GetComponent<Image>().enabled = true;
        }
        else if(MgerClass.InstFunc.enemyCount == 2)
        {
            mon_1.GetComponent<Image>().enabled = false;
            mon_2.GetComponent<Image>().enabled = false;
            mon_3.GetComponent<Image>().enabled = false;
            mon_4.GetComponent<Image>().enabled = true;
            mon_5.GetComponent<Image>().enabled = true;
        }
        else if(MgerClass.InstFunc.enemyCount == 1)
        {
            mon_1.GetComponent<Image>().enabled = false;
            mon_2.GetComponent<Image>().enabled = false;
            mon_3.GetComponent<Image>().enabled = false;
            mon_4.GetComponent<Image>().enabled = false;
            mon_5.GetComponent<Image>().enabled = true;
        }
        else if(MgerClass.InstFunc.enemyCount == 0)
        {
            mon_1.GetComponent<Image>().enabled = false;
            mon_2.GetComponent<Image>().enabled = false;
            mon_3.GetComponent<Image>().enabled = false;
            mon_4.GetComponent<Image>().enabled = false;
            mon_5.GetComponent<Image>().enabled = false;
        }
    }




    public void countFunc()
    {
        if(MgerClass.InstFunc.count == 1)
        {
            count_1.SetActive(false);
            count_2.SetActive(false);
            count_3.SetActive(false);
            count_4.SetActive(false);
        }
        else if (MgerClass.InstFunc.count == 2)
        {
            count_1.SetActive(true);
            count_2.SetActive(false);
            count_3.SetActive(false);
            count_4.SetActive(false);
        }
        else if (MgerClass.InstFunc.count == 3)
        {
            count_1.SetActive(true);
            count_2.SetActive(true);
            count_3.SetActive(false);
            count_4.SetActive(false);
        }
        else if (MgerClass.InstFunc.count == 4)
        {
            count_1.SetActive(true);
            count_2.SetActive(true);
            count_3.SetActive(true);
            count_4.SetActive(false);
        }
        else if (MgerClass.InstFunc.count == 5)
        {
            count_1.SetActive(true);
            count_2.SetActive(true);
            count_3.SetActive(true);
            count_4.SetActive(true);
        }
    }

    public void powerFunc()//아이템 파워 ui
    {
        if(MgerClass.InstFunc.power == 0)
        {
            power_1.SetActive(false);
            power_2.SetActive(false);
            power_3.SetActive(false);
            power_4.SetActive(false);            
        }
        else if(MgerClass.InstFunc.power == 1)
        {
            power_1.SetActive(true);
            power_2.SetActive(false);
            power_3.SetActive(false);
            power_4.SetActive(false);
        }
        else if (MgerClass.InstFunc.power == 2)
        {
            power_1.SetActive(true);
            power_2.SetActive(true);
            power_3.SetActive(false);
            power_4.SetActive(false);
        }
        else if (MgerClass.InstFunc.power == 3)
        {
            power_1.SetActive(true);
            power_2.SetActive(true);
            power_3.SetActive(true);
            power_4.SetActive(false);
        }
        else if (MgerClass.InstFunc.power == 4)
        {
            power_1.SetActive(true);
            power_2.SetActive(true);
            power_3.SetActive(true);
            power_4.SetActive(true);
        }

    }

    public void speedFunc()//아치템 스피드 ui
    {
        if(MgerClass.InstFunc.speed == 0)
        {
            speed_1.SetActive(false);
            speed_2.SetActive(false);
            speed_3.SetActive(false);
            speed_4.SetActive(false);
        }
        else if (MgerClass.InstFunc.speed == 1)
        {
            speed_1.SetActive(true);
            speed_2.SetActive(false);
            speed_3.SetActive(false);
            speed_4.SetActive(false);
        }
        else if (MgerClass.InstFunc.speed == 2)
        {
            speed_1.SetActive(true);
            speed_2.SetActive(true);
            speed_3.SetActive(false);
            speed_4.SetActive(false);
        }
        else if (MgerClass.InstFunc.speed == 3)
        {
            speed_1.SetActive(true);
            speed_2.SetActive(true);
            speed_3.SetActive(true);
            speed_4.SetActive(false);
        }
        else if (MgerClass.InstFunc.speed == 4)
        {
            speed_1.SetActive(true);
            speed_2.SetActive(true);
            speed_3.SetActive(true);
            speed_4.SetActive(true);
        }
    }

    public void lifeFunc()//목숨체크
    {
        if (MgerClass.InstFunc.life == 0)
        {
            red_1.SetActive(false);
            red_2.SetActive(false);
            red_3.SetActive(false);
            red_4.SetActive(false);
            red_5.SetActive(false);
        }
        else if (MgerClass.InstFunc.life == 1)
        {
            red_1.SetActive(true);
            red_2.SetActive(false);
            red_3.SetActive(false);
            red_4.SetActive(false);
            red_5.SetActive(false);
        }
        else if (MgerClass.InstFunc.life == 2)
        {
            red_1.SetActive(true);
            red_2.SetActive(true);
            red_3.SetActive(false);
            red_4.SetActive(false);
            red_5.SetActive(false);
        }
        else if (MgerClass.InstFunc.life == 3)
        {
            red_1.SetActive(true);
            red_2.SetActive(true);
            red_3.SetActive(true);
            red_4.SetActive(false);
            red_5.SetActive(false);
        }
        else if (MgerClass.InstFunc.life == 4)
        {
            red_1.SetActive(true);
            red_2.SetActive(true);
            red_3.SetActive(true);
            red_4.SetActive(true);
            red_5.SetActive(false);
        }
        else if (MgerClass.InstFunc.life == 5)
        {
            red_1.SetActive(true);
            red_2.SetActive(true);
            red_3.SetActive(true);
            red_4.SetActive(true);
            red_5.SetActive(true);
        }
    }
}
