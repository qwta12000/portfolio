using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage_1 : MonoBehaviour
{
    public GameObject text_start;
    public Text text_stage_1;
    private int count = 0;
    public GameObject clear;
    private Sound_Mgr stg_sound;

    private EnemyMap myMap;
    private int xnode;
    private int znode;


    private GameObject[,] florarry;
    public GameObject flor1;
    public GameObject flor2;
    private float flor_h = 1f;
    public GameObject wall;
    public GameObject box_box;
    public GameObject kinetic_huacao;
    public GameObject kunetic_tree;
    private int randNum = 0;

    private void Awake()
    {        
        myMap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();
        xnode = myMap.getxnode();
        znode = myMap.getznode();
        florcreat();
    }

    void Start()
    {
        MgerClass.InstFunc.sevestage("Stage_1");
        StartCoroutine(blink_eft());
        stg_sound = GameObject.Find("sound").GetComponent<Sound_Mgr>();
        stg_sound.stage_1_sound(1);
    }

    public void florcreat()//맵 만들기
    {
        florarry = new GameObject[xnode, znode];
        for (int x = 0; x < xnode; x++)
        {
            for (int z = 0; z < znode; z++)
            {
                float xpos = myMap.dwonfloor.position.x + (myMap.size_whith * x);
                float zpos = myMap.dwonfloor.position.z + (myMap.size_height * z);

                if (x == 0 || z == 0 || x == xnode - 1 || z == znode - 1)
                {
                    florarry[x, z] = Instantiate(wall, new Vector3(xpos, transform.position.y, zpos), Quaternion.identity);
                }
                else
                {

                    if (x % 2 == 1)
                    {
                        if (z % 2 == 0)
                            florarry[x, z] = Instantiate(flor1, new Vector3(xpos, transform.position.y - flor_h, zpos), Quaternion.identity);
                        else
                            florarry[x, z] = Instantiate(flor2, new Vector3(xpos, transform.position.y - flor_h, zpos), Quaternion.identity);
                    }
                    else if (x % 2 == 0)
                    {
                        if (z % 2 == 1)
                            florarry[x, z] = Instantiate(flor1, new Vector3(xpos, transform.position.y - flor_h, zpos), Quaternion.identity);
                        else
                            florarry[x, z] = Instantiate(flor2, new Vector3(xpos, transform.position.y - flor_h, zpos), Quaternion.identity);
                    }

                    randNum = Random.Range(1, 10);
                    if (randNum <= 2)
                    {
                        if (x == 1 && z < 3 || z == 1 && x < 3)
                        {

                        }
                        else
                        {
                            Instantiate(box_box, new Vector3(xpos, transform.position.y + 1.5f, zpos), Quaternion.identity);

                        }


                    }
                    else if (randNum == 4)
                    {
                        if (x == 1 && z < 4 || z == 1 && x < 4)
                        {

                        }
                        else
                        {
                            Instantiate(kunetic_tree, new Vector3(xpos, transform.position.y + 0f, zpos), Quaternion.identity);
                        }
                    }
                    else if (randNum == 6)
                    {
                        if (x == 1 && z < 4 || z == 1 && x < 4)
                        {

                        }
                        else
                        {
                            Instantiate(kinetic_huacao, new Vector3(xpos, transform.position.y + 0.5f, zpos), Quaternion.identity);
                        }
                    }

                }
            }
        }
    }





    IEnumerator blink_eft()
    {
        while(count <=8)
        {
            text_stage_1.text = "";
            yield return new WaitForSeconds(0.1f);
            text_stage_1.text = "Stage 1";
            yield return new WaitForSeconds(0.1f);
            count++;

            if(count == 8)
            {
                text_stage_1.enabled = false;
                StartCoroutine(startEft());

            }
        }
    }

    IEnumerator startEft()
    {
        text_start.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        text_start.SetActive(false);
    }

    void Update()
    {
        //플레이어 쪽에 정리 겜오버이펙트  다시고민
        if(MgerClass.InstFunc.enemyCount == 0)
        {
            clear.SetActive(true);
            StartCoroutine(chektime());
        }
    }

    IEnumerator chektime()
    {
        yield return new WaitForSeconds(1.0f);
        clear.SetActive(false);
        

        MgerClass.InstFunc.seveData();
        MgerClass.InstFunc.seveLife();


        SceneManager.LoadScene("Stage_2");
    }

    public void nextstage()
    {
        MgerClass.InstFunc.seveData();
        MgerClass.InstFunc.seveLife();


        SceneManager.LoadScene("Stage_2");
    }
}
