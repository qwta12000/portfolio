using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerCtl : MonoBehaviour
{   
    public GameObject park;
    public GameObject seo;
    private int characNum = 0;
    
    public GameObject mon_1;
    public GameObject mon_2;
    public GameObject mon_3;
    public GameObject mon_4;
    public GameObject mon_5;
    public GameObject boss;

    private EnemyMap myMap;

    private void Start()
    {
        StartCoroutine(Park_choose());//캐릭터생성
        characNum = PlayerPrefs.GetInt("charac");
        StartCoroutine(monsterStart());// 몬스터생성
        myMap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();
    }

    IEnumerator bosscreat()//보스 생성
    {
        
        yield return new WaitForSeconds(3.0f);
        Instantiate(boss, new Vector3(35, 0, 25), Quaternion.identity);
    }

    //캐릭터 생성
    IEnumerator Park_choose()
    {
        yield return new WaitForSeconds(2.5f);
        
        if (characNum == 1)
        {
            //1 캐릭 생성

            Instantiate(park, new Vector3(-35, 0.0f, -25), Quaternion.identity);
        }
        else if(characNum == 2)
        {
            //2 캐릭 생성
            Instantiate(seo, new Vector3(-35, 0.0f, -25), Quaternion.identity);

        }
        else if(characNum == 3)
        {
            //3캐릭 생성
        }
    }

    IEnumerator monsterStart()
    {
        yield return new WaitForSeconds(2.5f);

        if (MgerClass.InstFunc.chek_boss == false)
        {
            Instantiate(mon_1, myMap.mon_instatate(), Quaternion.identity);
            Instantiate(mon_2, myMap.mon_instatate(), Quaternion.identity);
            Instantiate(mon_3, myMap.mon_instatate(), Quaternion.identity);
            Instantiate(mon_4, myMap.mon_instatate(), Quaternion.identity);
            Instantiate(mon_5, myMap.mon_instatate(), Quaternion.identity);
        }
        else
        {

            StartCoroutine(bosscreat());
        }
    }
}


