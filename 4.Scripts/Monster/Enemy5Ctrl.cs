using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy5Ctrl : MonoBehaviour
{
    private Vector3 target;
    private GameObject shild;

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
    //private Transform target_10;
    private int life = 2;

    public List<Mapclass> move_route;
    public List<Mapclass> stop_route;
    public List<Mapclass> unique_route;


    private EnemyMap myMap;
    //private int temprand = 0;
    private Vector3 pos;
    private Collider coll;


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
        target = myMap.mon_target_position();
    }


    private void Awake()
    {

    }

    private void Start()
    {
        myMap = GameObject.Find("FloorMap").GetComponent<EnemyMap>();
        anim = GetComponent<Animator>();
        shild = transform.Find("Sphere 1").gameObject;
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
        
        
        for(int i = 1;i <= 4; i++)
        {
            chekFunc_f(enemyPos.list_x, enemyPos.list_z + i);
            chekFunc_b(enemyPos.list_x, enemyPos.list_z - i);
            chekFunc_r(enemyPos.list_x + i, enemyPos.list_z);
            chekFunc_l(enemyPos.list_x - i, enemyPos.list_z);
            //myMap.chek_player_f(enemyPos.list_x, enemyPos.list_z + i); 
            //myMap.chek_player_b(enemyPos.list_x, enemyPos.list_z - i);
            //myMap.chek_player_r(enemyPos.list_x + i, enemyPos.list_z);
            //myMap.chek_player_l(enemyPos.list_x - i, enemyPos.list_z);
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
            else if (newmap.chek_player_1 == true || newmap.chek_player_2 == true || newmap.chek_player_3 == true)
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
            else if (newmap.chek_player_1 == true || newmap.chek_player_2 == true || newmap.chek_player_3 == true)
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
            else if (newmap.chek_player_1 == true || newmap.chek_player_2 == true || newmap.chek_player_3 == true)
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
            else if (newmap.chek_player_1 == true || newmap.chek_player_2 == true || newmap.chek_player_3 == true)
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
        anim.SetBool("run", true);

        shild.SetActive(true);

        if (chekhit == true && Vector3.Distance(pos, transform.position) <= 3)
        {
            chekhit = false;            
            anim.SetBool("attack", true);
            StartCoroutine(atktime());
        }
    }
    IEnumerator atktime()
    {
        yield return new WaitForSeconds(1.5f);
        anim.SetBool("attack", false);
        anim.SetBool("run", false);
        chekhit = true;
        chekatk = false;
        unique_route.Clear();
        shild.SetActive(false);

    }

    void movemap()
    {
        if (unique_route.Count > 0)
        {
            Vector3 dist = unique_route[0].worldPos;

            if (dist != transform.position)
            {
                Quaternion look = Quaternion.LookRotation(dist - transform.position);
                transform.rotation = Quaternion.Lerp(transform.rotation, look, Time.deltaTime * 10f);

            }
            else
            {
                rand_target();
            }
            transform.position = Vector3.MoveTowards(transform.position, dist, Time.deltaTime * 3f);

            if (Vector3.Distance(transform.position, dist) < 0.01f)
            {
                //rand_target();
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "explotion")
        {
            if (chekatk == false)
            {
                anim.SetBool("hit", true);
                life--;
                if (life == 0)
                {
                    coll.enabled = false;
                    MgerClass.InstFunc.enemyCount--;
                    UI_mger.enemy_gold += 500;
                    catDie = true;
                    unique_route.Clear();
                    anim.SetBool("Die", true);
                    Destroy(this.gameObject, 2);
                }
                anim.SetBool("hit", false);
            }
        }
    }



    public void chekDieFunc()
    {
        if (chekhit == true)
        {
            anim.SetBool("hit", true);
            life--;
            if (life == 0)
            {
                MgerClass.InstFunc.enemyCount--;
                UI_mger.enemy_gold += 500;
                catDie = true;
                unique_route.Clear();
                anim.SetBool("Die", true);
                Destroy(this.gameObject,2);
            }
            anim.SetBool("hit", false);
        }

    }

    void StartFind()
    {
        Mapclass startMap = myMap.worldposition(transform.position);
        Mapclass endMap = myMap.worldposition(target);

        move_route.Clear();
        stop_route.Clear();
        unique_route.Clear();


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


    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.magenta;

    //    if (unique_route != null)
    //    {
    //        for (int i = 0; i < unique_route.Count - 1; i++)
    //        {
    //            Gizmos.DrawLine(unique_route[i].worldPos, unique_route[i + 1].worldPos);
    //        }
    //    }
    //}
}
