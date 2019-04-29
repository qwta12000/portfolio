using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy4Ctrl : MonoBehaviour
{
    private Vector3 target;

    private GameObject tg;


    private Animator anim;
    private Transform target_1;
    private Transform target_2;
    private Transform target_3;
    private Transform target_4;
    private Transform target_5;
    private Transform target_6;
    private Transform target_7;
    private Transform target_8;
    private Transform target_9;
  

    public List<Mapclass> move_route;
    public List<Mapclass> stop_route;
    public List<Mapclass> unique_route;

    private Collider coll;
    private EnemyMap myMap;
    //private int temprand = 0;
    private Vector3 pos;



    private bool chek_f = true;
    private bool chek_b = true;
    private bool chek_r = true;
    private bool chek_l = true;


    private bool catDie = false;
    private bool chekhit = true;
    private bool chekatk = false;



    private int xnode = 0;
    private int znode = 0;


    public void rand_target()
    {

        int rand = Random.Range(1, 10);

        //while (temprand == rand)
        //{
        //    rand = Random.Range(1, 11);
        //}

        if (rand == 1)
        {
            target = target_1.position;
        }
        else if (rand == 2)
        {
            target = target_2.position;
        }
        else if (rand == 3)
        {
            target = target_3.position;
        }
        else if (rand == 4)
        {
            target = target_4.position;
        }
        else if (rand == 5)
        {
            target = target_5.position;
        }
        else if (rand == 6)
        {
            target = target_6.position;
        }
        else if (rand == 7)
        {
            target = target_7.position;
        }
        else if (rand == 8)
        {
            target = target_8.position;
        }
        else if (rand == 9)
        {
            target = target_9.position;
        }


        //temprand = rand;

    }



    private void Start()
    {
        myMap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();

        tg = GameObject.Find("target");

        target_1 = tg.transform.Find("targetpoint1");
        target_2 = tg.transform.Find("targetpoint2");
        target_3 = tg.transform.Find("targetpoint3");
        target_4 = tg.transform.Find("targetpoint4");
        target_5 = tg.transform.Find("targetpoint5");
        target_6 = tg.transform.Find("targetpoint6");
        target_7 = tg.transform.Find("targetpoint7");
        target_8 = tg.transform.Find("targetpoint8");
        target_9 = tg.transform.Find("targetpoint9");
  
        anim = GetComponent<Animator>();
        coll = GetComponent<SphereCollider>();

        xnode = myMap.getxnode();
        znode = myMap.getznode();
    }



    private void Update()
    {

        if (catDie == false)
        {
            if (chekatk == false)
            {
                movemap();
            }
            else if (chekatk == true)
            {
                enemy_Atk();
            }
            chek_Player();
        }

    }


    public void chek_Player()//플레이어 체크
    {

        Mapclass enemyPos = myMap.worldposition(transform.position);


        for (int i = 1; i <= 4; i++)
        {
            chekFunc_f(enemyPos.list_x, enemyPos.list_z + i);
            chekFunc_b(enemyPos.list_x, enemyPos.list_z - i);
            chekFunc_r(enemyPos.list_x + i, enemyPos.list_z);
            chekFunc_l(enemyPos.list_x - i, enemyPos.list_z);
        }

        chek_f = true;
        chek_b = true;
        chek_r = true;
        chek_l = true;


    }

    public void chekFunc_f(int x, int z)
    {
        if (chek_f == true && x >= 0 && x < xnode && z >= 0 && z < znode)
        {
            Mapclass newmap = myMap.bom_worldpos(x, z);
            if (newmap.chek_1obs == true || newmap.chek_2obs == true)
            {
                chek_f = false;
                return;
            }
            else if (newmap.chek_boom == true)
            {
                chek_f = false;
                if (chekatk == false)
                {
                    pos = newmap.worldPos;
                    chekatk = true;
                }
                return;
            }
        }
    }

    public void chekFunc_b(int x, int z)
    {
        if (chek_b == true && x >= 0 && x < xnode && z >= 0 && z < znode)
        {

            Mapclass newmap = myMap.bom_worldpos(x, z);
            if (newmap.chek_1obs == true || newmap.chek_2obs == true)
            {
                chek_b = false;
                return;
            }
            else if (newmap.chek_boom == true)
            {
                chek_b = false;
                if (chekatk == false)
                {
                    pos = newmap.worldPos;
                    chekatk = true;
                }
                return;
            }
        }
    }

    public void chekFunc_r(int x, int z)
    {
        if (chek_r == true && x >= 0 && x < xnode && z >= 0 && z < znode)
        {

            Mapclass newmap = myMap.bom_worldpos(x, z);
            if (newmap.chek_1obs == true || newmap.chek_2obs == true)
            {
                chek_r = false;
                return;
            }
            else if (newmap.chek_boom == true)
            {
                chek_r = false;
                if (chekatk == false)
                {
                    pos = newmap.worldPos;
                    chekatk = true;
                }
                return;
            }
        }
    }

    public void chekFunc_l(int x, int z)
    {
        if (chek_l == true && x >= 0 && x < xnode && z >= 0 && z < znode)
        {

            Mapclass newmap = myMap.bom_worldpos(x, z);
            if (newmap.chek_1obs == true || newmap.chek_2obs == true)
            {
                chek_l = false;
                return;
            }
            else if (newmap.chek_boom == true)
            {
                chek_l = false;
                if (chekatk == false)
                {
                    pos = newmap.worldPos;
                    chekatk = true;
                }
                return;
            }
        }
    }

    public void enemy_Atk()
    {
        chekatk = true;

        if (pos != transform.position)
        {
            Quaternion look = Quaternion.LookRotation(pos - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, look, Time.deltaTime * 10f);


            transform.position = Vector3.MoveTowards(transform.position, pos, Time.deltaTime * 10f);
        }
        
        if (chekhit == true && Vector3.Distance(pos, transform.position) <= 3)
        {
            chekhit = false;
            
            StartCoroutine(atktime());
        }
    }
    IEnumerator atktime()
    {
        yield return new WaitForSeconds(1.5f);
   
        chekhit = true;
        chekatk = false;
        unique_route.Clear();


    }

    void movemap()
    {
        if (unique_route.Count > 0)
        {
            Vector3 dist = unique_route[0].worldPos;

            //if (dist != transform.position)
            //{
                Quaternion look = Quaternion.LookRotation(dist - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, look, Time.deltaTime * 10f);

            //}
            //else
            //{
            //    rand_target();
            //}
            transform.position = Vector3.MoveTowards(transform.position, dist, Time.deltaTime * 3f);

            if (Vector3.Distance(transform.position, dist) < 0.001f)
            {
 
                StartFind();
            }
            if (Vector3.Distance(transform.position, target) < 0.5f)
            {
                rand_target();
            }
        }
        else
        {
            rand_target();
            StartFind();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (catDie == false)
        {
            if (other.tag == "explotion")
            {
                coll.enabled = false;
                MgerClass.InstFunc.enemyCount--;
                UI_mger.enemy_gold += 400;
                catDie = true;
                unique_route.Clear();
                anim.SetBool("die", true);
                Destroy(this.gameObject, 2);
            }
        }
    }

    void StartFind()
    {
        Mapclass startMap = myMap.worldposition(transform.position);
        Mapclass endMap = myMap.worldposition(target);

        move_route.Clear();
        stop_route.Clear();
        //unique_route.Clear();


        move_route.Add(startMap);

        while (move_route.Count > 0)
        {
            Mapclass newMap = move_route[0];//현재맵

            for (int i = 0; i < move_route.Count; i++)
            {
                if (move_route[i].f_cost < newMap.f_cost || move_route[i].f_cost == newMap.f_cost && move_route[i].h_cost < newMap.h_cost)
                {
                    newMap = move_route[i];
                }
            }

            move_route.Remove(newMap);
            stop_route.Add(newMap);

            if (newMap == endMap)
            {
                List<Mapclass> temp = new List<Mapclass>();

                while (endMap != startMap)
                {
                    temp.Add(endMap);
                    endMap = endMap.justpos;
                }

                temp.Reverse();

                unique_route = temp;
                return;
            }

            foreach (Mapclass nextMap in myMap.getnextmap(newMap))
            {
                if (!nextMap.chek_2obs && !nextMap.chek_boom && !nextMap.chek_1obs && !stop_route.Contains(nextMap))
                {
                    int move_cost = newMap.g_cost + manhattandist(newMap, nextMap);

                    if (!move_route.Contains(newMap) || nextMap.g_cost > move_cost)
                    {
                        nextMap.g_cost = move_cost;

                        nextMap.h_cost = manhattandist(nextMap, endMap);

                        nextMap.justpos = newMap;

                        if (!move_route.Contains(nextMap))
                        {
                            move_route.Add(nextMap);
                        }
                    }
                }
            }
        }
    }


    int manhattandist(Mapclass start, Mapclass next)
    {
        int dist = Mathf.Abs((start.list_x - next.list_x) * myMap.size_whith) + Mathf.Abs((start.list_z - next.list_z) * myMap.size_height);
        return dist;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;

        if (unique_route != null)
        {
            for (int i = 0; i < unique_route.Count - 1; i++)
            {
                Gizmos.DrawLine(unique_route[i].worldPos, unique_route[i + 1].worldPos);
            }
        }
    }
}
